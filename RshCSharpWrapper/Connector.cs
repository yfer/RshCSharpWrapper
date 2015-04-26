using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using RshCSharpWrapper.Device;
using RshCSharpWrapper.Types;
using InitDAC = RshCSharpWrapper.Types.InitDAC;
using InitDMA = RshCSharpWrapper.Types.InitDMA;
using InitGSPF = RshCSharpWrapper.Types.InitGSPF;
using InitMemory = RshCSharpWrapper.Types.InitMemory;
using InitPort = RshCSharpWrapper.Types.InitPort;
using InitVoltmeter = RshCSharpWrapper.Types.InitVoltmeter;

namespace RshCSharpWrapper
{    
    /// <summary>
    /// RshUniDriver native calls
    /// </summary>
    internal static class Connector
    {
        private static API ToAPI(this uint operationResult)
        {
            const uint MASK_RSH_ERROR = 0xffff0000;

            return (API)(operationResult & MASK_RSH_ERROR);;
        }

        public static void ThrowIfNotSuccess(this API api)
        {
            if ( api != API.SUCCESS )
                throw new RshDeviceException(api);
        }

        /// <summary>
        /// Read string data from driver;
        /// </summary>
        /// <typeparam name="T">String Type(U16P)</typeparam>
        /// <param name="func">RSH func to run, accepting IntPtr with allocated datatype</param>
        /// <returns></returns>
        private static string GetStringFromDriver<T>(Func<IntPtr, uint> func) where T : IReturn, IString, new()
        {
            var tmp = new T();
            IntPtr unmanagedAddr = Marshal.AllocHGlobal(Marshal.SizeOf(tmp));
            Marshal.StructureToPtr(tmp, unmanagedAddr, true);
            var api = func(unmanagedAddr).ToAPI();
            tmp = (T)Marshal.PtrToStructure(unmanagedAddr, typeof(T));
            Marshal.FreeHGlobal(unmanagedAddr);
            unmanagedAddr = IntPtr.Zero;

            return api == API.SUCCESS ? tmp.ReturnValue() : "";
        }

        #region IRSHDevice functions

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern uint UniDriverFreeBuffer(IntPtr uRshBuffer);

        /// <summary>
        /// Free pre-allocated buffer
        /// </summary>
        /// <param name="uRshBuffer"></param>
        /// <returns></returns>
        public static API FreeBuffer(IntPtr uRshBuffer)
        {
            return UniDriverFreeBuffer(uRshBuffer).ToAPI();
        }

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern uint UniDriverAllocateBuffer(IntPtr uRshBuffer, uint desiredBufferSize);

        /// <summary>
        /// Allocate buffer
        /// </summary>
        /// <param name="uRshBuffer"></param>
        /// <param name="desiredBufferSize"></param>
        /// <returns></returns>
        public static API AllocateBuffer(IntPtr uRshBuffer, uint desiredBufferSize)
        {
            return UniDriverAllocateBuffer(uRshBuffer, desiredBufferSize).ToAPI();
        }

        /// <summary>
        /// Выполняет подключение к драйверу устройства
        /// </summary>
        /// <param name="deviceName">Имя устройства</param>
        /// <param name="deviceHandle">Дескриптор устройства</param>
        /// <returns>Статус выполнения функции</returns>
        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern uint UniDriverGetDeviceHandle(string deviceName, out IntPtr deviceHandle);

        public static API GetDeviceHandle(string deviceName, out DeviceHandle deviceHandle)
        {
            IntPtr handle;
            var api = UniDriverGetDeviceHandle(deviceName, out handle).ToAPI();
            deviceHandle = handle;
            return api;
        }

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern uint UniDriverConnect(IntPtr deviceHandle, uint deviceIndex, uint mode);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="id">Базовый адрес или серийный номер, выбирается режимом во втором параметре.</param>
        /// <param name="mode">Режим подключения, по базовому адресу(по умолчанию) или по серийному номеру.</param>
        /// <returns></returns>
        public static API Connect(DeviceHandle handle, uint id = 1, CONNECT_MODE mode = CONNECT_MODE.BASE)
        {
            handle.ThrowIfDeviceHandleNotOK();
            return UniDriverConnect(handle, id, (uint)mode).ToAPI();
        }

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern uint UniDriverStart(IntPtr deviceHandle);

        public static API Start(DeviceHandle handle)
        {
            handle.ThrowIfDeviceHandleNotOK();
            return UniDriverStart(handle).ToAPI();
        }

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern uint UniDriverStop(IntPtr deviceHandle);

        internal class DeviceHandle
        {
            internal IntPtr Handle;

            public void ThrowIfDeviceHandleNotOK()
            {
                if (Handle == IntPtr.Zero)
                    throw new RshDeviceException(API.DEVICE_DLLWASNOTLOADED);
            }

            public static implicit operator IntPtr(DeviceHandle handle)
            {
                return handle.Handle;
            }

            public static implicit operator DeviceHandle(IntPtr handle)
            {
                return new DeviceHandle{Handle = handle};
            }
        }
        public static API Stop(DeviceHandle handle)
        {
            handle.ThrowIfDeviceHandleNotOK();
            return UniDriverStop(handle).ToAPI();
        }

        #region Init

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverInit(IntPtr deviceHandle, uint initializationMode, ref InitDMA initStructure);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverInit(IntPtr deviceHandle, uint initializationMode, ref InitMemory initStructure);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverInit(IntPtr deviceHandle, uint initializationMode, IntPtr initStructure);


        public static API Init(DeviceHandle handle, INIT_MODE initializationMode, IntPtr initStructure)
        {
            return UniDriverInit(handle, (uint)initializationMode, initStructure).ToAPI();
        }

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverInit(IntPtr deviceHandle, uint initializationMode, ref InitGSPF initStructure);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverInit(IntPtr deviceHandle, uint initializationMode, ref InitVoltmeter initStructure);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverInit(IntPtr deviceHandle, uint initializationMode, ref InitPort initStructure);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverInit(IntPtr deviceHandle, uint initializationMode, ref InitDAC initStructure);

        #endregion

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern uint UniDriverGet(IntPtr deviceHandle, uint getMode, IntPtr value);

        public static API Get(DeviceHandle handle, GET mode, IntPtr value)
        {
            return UniDriverGet(handle, (uint) mode, value).ToAPI();
        }

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverGetData(IntPtr deviceHandle, uint getMode, IntPtr value);

        public static API GetData(DeviceHandle handle, DATA_MODE mode, IntPtr value)
        {
            return UniDriverGetData(handle, (uint) mode, value).ToAPI();
        }

        #region GetData

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverGetData(IntPtr deviceHandle, uint getDataMode, ref BufferU8 uRshBuffer);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverGetData(IntPtr deviceHandle, uint getDataMode, ref BufferS8 uRshBuffer);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverGetData(IntPtr deviceHandle, uint getDataMode, ref BufferU16 uRshBuffer);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverGetData(IntPtr deviceHandle, uint getDataMode, ref BufferS16 uRshBuffer);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverGetData(IntPtr deviceHandle, uint getDataMode, ref BufferU32 uRshBuffer);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverGetData(IntPtr deviceHandle, uint getDataMode, ref BufferS32 uRshBuffer);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverGetData(IntPtr deviceHandle, uint getDataMode, ref BufferU64 uRshBuffer);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverGetData(IntPtr deviceHandle, uint getDataMode, ref BufferS64 uRshBuffer);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverGetData(IntPtr deviceHandle, uint getDataMode, ref BufferDouble uRshBuffer);

        #endregion

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern uint UniDriverGetError(uint errorCode, IntPtr value, uint language);

        public static string GetError(API errorCode)
        {
            var language = LANGUAGE.ENGLISH;
            var ci = Thread.CurrentThread.CurrentCulture;
            if (ci.ThreeLetterISOLanguageName == "rus")
                language = LANGUAGE.RUSSIAN;
            return GetStringFromDriver<U16P>(intPtr => UniDriverGetError((uint)errorCode, intPtr, (uint)language));
        }

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern uint UniDriverGetRegisteredDeviceName(uint index, IntPtr ptr);

        /// <summary>
        /// Get list of registered devices.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<string> GetRegisteredDeviceNames()
        {            
            for(uint i = 0 ;; i++)
            {
                var str = GetStringFromDriver<U16P>(intPtr => UniDriverGetRegisteredDeviceName(i, intPtr));
                if(str!=string.Empty)
                    yield return str;
                else
                    yield break;
            }             
        }


        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern uint UniDriverCloseDeviceHandle(IntPtr deviceHandle);

        public static API CloseDeviceHandle(DeviceHandle handle)
        {
            handle.ThrowIfDeviceHandleNotOK();
            return UniDriverCloseDeviceHandle(handle).ToAPI();
        }

        #endregion
    }
}
