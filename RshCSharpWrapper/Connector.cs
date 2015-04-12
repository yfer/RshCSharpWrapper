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

        private static void CheckIfDeviceHandleOk(this IntPtr deviceHandle)
        {
            if (deviceHandle == IntPtr.Zero)
                throw new RshDeviceException(API.DEVICE_DLLWASNOTLOADED);
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

        #region Allocate & Free memory
        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern uint UniDriverFreeBuffer(IntPtr uRshBuffer);

        public static API FreeBuffer(IntPtr uRshBuffer)
        {
            return UniDriverFreeBuffer(uRshBuffer).ToAPI();
        }

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern uint UniDriverAllocateBuffer(IntPtr uRshBuffer, uint desiredBufferSize);

        public static API AllocateBuffer(IntPtr uRshBuffer, uint desiredBufferSize)
        {
            return UniDriverAllocateBuffer(uRshBuffer, desiredBufferSize).ToAPI();
        }

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverFreeBuffer(ref BufferS8 uRshBuffer);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverAllocateBuffer(ref BufferS8 uRshBuffer, uint desiredBufferSize);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverFreeBuffer(ref BufferS16 uRshBuffer);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverAllocateBuffer(ref BufferS16 uRshBuffer, uint desiredBufferSize);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverFreeBuffer(ref BufferS32 uRshBuffer);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverAllocateBuffer(ref BufferS32 uRshBuffer, uint desiredBufferSize);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverFreeBuffer(ref BufferS64 uRshBuffer);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverAllocateBuffer(ref BufferS64 uRshBuffer, uint desiredBufferSize);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverFreeBuffer(ref BufferU8 uRshBuffer);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverAllocateBuffer(ref BufferU8 uRshBuffer, uint desiredBufferSize);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverFreeBuffer(ref BufferU16 uRshBuffer);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverAllocateBuffer(ref BufferU16 uRshBuffer, uint desiredBufferSize);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverFreeBuffer(ref BufferU32 uRshBuffer);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverAllocateBuffer(ref BufferU32 uRshBuffer, uint desiredBufferSize);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverFreeBuffer(ref BufferU64 uRshBuffer);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverAllocateBuffer(ref BufferU64 uRshBuffer, uint desiredBufferSize);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverFreeBuffer(ref BufferDouble uRshBuffer);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverAllocateBuffer(ref BufferDouble uRshBuffer, uint desiredBufferSize);
        #endregion
        /// <summary>
        /// Выполняет подключение к драйверу устройства
        /// </summary>
        /// <param name="deviceName">Имя устройства</param>
        /// <param name="deviceHandle">Дескриптор устройства</param>
        /// <returns>Статус выполнения функции</returns>
        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern uint UniDriverGetDeviceHandle(string deviceName, out IntPtr deviceHandle);

        public static API GetDeviceHandle(string deviceName, out IntPtr deviceHandle)
        {
            return UniDriverGetDeviceHandle(deviceName, out deviceHandle).ToAPI();
        }

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern uint UniDriverConnect(IntPtr deviceHandle, uint deviceIndex, uint mode);

        public static API Connect(IntPtr deviceHandle, uint deviceIndex, uint mode)
        {
            deviceHandle.CheckIfDeviceHandleOk();            
            return UniDriverConnect(deviceHandle, deviceIndex, mode).ToAPI();
        }

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern uint UniDriverStart(IntPtr deviceHandle);

        public static API Start(IntPtr deviceHandle)
        {
            deviceHandle.CheckIfDeviceHandleOk();
            return UniDriverStart(deviceHandle).ToAPI();
        }

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern uint UniDriverStop(IntPtr deviceHandle);

        public static API Stop(IntPtr deviceHandle)
        {
            deviceHandle.CheckIfDeviceHandleOk();
            return UniDriverStop(deviceHandle).ToAPI();
        }

        #region Init

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverInit(IntPtr deviceHandle, uint initializationMode, ref InitDMA initStructure);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverInit(IntPtr deviceHandle, uint initializationMode, ref InitMemory initStructure);

        public static API Init(IntPtr deviceHandle, uint initializationMode, ref InitMemory initStructure)
        {
            return UniDriverInit(deviceHandle, initializationMode, ref initStructure).ToAPI();
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

        public static API Get(IntPtr deviceHandle, GET mode, IntPtr value)
        {
            return UniDriverGet(deviceHandle, (uint) mode, value).ToAPI();
        }

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverGetData(IntPtr deviceHandle, uint getMode, IntPtr value);


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

        public static API CloseDeviceHandle(IntPtr deviceHandle)
        {
            deviceHandle.CheckIfDeviceHandleOk();
            return UniDriverCloseDeviceHandle(deviceHandle).ToAPI();
        }

        #endregion
    }
}
