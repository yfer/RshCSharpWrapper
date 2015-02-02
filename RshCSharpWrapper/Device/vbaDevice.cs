//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace RshCSharpWrapper.Device
//{
//    [System.Runtime.InteropServices.ClassInterface(System.Runtime.InteropServices.ClassInterfaceType.AutoDual)]
//    public class vbaDevice
//    {
//        Device device = new Device();

//        public API Connect(string name, int index)
//        {
//            API st;

//            device.EstablishDriverConnection(name);
//            /*
//            //=================== ИНФОРМАЦИЯ О ЗАГРУЖЕННОЙ БИБЛИОТЕКЕ ====================== 
//            string libVersion, libname, libCoreVersion, libCoreName;

//            st = device.Get(RSH_GET.LIBRARY_VERSION_STR, out libVersion);
//            if (st != RSH_API.SUCCESS) return st;//return SayGoodBye(st);

//            st = device.Get(RSH_GET.CORELIB_VERSION_STR, out libCoreVersion);
//            st = device.Get(RSH_GET.CORELIB_FILENAME, out libCoreName);
//            st = device.Get(RSH_GET.LIBRARY_FILENAME, out libname);

//            Console.WriteLine("Library Name: {0:d}", libname);
//            Console.WriteLine("Library Version: {0:d}", libVersion);
//            Console.WriteLine("\nCore Library Name: {0:d}", libCoreName);
//            Console.WriteLine("Core Library Version: {0:d}", libCoreVersion);
//            */
//            //===================== ПРОВЕРКА СОВМЕСТИМОСТИ =================================  

//            if (!device.IsCapable(CAPS.SOFT_GATHERING_IS_AVAILABLE)) throw new Exception("No Soft gathering is available"); //return SayGoodBye(st);

//            //========================== ИНИЦИАЛИЗАЦИЯ =====================================        

//            st = device.Connect((uint)index); // Подключаемся к плате. Нумерация плат начинается с 1.
//            if (st != API.SUCCESS) return st;//return SayGoodBye(st);

//            /*
//            Для подключения к плате по серийному номеру.
//            uint serialNumber = 11111;
//            st = device.Connect(serialNumber, RSH_CONNECT_MODE.SERIAL_NUMBER); // Подключаемся к плате по серийному номеру платы.
//            if (st != RSH_API.SUCCESS) return SayGoodBye(st);
//            */

//            return st;
//        }

//        public API Init(int chanNumber, double frequency, int bufferSize)
//        {
//            API st;
            
//            if (device.IsCapable(CAPS.SOFT_INIT_DMA))
//            {
//                InitDMA p = new InitDMA(); // Структура для инициализации параметров работы платы.  
//                p.startType = (uint)InitDMA.StartTypeBit.Program; // Запуск платы по внутреннему таймеру. 
//                p.bufferSize = (uint)bufferSize; // Размер внутреннего блока данных, по готовности которого произойдёт прерывание.
//                p.frequency = frequency; // Частота дискретизации.

//                foreach (Channel ch in p.channels)
//                {
//                    ch.control = (uint)Channel.ControlBit.Used; // Сделаем 0-ой канал активным.
//                    ch.gain = 1; // Зададим коэффициент усиления для 0-го канала.

//                    if (--chanNumber == 0) break;
//                }

//                return device.Init(p);
//            }


//            // Проверим, поддерживается ли структура DMA.
//            if (device.IsCapable(CAPS.SOFT_INIT_MEMORY))
//            {
//                InitMemory p = new InitMemory(); // Структура для инициализации параметров работы платы.  
//                p.startType = (uint)InitMemory.StartTypeBit.Program; // Запуск платы по внутреннему таймеру. 
//                p.bufferSize = (uint)bufferSize; // Размер внутреннего блока данных, по готовности которого произойдёт прерывание.
//                p.frequency = frequency; // Частота дискретизации.

//                foreach (Channel ch in p.channels)
//                {
//                    ch.control = (uint)Channel.ControlBit.Used; // Сделаем 0-ой канал активным.
//                    ch.gain = 1; // Зададим коэффициент усиления для 0-го канала.

//                    if (--chanNumber == 0) break;
//                }

//                return device.Init(p);
//            }

//            return API.PARAMETER_NOTSUPPORTED;
//        }

//        public API GetData(ref short[] buffer)
//        {
//            API st;
//            st = device.Start(); // Запускаем плату на сбор буфера.
//            if (st != API.SUCCESS) return st;//SayGoodBye(st);

//            //Console.WriteLine("\n--> Collecting buffer...\n", BOARD_NAME);
//            uint waitTime = 100000; // Время ожидания(в миллисекундах) до наступления прерывания. Прерывание произойдет при полном заполнении буфера. 

//            /*if ((st = device.Get(GET.WAIT_BUFFER_READY_EVENT, ref waitTime)) == API.SUCCESS)	// Ожидаем готовность буфера.
//            {
//                Console.WriteLine("\nInterrupt has taken place!\nWhich means that onboard buffer had filled completely.");

//                device.Stop();
//            }
//            */
//            st = device.GetData(buffer);
//            return st;
//        }

//        public API GetVoltage(ref double[] buffer)
//        {
//            API st;
//            st = device.Start(); // Запускаем плату на сбор буфера.
//            if (st != API.SUCCESS) return st;//SayGoodBye(st);

//            //Console.WriteLine("\n--> Collecting buffer...\n", BOARD_NAME);
//            uint waitTime = 100000; // Время ожидания(в миллисекундах) до наступления прерывания. Прерывание произойдет при полном заполнении буфера. 

//            /*if ((st = device.Get(GET.WAIT_BUFFER_READY_EVENT, ref waitTime)) == API.SUCCESS)	// Ожидаем готовность буфера.
//            {
//                Console.WriteLine("\nInterrupt has taken place!\nWhich means that onboard buffer had filled completely.");

//                device.Stop();
//            }*/

//            st = device.GetData(buffer);
//            return st;
//        }

//        public API GetErrorDescription(API errorCode, out string value, LANGUAGE language)
//        {
//            return Device.RshGetErrorDescription(errorCode, out value, language);
//        }

//        public API GetRegisteredDeviceName(int index, out string value)
//        {
//            return Device.RshGetRegisteredDeviceName((uint)index, out value);
//        }

//    };
//}
