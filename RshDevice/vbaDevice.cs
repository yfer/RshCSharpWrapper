using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RshCSharpWrapper.RshDevice
{
    [System.Runtime.InteropServices.ClassInterface(System.Runtime.InteropServices.ClassInterfaceType.AutoDual)]
    public class vbaDevice
    {
        RshDevice.Device device = new Device();

        public RSH_API Connect(string name, int index)
        {
            RSH_API st;

            device.EstablishDriverConnection(name);
            /*
            //=================== ИНФОРМАЦИЯ О ЗАГРУЖЕННОЙ БИБЛИОТЕКЕ ====================== 
            string libVersion, libname, libCoreVersion, libCoreName;

            st = device.Get(RSH_GET.LIBRARY_VERSION_STR, out libVersion);
            if (st != RSH_API.SUCCESS) return st;//return SayGoodBye(st);

            st = device.Get(RSH_GET.CORELIB_VERSION_STR, out libCoreVersion);
            st = device.Get(RSH_GET.CORELIB_FILENAME, out libCoreName);
            st = device.Get(RSH_GET.LIBRARY_FILENAME, out libname);

            Console.WriteLine("Library Name: {0:d}", libname);
            Console.WriteLine("Library Version: {0:d}", libVersion);
            Console.WriteLine("\nCore Library Name: {0:d}", libCoreName);
            Console.WriteLine("Core Library Version: {0:d}", libCoreVersion);
            */
            //===================== ПРОВЕРКА СОВМЕСТИМОСТИ =================================  

            uint caps = (uint)RSH_CAPS.SOFT_GATHERING_IS_AVAILABLE;
            st = device.Get(RSH_GET.DEVICE_IS_CAPABLE, ref caps); // Проверим, поддерживает ли плата функцию сбора данных сигнала.
            if (st != RSH_API.SUCCESS) return st;//return SayGoodBye(st);

            //========================== ИНИЦИАЛИЗАЦИЯ =====================================        

            st = device.Connect((uint)index); // Подключаемся к плате. Нумерация плат начинается с 1.
            if (st != RSH_API.SUCCESS) return st;//return SayGoodBye(st);

            /*
            Для подключения к плате по серийному номеру.
            uint serialNumber = 11111;
            st = device.Connect(serialNumber, RSH_CONNECT_MODE.SERIAL_NUMBER); // Подключаемся к плате по серийному номеру платы.
            if (st != RSH_API.SUCCESS) return SayGoodBye(st);
            */

            return st;
        }

        public RSH_API Init(int chanNumber, double frequency, int bufferSize)
        {
            RSH_API st;

            uint caps = (uint)RSH_CAPS.SOFT_INIT_DMA;
            st = device.Get(RSH_GET.DEVICE_IS_CAPABLE, ref caps); // Проверим, поддерживается ли структура DMA.
            if (st == RSH_API.SUCCESS)
            {
                RshInitDMA p = new RshInitDMA(); // Структура для инициализации параметров работы платы.  
                p.startType = (uint)RshInitDMA.StartTypeBit.Program; // Запуск платы по внутреннему таймеру. 
                p.bufferSize = (uint)bufferSize; // Размер внутреннего блока данных, по готовности которого произойдёт прерывание.
                p.frequency = frequency; // Частота дискретизации.

                foreach (RshChannel ch in p.channels)
                {
                    ch.control = (uint)RshChannel.ControlBit.Used; // Сделаем 0-ой канал активным.
                    ch.gain = 1; // Зададим коэффициент усиления для 0-го канала.

                    if (--chanNumber == 0) break;
                }

                return device.Init(p);
            }


            caps = (uint)RSH_CAPS.SOFT_INIT_MEMORY;
            st = device.Get(RSH_GET.DEVICE_IS_CAPABLE, ref caps); // Проверим, поддерживается ли структура DMA.
            if (st == RSH_API.SUCCESS)
            {
                RshInitMemory p = new RshInitMemory(); // Структура для инициализации параметров работы платы.  
                p.startType = (uint)RshInitMemory.StartTypeBit.Program; // Запуск платы по внутреннему таймеру. 
                p.bufferSize = (uint)bufferSize; // Размер внутреннего блока данных, по готовности которого произойдёт прерывание.
                p.frequency = frequency; // Частота дискретизации.

                foreach (RshChannel ch in p.channels)
                {
                    ch.control = (uint)RshChannel.ControlBit.Used; // Сделаем 0-ой канал активным.
                    ch.gain = 1; // Зададим коэффициент усиления для 0-го канала.

                    if (--chanNumber == 0) break;
                }

                return device.Init(p);
            }

            return RSH_API.PARAMETER_NOTSUPPORTED;
        }

        public RSH_API GetData(ref short[] buffer)
        {
            RSH_API st;
            st = device.Start(); // Запускаем плату на сбор буфера.
            if (st != RSH_API.SUCCESS) return st;//SayGoodBye(st);

            //Console.WriteLine("\n--> Collecting buffer...\n", BOARD_NAME);
            uint waitTime = 100000; // Время ожидания(в миллисекундах) до наступления прерывания. Прерывание произойдет при полном заполнении буфера. 

            if ((st = device.Get(RSH_GET.WAIT_BUFFER_READY_EVENT, ref waitTime)) == RSH_API.SUCCESS)	// Ожидаем готовность буфера.
            {
                Console.WriteLine("\nInterrupt has taken place!\nWhich means that onboard buffer had filled completely.");

                device.Stop();
            }

            st = device.GetData(buffer);
            return st;
        }

        public RSH_API GetVoltage(ref double[] buffer)
        {
            RSH_API st;
            st = device.Start(); // Запускаем плату на сбор буфера.
            if (st != RSH_API.SUCCESS) return st;//SayGoodBye(st);

            //Console.WriteLine("\n--> Collecting buffer...\n", BOARD_NAME);
            uint waitTime = 100000; // Время ожидания(в миллисекундах) до наступления прерывания. Прерывание произойдет при полном заполнении буфера. 

            if ((st = device.Get(RSH_GET.WAIT_BUFFER_READY_EVENT, ref waitTime)) == RSH_API.SUCCESS)	// Ожидаем готовность буфера.
            {
                Console.WriteLine("\nInterrupt has taken place!\nWhich means that onboard buffer had filled completely.");

                device.Stop();
            }

            st = device.GetData(buffer);
            return st;
        }

        public RSH_API GetErrorDescription(RSH_API errorCode, out string value, RSH_LANGUAGE language)
        {
            return Device.RshGetErrorDescription(errorCode, out value, language);
        }

        public RSH_API GetRegisteredDeviceName(int index, out string value)
        {
            return Device.RshGetRegisteredDeviceName((uint)index, out value);
        }

    };
}
