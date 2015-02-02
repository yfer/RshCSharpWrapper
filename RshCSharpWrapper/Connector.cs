using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;
using RshCSharpWrapper.Device;
using RshCSharpWrapper.Types;

namespace RshCSharpWrapper
{
    /// <summary>
    /// RshUniDriver native calls
    /// </summary>
    internal class Connector
    {        
        private static API ToAPI(uint operationResult)
        {
            const uint MASK_RSH_ERROR = 0xffff0000;

            return (API)(operationResult & MASK_RSH_ERROR);;
        }

        #region IRSHDevice functions

        #region Allocate & Free memory
        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverFreeBuffer(IntPtr uRshBuffer);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern uint UniDriverAllocateBuffer(IntPtr uRshBuffer, uint desiredBufferSize);

        public static API AllocateBuffer(IntPtr uRshBuffer, uint desiredBufferSize)
        {
            return ToAPI(UniDriverAllocateBuffer(uRshBuffer, desiredBufferSize));
        }

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverFreeBuffer(ref Types.BufferS8 uRshBuffer);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverAllocateBuffer(ref Types.BufferS8 uRshBuffer, uint desiredBufferSize);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverFreeBuffer(ref Types.BufferS16 uRshBuffer);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverAllocateBuffer(ref Types.BufferS16 uRshBuffer, uint desiredBufferSize);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverFreeBuffer(ref Types.BufferS32 uRshBuffer);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverAllocateBuffer(ref Types.BufferS32 uRshBuffer, uint desiredBufferSize);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverFreeBuffer(ref Types.BufferS64 uRshBuffer);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverAllocateBuffer(ref Types.BufferS64 uRshBuffer, uint desiredBufferSize);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverFreeBuffer(ref Types.BufferU8 uRshBuffer);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverAllocateBuffer(ref Types.BufferU8 uRshBuffer, uint desiredBufferSize);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverFreeBuffer(ref Types.BufferU16 uRshBuffer);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverAllocateBuffer(ref Types.BufferU16 uRshBuffer, uint desiredBufferSize);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverFreeBuffer(ref Types.BufferU32 uRshBuffer);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverAllocateBuffer(ref Types.BufferU32 uRshBuffer, uint desiredBufferSize);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverFreeBuffer(ref Types.BufferU64 uRshBuffer);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverAllocateBuffer(ref Types.BufferU64 uRshBuffer, uint desiredBufferSize);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverFreeBuffer(ref Types.BufferDouble uRshBuffer);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverAllocateBuffer(ref Types.BufferDouble uRshBuffer, uint desiredBufferSize);
        #endregion
        /// <summary>
        /// Выполняет подключение к драйверу устройства
        /// </summary>
        /// <param name="deviceName">Имя устройства</param>
        /// <param name="deviceHandle">Дескриптор устройства</param>
        /// <returns>Статус выполнения функции</returns>
        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern uint UniDriverGetDeviceHandle(string deviceName, out IntPtr deviceHandle);

        public static void GetDeviceHandle(string deviceName, out IntPtr deviceHandle)
        {
            try
            {
                var res = ToAPI(UniDriverGetDeviceHandle(deviceName, out deviceHandle));
                if( res != API.SUCCESS )
                    throw new RshDeviceException(res);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Unable to load DLL"))
                    throw new RshDeviceException(API.UNIDRIVER_DLLWASNOTLOADED);
                throw;
            }
        }

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern uint UniDriverConnect(IntPtr deviceHandle, uint deviceIndex, uint mode);

        public static void Connect(IntPtr deviceHandle, uint deviceIndex, uint mode)
        {
            if (deviceHandle == IntPtr.Zero)
                throw new RshDeviceException(API.DEVICE_DLLWASNOTLOADED);
            try
            {
                var api = ToAPI(UniDriverConnect(deviceHandle, deviceIndex, mode));
                if( api != API.SUCCESS )
                    throw new RshDeviceException(api);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Unable to load DLL"))
                    throw new RshDeviceException(API.UNIDRIVER_DLLWASNOTLOADED);
                throw;
            }
        }

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern uint UniDriverStart(IntPtr deviceHandle);

        public static void Start(IntPtr deviceHandle)
        {
            if (deviceHandle == IntPtr.Zero)
                throw new RshDeviceException(API.DEVICE_DLLWASNOTLOADED);
            try
            {
                var api = ToAPI( UniDriverStart(deviceHandle) );
                if(api != API.SUCCESS)
                    throw new RshDeviceException(api);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Unable to load DLL"))
                    throw new RshDeviceException(API.UNIDRIVER_DLLWASNOTLOADED);
                throw;
            }
        }

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern uint UniDriverStop(IntPtr deviceHandle);

        public static void Stop(IntPtr deviceHandle)
        {
            if (deviceHandle == IntPtr.Zero)
                throw new RshDeviceException(API.DEVICE_DLLWASNOTLOADED);
            try 
            { 
                var api = ToAPI(UniDriverStop(deviceHandle));
                if (api != API.SUCCESS)
                    throw new RshDeviceException(api);
            }
            catch(Exception ex)
            {
                if (ex.Message.Contains("Unable to load DLL"))
                    throw new RshDeviceException(API.UNIDRIVER_DLLWASNOTLOADED);
                throw;
            }
        }

        #region Init

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverInit(IntPtr deviceHandle, uint initializationMode, ref Types.InitDMA initStructure);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverInit(IntPtr deviceHandle, uint initializationMode, ref Types.InitMemory initStructure);

        public static API Init(IntPtr deviceHandle, uint initializationMode, ref Types.InitMemory initStructure)
        {
            return ToAPI(UniDriverInit(deviceHandle, initializationMode, ref initStructure));
        }

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverInit(IntPtr deviceHandle, uint initializationMode, ref Types.InitGSPF initStructure);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverInit(IntPtr deviceHandle, uint initializationMode, ref Types.InitVoltmeter initStructure);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverInit(IntPtr deviceHandle, uint initializationMode, ref Types.InitPort initStructure);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverInit(IntPtr deviceHandle, uint initializationMode, ref Types.InitDAC initStructure);

        #endregion

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern uint UniDriverGet(IntPtr deviceHandle, uint getMode, IntPtr value);

        public static API Get(IntPtr deviceHandle, GET mode, IntPtr value)
        {
            return ToAPI(UniDriverGet(deviceHandle, (uint) mode, value));
        }

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverGetData(IntPtr deviceHandle, uint getMode, IntPtr value);


        #region GetData

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverGetData(IntPtr deviceHandle, uint getDataMode, ref Types.BufferU8 uRshBuffer);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverGetData(IntPtr deviceHandle, uint getDataMode, ref Types.BufferS8 uRshBuffer);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverGetData(IntPtr deviceHandle, uint getDataMode, ref Types.BufferU16 uRshBuffer);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverGetData(IntPtr deviceHandle, uint getDataMode, ref Types.BufferS16 uRshBuffer);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverGetData(IntPtr deviceHandle, uint getDataMode, ref Types.BufferU32 uRshBuffer);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverGetData(IntPtr deviceHandle, uint getDataMode, ref Types.BufferS32 uRshBuffer);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverGetData(IntPtr deviceHandle, uint getDataMode, ref Types.BufferU64 uRshBuffer);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverGetData(IntPtr deviceHandle, uint getDataMode, ref Types.BufferS64 uRshBuffer);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverGetData(IntPtr deviceHandle, uint getDataMode, ref Types.BufferDouble uRshBuffer);

        #endregion

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern uint UniDriverGetError(uint errorCode, IntPtr value, uint language);

        public static string GetError(API errorCode, LANGUAGE language)
        {
            try
            {
                var tmp = new U16P();
                IntPtr unmanagedAddr = Marshal.AllocHGlobal(Marshal.SizeOf(tmp));
                Marshal.StructureToPtr(tmp, unmanagedAddr, true);              
                var api = ToAPI(UniDriverGetError((uint) errorCode, unmanagedAddr, (uint) language));
                tmp = (U16P)Marshal.PtrToStructure(unmanagedAddr, typeof(U16P));
                Marshal.FreeHGlobal(unmanagedAddr);
                unmanagedAddr = IntPtr.Zero;

                if (api != API.SUCCESS)
                    throw new RshDeviceException(api);
                return tmp.ReturnValue();                
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Unable to load DLL"))
                    throw new RshDeviceException(API.UNIDRIVER_DLLWASNOTLOADED);
                throw;
            }
           
        }

        public static string GetError(API errorCode)
        {
            var language = LANGUAGE.ENGLISH;
            var ci = Thread.CurrentThread.CurrentCulture;
            if (ci.ThreeLetterISOLanguageName == "rus")
                language = LANGUAGE.RUSSIAN;
            return GetError(errorCode, language);
        }

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern uint UniDriverGetRegisteredDeviceName(uint index, IntPtr ptr);

        public static string GetRegisteredDeviceName(uint index)
        {
            try
            {
                var tmp = new U16P();
                IntPtr unmanagedAddr = Marshal.AllocHGlobal(Marshal.SizeOf(tmp));
                Marshal.StructureToPtr(tmp, unmanagedAddr, true);              
                var api = ToAPI(UniDriverGetRegisteredDeviceName(index, unmanagedAddr));
                tmp = (U16P)Marshal.PtrToStructure(unmanagedAddr, typeof(U16P));
                Marshal.FreeHGlobal(unmanagedAddr);
                unmanagedAddr = IntPtr.Zero;

                if (api != API.SUCCESS)
                    throw new RshDeviceException(api);
                return tmp.ReturnValue();                
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Unable to load DLL"))
                    throw new RshDeviceException(API.UNIDRIVER_DLLWASNOTLOADED);
                throw;
            }
        }

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern uint UniDriverCloseDeviceHandle(IntPtr deviceHandle);

        public static void CloseDeviceHandle(IntPtr deviceHandle)
        {
            try
            {
                var res = ToAPI(UniDriverCloseDeviceHandle(deviceHandle));
                if (res != API.SUCCESS)
                    throw new RshDeviceException(res);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Unable to load DLL"))
                    throw new RshDeviceException(API.UNIDRIVER_DLLWASNOTLOADED);
                throw;
            }
        }

        #endregion
    }
}
