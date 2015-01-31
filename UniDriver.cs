using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace RshCSharpWrapper
{
    #region Types

    namespace Types
    {

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct RshU8
        {
            private Names typeName; // data code
            public byte data;
            public RshU8(byte data)
            {
                typeName = Names.rshU8;
                this.data = data;
            }
        };

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct RshU16
        {
            private Names typeName; // data code
            public UInt16 data;
            public RshU16(UInt16 data)
            {
                typeName = Names.rshU16;
                this.data = data;
            }
        };
     

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct RshU32
        {
            private Names type; // data code
            public UInt32 data;
            public RshU32(UInt32 data)
            {
                type = Names.rshU32;
                this.data = data;
            }
        };

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct RshU64
        {
            private Names type; // data code
            public UInt64 data;
            public RshU64(UInt64 data)
            {
                type = Names.rshU64;
                this.data = data;
            }
        };

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct RshS8
        {
            private Names typeName; // data code
            public sbyte data;
            public RshS8(sbyte data)
            {
                typeName = Names.rshS8;
                this.data = data;
            }
        };

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct RshS16
        {
            private Names typeName; // data code
            public Int16 data;
            public RshS16(Int16 data)
            {
                typeName = Names.rshS16;
                this.data = data;
            }
        };


        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct RshS32
        {
            private Names type; // data code
            public Int32 data;
            public RshS32(Int32 data)
            {
                type = Names.rshS32;
                this.data = data;
            }
        };

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct RshS64
        {
            private Names type; // data code
            public Int64 data;
            public RshS64(Int64 data)
            {
                type = Names.rshS64;
                this.data = data;
            }
        };

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct RshDouble
        {
            private Names type; // data code
            public Double data;
            public RshDouble(Double data)
            {
                type = Names.rshDouble;
                this.data = data;
            }
        };

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct RshU8P
        {
            private Names type; // data code
            public IntPtr data;
            public RshU8P(Int32 data)
            {
                type = Names.rshU8P;
                this.data = IntPtr.Zero;
            }
        };

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct RshU16P
        {
            private Names type; // data code
            public IntPtr data;
            public RshU16P(Int32 data)
            {
                type = Names.rshU16P;
                this.data = IntPtr.Zero;
            }
        };

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct RshS8P
        {
            private Names type; // data code
            public IntPtr data;
            public RshS8P(Int32 data)
            {
                type = Names.rshS8P;
                this.data = IntPtr.Zero;
            }
        };

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct RshS16P
        {
            private Names type; // data code
            public IntPtr data;
            public RshS16P(Int32 data)
            {
                type = Names.rshS16P;
                this.data = IntPtr.Zero;
            }
        };

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct RshBufferU32
        {
            private Names typeName;  //!< тип данных буфера
            public uint size;  //!< данное поле используется после вызова UniDriverGetData(), чтобы отразить реальное количество скопированных данных в буфер
            public uint psize; //!< количество элементов в буфере
            private uint id; // кникальный идентификатор буфера (служебное поле)
            public IntPtr ptr;   //!< указатель на буфер

            public RshBufferU32(uint size)
            {
                typeName = Names.rshBufferTypeU32;
                this.size = size;
                this.psize = 0;
                this.ptr = IntPtr.Zero;
                this.id = 0;
            }
        };

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct RshBufferS32
        {
            private Names typeName;  //!< тип данных буфера
            public uint size;  //!< данное поле используется после вызова UniDriverGetData(), чтобы отразить реальное количество скопированных данных в буфер
            public uint psize; //!< количество элементов в буфере
            private uint id;
            public IntPtr ptr;   //!< указатель на буфер

            public RshBufferS32(uint size)
            {
                typeName = Names.rshBufferTypeS32;
                this.size = size;
                this.psize = 0;
                this.ptr = IntPtr.Zero;
                this.id = 0;
            }
        };

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct RshBufferU16
        {
            private Names typeName;  //!< тип данных буфера
            public uint size;  //!< данное поле используется после вызова UniDriverGetData(), чтобы отразить реальное количество скопированных данных в буфер
            public uint psize; //!< количество элементов в буфере
            private uint id;
            public IntPtr ptr;   //!< указатель на буфер

            public RshBufferU16(uint size)
            {
                typeName = Names.rshBufferTypeU16;
                this.size = size;
                this.psize = 0;
                this.ptr = IntPtr.Zero;
                this.id = 0;
            }
        };

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct RshBufferS16
        {
            private Names typeName;  //!< тип данных буфера
            public uint size;  //!< данное поле используется после вызова UniDriverGetData(), чтобы отразить реальное количество скопированных данных в буфер
            public uint psize; //!< количество элементов в буфере
            private uint id;
            public IntPtr ptr;   //!< указатель на буфер

            public RshBufferS16(uint size)
            {
                typeName = Names.rshBufferTypeS16;
                this.size = size;
                this.psize = 0;
                this.ptr = IntPtr.Zero;
                this.id = 0;
            }
        };

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct RshBufferU8
        {
            private Names typeName;  //!< тип данных буфера
            public uint size;  //!< данное поле используется после вызова UniDriverGetData(), чтобы отразить реальное количество скопированных данных в буфер
            public uint psize; //!< количество элементов в буфере
            private uint id;
            public IntPtr ptr;   //!< указатель на буфер

            public RshBufferU8(uint size)
            {
                typeName = Names.rshBufferTypeU8;
                this.size = size;
                this.psize = 0;
                this.ptr = IntPtr.Zero;
                this.id = 0;
            }
        };

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct RshBufferS8
        {
            private Names typeName;  //!< тип данных буфера
            public uint size;  //!< данное поле используется после вызова UniDriverGetData(), чтобы отразить реальное количество скопированных данных в буфер
            public uint psize; //!< количество элементов в буфере
            private uint id;
            public IntPtr ptr;   //!< указатель на буфер

            public RshBufferS8(uint size)
            {
                typeName = Names.rshBufferTypeS8;
                this.size = size;
                this.psize = 0;
                this.ptr = IntPtr.Zero;
                this.id = 0;
            }
        };

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct RshBufferU64
        {
            private Names typeName;  //!< тип данных буфера
            public uint size;  //!< данное поле используется после вызова UniDriverGetData(), чтобы отразить реальное количество скопированных данных в буфер
            public uint psize; //!< количество элементов в буфере
            private uint id;
            public IntPtr ptr;   //!< указатель на буфер

            public RshBufferU64(uint size)
            {
                typeName = Names.rshBufferTypeU64;
                this.size = size;
                this.psize = 0;
                this.ptr = IntPtr.Zero;
                this.id = 0;
            }
        };

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct RshBufferS64
        {
            private Names typeName;  //!< тип данных буфера
            public uint size;  //!< данное поле используется после вызова UniDriverGetData(), чтобы отразить реальное количество скопированных данных в буфер
            public uint psize; //!< количество элементов в буфере
            private uint id;
            public IntPtr ptr;   //!< указатель на буфер

            public RshBufferS64(uint size)
            {
                typeName = Names.rshBufferTypeS64;
                this.size = size;
                this.psize = 0;
                this.ptr = IntPtr.Zero;
                this.id = 0;
            }
        };

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct RshBufferDouble
        {
            private Names typeName;  //!< тип данных буфера
            public uint size;  //!< данное поле используется после вызова UniDriverGetData(), чтобы отразить реальное количество скопированных данных в буфер
            public uint psize; //!< количество элементов в буфере
            private uint id;
            public IntPtr ptr;   //!< указатель на буфер

            public RshBufferDouble(uint size)
            {
                typeName = Names.rshBufferTypeDouble;
                this.size = size;
                this.psize = 0;
                this.ptr = IntPtr.Zero;
                this.id = 0;
            }
        };


        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct RshChannel   // настройка канала платы
        {
            public uint gain;		//!< коэффициент усиления
            public uint control;	//!< специфические настройки канала        
            public double delta;		//!< смещениe (в вольтах)
        };

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct RshSynchroChannel   // настройка канала платы
        {
            public uint gain;		//!< коэффициент усиления
            public uint control;	//!< специфические настройки канала        
        };

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct RshPortInfo   
        {
            public uint address;    //!< регистр отвечающий за порт
            public byte bitSize;    //!< разрядность порта 
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public byte[] name;     //!< название порта
            public RshPortInfo(UInt32 st)
            {
                address = 0;
                bitSize = 0;
                name = new byte[32];
            }
        };

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct RshBoardPortInfo   
        {
            private Names typeName;     // data code
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public RshPortInfo[] confs;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public RshPortInfo[] ports;
            public uint totalConfs;
            public uint totalPorts;
            public RshBoardPortInfo(UInt32 st)
            {
                typeName = Names.rshBoardPortInfo;
                confs = new RshPortInfo[32];
                ports = new RshPortInfo[32];
                for (int i = 0; i < 32; i++)
                {
                    confs[i] = new RshPortInfo(0);
                    ports[i] = new RshPortInfo(0);
                }
                totalConfs = 0;
                totalPorts = 0;
            }
        };

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct RshInitDMA
        {
            private Names typeName;     // data code				URshInitMemoryType

            public uint startType;	// !< настройки типа старта платы
            public uint bufferSize;	// !< размер буфера в отсчётах (значение пересчитывается при инициализации в зависимости от сопутствующих настроек)
            public double frequency;	// !< частота дискретизации	

            public uint dmaMode;    //!< режим работы DMA	

            public uint control;	//!< специфические настройки для данного типа плат (например, диф режим)
            public double frequencyPack;		// !< частота дискретизации	внутри пачки
            
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public RshChannel[] channels; // параметры каналов

            public double threshold;		//!< уровень синхронизации в Вольтах
            public uint controlSynchro;	//!< специфические настройки синхронизации

            public RshInitDMA(UInt32 st)
            {
                typeName = Names.rshInitDMA;
                startType = 0;
                control = bufferSize = dmaMode = 0;
                frequency = frequencyPack = 0;
                threshold = 0.0;
                controlSynchro = 0;
                channels = new RshChannel[32];
            }
        };

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct RshInitMemory
        {
            private Names typeName;     // data code				URshInitMemoryType

            public uint startType;	// !< настройки типа старта платы
            public uint bufferSize;	// !< размер буфера в отсчётах (значение пересчитывается при инициализации в зависимости от сопутствующих настроек)
            public double frequency;	// !< частота дискретизации	

            public uint control;

            public uint beforeHistory;	//!< размер предыстории, может принимать значения от 0 до 15
            public uint startDelay;		//!< задержка старта
            public uint hysteresis;		//!< гистеризис
            public uint packetNumber;	//!< количество пакетов размера bufferSize

            public double threshold;		//!< уровень синхронизации в Вольтах
            public uint controlSynchro;	//!< специфические настройки синхронизации

            public RshSynchroChannel channelSynchro; //<! настройки канала внешней синхронизации
            
             [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public RshChannel[] channels; // параметры каналов

            public RshInitMemory(UInt32 st)
            {
                typeName = Names.rshInitMemory;
                startType = 0;
                control = bufferSize = controlSynchro = 0;
                frequency = threshold = 0;
                beforeHistory = startDelay = startDelay = hysteresis = packetNumber = 0;
                channelSynchro = new RshSynchroChannel();
                channels = new RshChannel[32];
            }
        };


        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct RshInitGSPF
        {
            private Names typeName;     // data code				URshInitMemoryType

            public uint startType;	//!< тип запуска платы
            public double frequency;	//!< частота 
            public uint attenuator;		//!<
            public uint control;	//!< настройки платы
            public RshInitGSPF(UInt32 st)
            {
                typeName = Names.rshInitGSPF;
                startType = 0;	//!< тип запуска платы
                control =  attenuator = 0;
                frequency = 0;
            }
        } ;

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct RshInitVoltmeter
        {
            private Names typeName;     // data code				URshInitMemoryType

            public uint startType;	//!< тип запуска
            public uint bufferSize;	// !< размер буфера в отсчётах (значение пересчитывается при инициализации в зависимости от сопутствующих настроек)
            public uint filter;		//!<
            public uint control;	//!< настройки платы
            public RshInitVoltmeter(UInt32 st)
            {
                typeName = Names.rshInitVoltmeter;
                startType = 0;	//!< тип запуска
                bufferSize = filter = control = 0;
            }
        };

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct RshInitPort
        {
            private Names typeName;     // data code				URshInitMemoryType

            public uint operationType;  //!< Read, Write, Mask with And, OR
            public uint portAddress;   //!< port number
            public uint portValue;     //!< port value

            public RshInitPort(UInt32 ot)
            {
                typeName = Names.rshInitPort;
                operationType = portAddress = portValue = 0;
            }
        };

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct RshRegisterInternal
        {
            private Names typeName;

            public uint size;
            public uint offset;
            public uint value;

            public RshRegisterInternal(UInt32 ot)
            {
                typeName = Names.rshRegister;
                size = 1;
                offset = 0;
                value = 0;
            }
        };

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct RshInitDAC
        {
            private Names typeName;     // data code				URshInitDAC

            public uint id;  //!< Идентификатор ЦАПа
            public double voltage;   //!< Напряжение, которое нужно выдать на ЦАП

            public RshInitDAC(UInt32 ot)
            {
                typeName = Names.rshInitDAC;
                id = 0;
                voltage = 0;
            }
        };


    }
    


    #endregion

    internal class Connector
    {


        #region IRSHDevice functions

        #region Allocate & Free memory
        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverFreeBuffer(ref Types.RshBufferS8 uRshBuffer);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverAllocateBuffer(ref Types.RshBufferS8 uRshBuffer, uint desiredBufferSize);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverFreeBuffer(ref Types.RshBufferS16 uRshBuffer);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverAllocateBuffer(ref Types.RshBufferS16 uRshBuffer, uint desiredBufferSize);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverFreeBuffer(ref Types.RshBufferS32 uRshBuffer);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverAllocateBuffer(ref Types.RshBufferS32 uRshBuffer, uint desiredBufferSize);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverFreeBuffer(ref Types.RshBufferS64 uRshBuffer);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverAllocateBuffer(ref Types.RshBufferS64 uRshBuffer, uint desiredBufferSize);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverFreeBuffer(ref Types.RshBufferU8 uRshBuffer);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverAllocateBuffer(ref Types.RshBufferU8 uRshBuffer, uint desiredBufferSize);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverFreeBuffer(ref Types.RshBufferU16 uRshBuffer);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverAllocateBuffer(ref Types.RshBufferU16 uRshBuffer, uint desiredBufferSize);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverFreeBuffer(ref Types.RshBufferU32 uRshBuffer);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverAllocateBuffer(ref Types.RshBufferU32 uRshBuffer, uint desiredBufferSize);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverFreeBuffer(ref Types.RshBufferU64 uRshBuffer);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverAllocateBuffer(ref Types.RshBufferU64 uRshBuffer, uint desiredBufferSize);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverFreeBuffer(ref Types.RshBufferDouble uRshBuffer);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverAllocateBuffer(ref Types.RshBufferDouble uRshBuffer, uint desiredBufferSize);
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
        public static extern uint UniDriverInit(IntPtr deviceHandle, uint initializationMode, ref Types.RshInitDMA initStructure);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverInit(IntPtr deviceHandle, uint initializationMode, ref Types.RshInitMemory initStructure);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverInit(IntPtr deviceHandle, uint initializationMode, ref Types.RshInitGSPF initStructure);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverInit(IntPtr deviceHandle, uint initializationMode, ref Types.RshInitVoltmeter initStructure);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverInit(IntPtr deviceHandle, uint initializationMode, ref Types.RshInitPort initStructure);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverInit(IntPtr deviceHandle, uint initializationMode, ref Types.RshInitDAC initStructure);

        #endregion

        #region Get
        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverGet(IntPtr deviceHandle, uint getMode, ref Types.RshS8 value);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverGet(IntPtr deviceHandle, uint getMode, ref Types.RshU8 value);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverGet(IntPtr deviceHandle, uint getMode, ref Types.RshS16 value);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverGet(IntPtr deviceHandle, uint getMode, ref Types.RshU16 value);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverGet(IntPtr deviceHandle, uint getMode, ref Types.RshS32 value);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverGet(IntPtr deviceHandle, uint getMode, ref Types.RshU32 value);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverGet(IntPtr deviceHandle, uint getMode, ref Types.RshS64 value);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverGet(IntPtr deviceHandle, uint getMode, ref Types.RshU64 value);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverGet(IntPtr deviceHandle, uint getMode, ref Types.RshDouble value);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverGet(IntPtr deviceHandle, uint getMode, ref Types.RshU8P value);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverGet(IntPtr deviceHandle, uint getMode, ref Types.RshU16P value);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverGet(IntPtr deviceHandle, uint getMode, ref Types.RshS8P value);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverGet(IntPtr deviceHandle, uint getMode, ref Types.RshS16P value);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverGet(IntPtr deviceHandle, uint getMode, ref Types.RshBufferS8 value);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverGet(IntPtr deviceHandle, uint getMode, ref Types.RshBufferU8 value);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverGet(IntPtr deviceHandle, uint getMode, ref Types.RshBufferS16 value);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverGet(IntPtr deviceHandle, uint getMode, ref Types.RshBufferU16 value);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverGet(IntPtr deviceHandle, uint getMode, ref Types.RshBufferS32 value);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverGet(IntPtr deviceHandle, uint getMode, ref Types.RshBufferU32 value);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverGet(IntPtr deviceHandle, uint getMode, ref Types.RshBufferS64 value);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverGet(IntPtr deviceHandle, uint getMode, ref Types.RshBufferU64 value);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverGet(IntPtr deviceHandle, uint getMode, ref Types.RshBufferDouble value);  
        
        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverGet(IntPtr deviceHandle, uint getMode, ref Types.RshBoardPortInfo value);  

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverGet(IntPtr deviceHandle, uint getMode, ref Types.RshRegisterInternal value);  
        /*
        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverLVGetArrayDouble(IntPtr deviceHandle, uint getMode, uint size, ref uint received, ref double[] value);  
        */
        
        #endregion

        #region GetData

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverGetData(IntPtr deviceHandle, uint getDataMode, ref Types.RshBufferU8 uRshBuffer);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverGetData(IntPtr deviceHandle, uint getDataMode, ref Types.RshBufferS8 uRshBuffer);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverGetData(IntPtr deviceHandle, uint getDataMode, ref Types.RshBufferU16 uRshBuffer);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverGetData(IntPtr deviceHandle, uint getDataMode, ref Types.RshBufferS16 uRshBuffer);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverGetData(IntPtr deviceHandle, uint getDataMode, ref Types.RshBufferU32 uRshBuffer);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverGetData(IntPtr deviceHandle, uint getDataMode, ref Types.RshBufferS32 uRshBuffer);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverGetData(IntPtr deviceHandle, uint getDataMode, ref Types.RshBufferU64 uRshBuffer);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverGetData(IntPtr deviceHandle, uint getDataMode, ref Types.RshBufferS64 uRshBuffer);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverGetData(IntPtr deviceHandle, uint getDataMode, ref Types.RshBufferDouble uRshBuffer);

        #endregion

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverGetError(uint errorCode, ref Types.RshU16P value, uint language);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverGetRegisteredDeviceName(uint index, ref Types.RshU16P value);

        [DllImport("RshUniDriver.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint UniDriverCloseDeviceHandle(IntPtr deviceHandle);

        #endregion

    }
}
