using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RshCSharpWrapper.Device;
using RshCSharpWrapper;
using RshCSharpWrapper.Types;
using Double = RshCSharpWrapper.Types.Double;

namespace RshCSharpWrapperTest
{
    [TestClass]
    public class ADCTests
    {
        [TestMethod]
        public void GetADCList()
        {
            var result = Device.GetRegisteredDeviceNames();
            Assert.IsFalse(result.Count == 0, "There is no boards installed on this machine.");
        }

        [TestMethod]
        public void GetGainList()
        {
            foreach (var deviceName in Device.GetRegisteredDeviceNames())
                using (var device = new Device(deviceName))
                {
                    var list = device.Get(GET.DEVICE_GAIN_LIST);
                }
        }

        [TestMethod]
        public void GetBaseAddressList()
        {
            foreach (var deviceName in Device.GetRegisteredDeviceNames())
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
            foreach (var deviceName in Device.GetRegisteredDeviceNames())
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
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en");
                str += api + ":" + Connector.GetError(api) + "\n";
                Thread.CurrentThread.CurrentCulture = new CultureInfo("ru");
                str += api + ":" + Connector.GetError(api) + "\n";
            }            
        }

        [TestMethod]
        public void IsCapable()
        {
            foreach (var deviceName in Device.GetRegisteredDeviceNames())
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
            var r = new Random();
            foreach (var deviceName in Device.GetRegisteredDeviceNames())
                if(deviceName=="LAN4USB")//!?
                using (var device = new Device(deviceName))
                {
                    var gains = (uint[])device.Get(GET.DEVICE_GAIN_LIST);
                    var freqs = (double[])device.Get(GET.DEVICE_FREQUENCY_LIST);
                    var bufs = (uint[])device.Get(GET.DEVICE_SIZE_LIST);
                    device.Connect();
                
                    //Структура для инициализации параметров работы устройства.  
                    var p = new InitMemory
                    {
                        //Запуск сбора данных программный. 
                        StartType = StartType.Program,
                        //Размер внутреннего блока данных, по готовности которого произойдёт прерывание.
                        BufferSize = bufs[bufs.Count()-1],
                        //Частота дискретизации.
                        frequency = freqs[freqs.Count()-1]
                    };

                    //Сделаем 0-ой канал активным.
                    p.channels[0].Control = ChannelControl.Used;
                    //Зададим коэффициент усиления для 0-го канала.
                    p.channels[0].Gain = gains[r.Next(gains.Count())];

                    //Сделаем 1-ый канал активным.
                    p.channels[1].Control = ChannelControl.Used;
                    //Зададим коэффициент усиления для 1-го канала.
                    p.channels[1].Gain = gains[r.Next(gains.Count())];

                    //Инициализация устройства (передача выбранных параметров сбора данных)
                    //После инициализации неправильные значения в структуре будут откорректированы.
                    device.Init(p);

                    // Время ожидания(в миллисекундах) до наступления прерывания. Прерывание произойдет при полном заполнении буфера. 
                    var sw = new Stopwatch();
                    sw.Start();
                    for (var i = 0; i < 10; i++)
                    {
                        device.Start(); // Запускаем плату на сбор буфера.                        
                        if (device.WaitBufferReady())
                        {
                            //Получаем буфер с данными.
                            //var ret1 = device.GetData(Device.DataTypeEnum.Int16);
                            //var ret2 = device.GetData(Device.DataTypEnum.UInt16);//Throws
                            //var ret3 = device.GetData(Device.DataTypeEnum.Int32);
                            //var ret4 = device.GetData(Device.DataTypEnum.UInt32);//Throws
                            var ret5 = device.GetData(Device.DataTypeEnum.Double);
                            //var ret6 = device.GetData(Device.DataTypeEnum.Int8);
                            //var ret7 = device.GetData(Device.DataTypeEnum.UInt8);
                        }
                    }
                    sw.Stop();
                    var t = sw.ElapsedMilliseconds;
                    device.Stop();
                }
        }        
    }
}
