using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RshCSharpWrapper.Device;
using RshCSharpWrapper;
using RshCSharpWrapper.Types;
using Channel = RshCSharpWrapper.Device.Channel;
using Double = RshCSharpWrapper.Types.Double;
using InitMemory = RshCSharpWrapper.Device.InitMemory;

namespace RshCSharpWrapperTest
{
    [TestClass]
    public class ADCTests
    {
        //TODO: Когда прогоняете тесты, убедитесь что ваша плата может работать при указанных ниже параметрах.
        
        //Размер собираемого блока данных в отсчётах (на канал).
        const uint BSIZE = 1048576;
        //Частота дискретизации. 
        const double SAMPLE_FREQ = 1.0e+8;

        [TestMethod]
        public void GetADCList()
        {
            var result = Device.RshGetRegisteredDeviceNames();
            Assert.IsFalse(result.Count == 0, "There is no boards installed on this machine.");
        }

        [TestMethod]
        public void GetGainList()
        {
            foreach (var deviceName in Device.RshGetRegisteredDeviceNames())
                using (var device = new Device(deviceName))
                {
                    var list = device.Get(GET.DEVICE_GAIN_LIST);
                }
        }

        [TestMethod]
        public void GetBaseAddressList()
        {
            foreach (var deviceName in Device.RshGetRegisteredDeviceNames())
            {
                using (var device = new Device(deviceName))
                {
                    var list = device.Get(GET.DEVICE_BASE_LIST);                    
                }
            }
        }

        [TestMethod]
        public void GetParameters()
        {
            foreach (var deviceName in Device.RshGetRegisteredDeviceNames())
                using (var device = new Device(deviceName))
                {                
                    var types = new List<Type>
                    {
                        typeof(S8P),
                        typeof(U16P),
                        typeof(U32),
                        typeof(U64),
                        typeof(Double),
                        typeof(BufferU32)
                    };
                    var res = new Dictionary<Type, string>();
                    foreach (var type in types)
                    {
                        res.Add(type,"");
                        foreach (var v in GETHelper.GetModes(x => x.Type == type && x.Input == false))
                        {
                            // API? api = API.SUCCESS;

                            try
                            {
                                var result = device.Get(v);
                                res[type] += v + ":" + result + "   API:" + API.SUCCESS + "\n";
                            }
                            catch (RshDeviceException ex)
                            {
                                res[type] += v + ":" + "null" + "   API:" + ex.Api + "," + ex.Message + "\n";
                            } 
                        
                        }              
                    }                
                    // Смотрите переменную res, в ней содержится список данных отданных платой.
                }
        }

        [TestMethod]
        public void GetErrorTexts()
        {
            string str = "";
            foreach (API api in Enum.GetValues(typeof(API)))
            {
                str += api + ":" + Connector.GetError(api, LANGUAGE.ENGLISH) + "\n";
                str += api + ":" + Connector.GetError(api, LANGUAGE.RUSSIAN) + "\n";
            }            
        }

        [TestMethod]
        public void IsCapable()
        {
            foreach (var deviceName in Device.RshGetRegisteredDeviceNames())
                using (var device = new Device(deviceName))
                {
                    string res = "";
                    foreach (CAPS cap in Enum.GetValues(typeof(CAPS)))
                        res += cap + ":" + device.IsCapable(cap) + "\n";
                    //Смотрите переменную res, в ней содержится список всего того что может ваша плата.
                }
        }

        [TestMethod]
        public void GetDataFromDriver()
        {
            foreach (var deviceName in Device.RshGetRegisteredDeviceNames())
                //if(deviceName=="LAN4USB")//!?
                using (var device = new Device(deviceName))
                {
                    device.Connect();
                
                    //Структура для инициализации параметров работы устройства.  
                    var p = new InitMemory();
                    //Запуск сбора данных программный. 
                    p.startType = (uint)InitADC.StartTypeBit.Program;
                    //Размер внутреннего блока данных, по готовности которого произойдёт прерывание.
                    p.bufferSize = BSIZE;
                    //Частота дискретизации.
                    p.frequency = SAMPLE_FREQ;

                    //Сделаем 0-ой канал активным.
                    p.channels[0].control = (uint)Channel.ControlBit.Used;
                    //Зададим коэффициент усиления для 0-го канала.
                    p.channels[0].gain = 10;

                    //Сделаем 0-ой канал активным.
                    p.channels[1].control = (uint)Channel.ControlBit.Used;
                    //Зададим коэффициент усиления для 0-го канала.
                    p.channels[1].gain = 10;

                    //Инициализация устройства (передача выбранных параметров сбора данных)
                    //После инициализации неправильные значения в структуре будут откорректированы.
                    var res = device.Init(p);

                    //=================== ИНФОРМАЦИЯ О ПРЕДСТОЯЩЕМ СБОРЕ ДАННЫХ ====================== 
                    uint 
                        activeChannelsCount = device.Get(GET.DEVICE_ACTIVE_CHANNELS_NUMBER),
                        serNum = device.Get(GET.DEVICE_SERIAL_NUMBER);                

                    // Время ожидания(в миллисекундах) до наступления прерывания. Прерывание произойдет при полном заполнении буфера. 
                    U32 waitTime = new U32() { data = 100000 };
                
                    device.Start(); // Запускаем плату на сбор буфера.

                    if (device.Get(GET.WAIT_BUFFER_READY_EVENT, waitTime)==100000)	// Ожидаем готовность буфера.
                    {
                        device.Stop();

                        //Буфер с данными в мзр.
                        short[] userBuffer = new short[p.bufferSize * activeChannelsCount];
                        //Буфер с данными в вольтах.
                        double[] userBufferD = new double[p.bufferSize * activeChannelsCount];

                        byte[] userBufferB = new byte[p.bufferSize * activeChannelsCount];

                        //Получаем буфер с данными.
                        //device.GetData(userBuffer);

                        ////Получаем буфер с данными. В этом буфере будут те же самые данные, но преобразованные в вольты.
                        //device.GetData(userBufferD);

                        //device.GetData(userBufferB);

                        sbyte[] userBufferSB = new sbyte[userBufferB.Length];
                        Buffer.BlockCopy(userBufferB, 0, userBufferSB, 0, userBufferB.Length);
                        // Выведем в консоль данные в вольтах. (первые 10 измерений)
                        for (int i = 0; i < 10; i++)
                            Console.WriteLine(userBufferD[i].ToString());
                    }
                }
        }        
    }
}
