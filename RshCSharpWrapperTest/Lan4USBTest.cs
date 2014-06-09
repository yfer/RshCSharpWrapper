using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RshCSharpWrapper.Device;
using RshCSharpWrapper;
using System.Reflection;
using RshCSharpWrapper.Types;

namespace RshCSharpWrapperTest
{
    [TestClass]
    public class Lan4USBTest
    {
        //TODO: Когда прогоняете тесты, убедитесь что ваша плата может работать при указанных ниже параметрах.
        //Служебное имя платы, с которой будет работать программа.
        const string BOARD_NAME = "LAn4USB"; 
        //Размер собираемого блока данных в отсчётах (на канал).
        const uint BSIZE = 1048576;
        //Частота дискретизации. 
        const double SAMPLE_FREQ = 1.0e+8;
        
        [TestMethod]
        public void GetTextParameters()
        {
            using (var device = new Device(BOARD_NAME))
            {
                string res = "";
                foreach(var v in GETHelper.GetModes( x => x.Name == Names.S8P || x.Name == Names.U16P ) )
                {
                    API? api = API.SUCCESS;
                    res += v + ":" + device.Get(v, ref api) + "   API:" + api + "\n";
                }                
                // Смотрите переменную res, в ней содержится список текстовых данных отданных платой.
            }
        }
        [TestMethod]
        public void IsCapable()
        {
            using (var device = new Device(BOARD_NAME))
            {
                string res = "";
                foreach (var cap in Enum.GetNames(typeof(CAPS)))
                    res += cap + ":" + device.IsCapable((CAPS)Enum.Parse(typeof(CAPS), cap)) + "\n";
                //Смотрите переменную res, в ней содержится список всего того что может ваша плата.
            }
        }
        [TestMethod]
        public void GetDataFromDriver()
        {
            using (var device = new Device(BOARD_NAME))
            {
                //Подключаемся к устройству. Нумерация начинается с 1.
                device.Connect(1);
                
                //Структура для инициализации параметров работы устройства.  
                var p = new RshCSharpWrapper.Device.InitMemory();
                //Запуск сбора данных программный. 
                p.startType = (uint)RshCSharpWrapper.Device.InitMemory.StartTypeBit.Program;
                //Размер внутреннего блока данных, по готовности которого произойдёт прерывание.
                p.bufferSize = BSIZE;
                //Частота дискретизации.
                p.frequency = SAMPLE_FREQ;

                //Сделаем 0-ой канал активным.
                p.channels[0].control = (uint)RshCSharpWrapper.Device.Channel.ControlBit.Used;
                //Зададим коэффициент усиления для 0-го канала.
                p.channels[0].gain = 1;

                //Инициализация устройства (передача выбранных параметров сбора данных)
                //После инициализации неправильные значения в структуре будут откорректированы.
                device.Init(p);

                //=================== ИНФОРМАЦИЯ О ПРЕДСТОЯЩЕМ СБОРЕ ДАННЫХ ====================== 
                uint 
                    activeChanNumber = device.Get(GET.DEVICE_ACTIVE_CHANNELS_NUMBER),
                    serNum = device.Get(GET.DEVICE_SERIAL_NUMBER);                

                // Время ожидания(в миллисекундах) до наступления прерывания. Прерывание произойдет при полном заполнении буфера. 
                RshCSharpWrapper.Types.U32 waitTime = new RshCSharpWrapper.Types.U32() { data = 100000 };
                
                device.Start(); // Запускаем плату на сбор буфера.

                if (device.Get(GET.WAIT_BUFFER_READY_EVENT, waitTime)==100000)	// Ожидаем готовность буфера.
                {
                    device.Stop();

                    //Буфер с данными в мзр.
                    short[] userBuffer = new short[p.bufferSize * activeChanNumber];
                    //Буфер с данными в вольтах.
                    double[] userBufferD = new double[p.bufferSize * activeChanNumber];

                    //Получаем буфер с данными.
                    device.GetData(userBuffer);

                    //Получаем буфер с данными. В этом буфере будут те же самые данные, но преобразованные в вольты.
                    device.GetData(userBufferD);

                    // Выведем в консоль данные в вольтах. (первые 10 измерений)
                    for (int i = 0; i < 10; i++)
                        Console.WriteLine(userBufferD[i].ToString());
                }
            }
        }        
    }
}
