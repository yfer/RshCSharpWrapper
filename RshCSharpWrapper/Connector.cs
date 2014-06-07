using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace RshCSharpWrapper
{
    /// <summary>
    /// RshUniDriver native calls
    /// </summary>
    internal class Connector
    {
        #region IRSHDevice functions

        #region Allocate & Free memory
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
        public static extern uint UniDriverGetDeviceHandle(string deviceName, out IntPtr deviceHandle);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverConnect(IntPtr deviceHandle, uint deviceIndex, uint mode);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverStart(IntPtr deviceHandle);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverStop(IntPtr deviceHandle);

        #region Init

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverInit(IntPtr deviceHandle, uint initializationMode, ref Types.InitDMA initStructure);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverInit(IntPtr deviceHandle, uint initializationMode, ref Types.InitMemory initStructure);

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
        public static extern uint UniDriverGet(IntPtr deviceHandle, uint getMode, IntPtr value);

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
        public static extern uint UniDriverGetError(uint errorCode, ref Types.U16P value, uint language);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverGetRegisteredDeviceName(uint index, ref Types.U16P value);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverCloseDeviceHandle(IntPtr deviceHandle);

        #endregion
    }
}
