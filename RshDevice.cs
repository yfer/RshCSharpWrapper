using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RshCSharpWrapper
{
    namespace RshDevice
    {
        public enum RSH_LANGUAGE
        {
            ENGLISH = 0,
            RUSSIAN = 1
        };

        public enum RSH_CONNECT_MODE
        {
            BASE = 0,
            SERIAL_NUMBER = 1
        };

        public enum RSH_INIT_MODE
        {
            CHECK = 0,
            INIT = 1
        };

        public enum RSH_DATA_MODE
        {
            NO_FLAGS = 0x0,
            CONTAIN_DIGITAL_INPUT = 0x00001,

            GSPF_TTL = 0x10000
        };

        public class RshChannel
        {
            public uint gain;		//!< коэффициент усиления
            public uint control;	//!< специфические настройки канала        
            public double delta;		//!< смещениe (в вольтах)

            public enum ControlBit : uint	// специфические настройки канала
            {
                NotUsed = 0x0,	//!< канал не используется при оцифровке
                NoSynchro = 0x0,	//!< по данному каналу не осуществляется синхронизация
                Resist1MOm = 0x0,	//!< сопротивление входа 1 МОм
                DC = 0x0,	//!< состояние входa открытый

                Used = 0x1,	//!< канал используется
                Synchro = 0x2,	//!< синхронизация по данному каналу
                AC = 0x4,	//!< состояние входa закрытый
                Resist50Om = 0x8,	//!< сопротивление входа 50 Ом

                FirstChannel = 0x10000, //!< для некоторых плат данный флаг задаёт канал, который будет оцифрован первым

            };
            public RshChannel()
            {
                gain = 1;
                control = 0;
                delta = 0.0;
            }
            public void SetControl(params ControlBit[] array)
            {
                this.control = 0;
                foreach (ControlBit elem in array)
                    this.control |= (uint)elem;

            }
        };

        public class RshSynchroChannel  // настройка канала внешней синхронизации
        {
            public uint gain;		//!< коэффициент усиления
            public uint control;	//!< специфические настройки канала 

            public enum ControlBit : uint	// специфические настройки канала
            {
                FilterOff = 0x0, //!< фильтр не используется
                Resist1MO = 0x0, //!< сопротивление входа 1 МОм
                DC = 0x0, //!< состояние входa открытый

                FilterLow = 0x1, //!< Фильтр ФНЧ включен
                FilterHigh = 0x3, //!< Фильтр ФВЧ включен
                AC = 0x4, //!< состояние входa закрытый
                Resist50Om = 0x8  //!< сопротивление входa 50 Ом)
            };
            public void SetControl(params ControlBit[] array)
            {
                this.control = 0;
                foreach (ControlBit elem in array)
                    this.control |= (uint)elem;
            }
        }

        public class RshPortInfo
        {
            public uint address;    //!< регистр отвечающий за порт
            public byte bitSize;    //!< разрядность порта     
            public string name;     //!< название порта
            public RshPortInfo()
            {
                address = 0;
                bitSize = 0;
                name = "";
            }
        };

        public class RshBoardPortInfo
        {
            public RshPortInfo[] confs;
            public RshPortInfo[] ports;
        };

        public class RshInitADC
        {
            public uint startType;	// !< настройки типа старта платы
            public uint bufferSize;	// !< размер буфера в отсчётах (значение пересчитывается при инициализации в зависимости от сопутствующих настроек)
            public double frequency;	// !< частота дискретизации	
            public RshChannel[] channels; // параметры каналов
            public double threshold;		//!< уровень синхронизации в Вольтах
            public uint controlSynchro;	//!< специфические настройки синхронизации

            public enum ControlSynchroBit : uint// параметры синхронизации
            {
                FrequencySwitchOFF = 0x0, //!< предыстория и история собираются с одной частотой (ADC_CONTROL_ESW)
                SlopeFront = 0x1,	      //!< синхронизация по фронту
                SlopeDecline = 0x2,       //!< синхронизация по спаду
                FrequencySwitchOn = 0x4   //!< предыстория и история собираются с разными частотами (ADC_CONTROL_FSW)
            };
            public enum StartTypeBit : uint // режимы старта платы
            {
                Program = 0x1, //!< программный запуск
                Timer = 0x2, //!< запуск по таймеру
                External = 0x4, //!< использование внешней синхронизации
                Internal = 0x8, //!< использование внутренней синхронизации
                FrequencyExternal = 0x10, //!< использование внешней частоты дискретизации
                Master = 0x20 //!< старт от устройства-мастера в системах с несколькими устройствами  
            };
            public RshInitADC()
            {
                startType = 1;
                frequency = 0;
                bufferSize = 0;
                channels = new RshChannel[32];
                for (int i = 0; i < 32; i++)
                    channels[i] = new RshChannel();

                threshold = 0.0;
                controlSynchro = 0;
            }
            public void SetStartType(params StartTypeBit[] array)
            {
                this.startType = 0;
                foreach (StartTypeBit elem in array)
                    this.startType |= (uint)elem;
            }
        }

        public class RshInitDMA : RshInitADC
        {
            public uint dmaMode;	//!< режим работы DMA	
            public uint control;	//!< специфические настройки для данного типа плат (например, диф режим)
            public double frequencyPack;	// !< частота дискретизации	внутри пачки
            public enum ControlBit : uint	// настройка режима работы платы
            {
                StandardMode = 0x0, //<! обычный режим работы
                DiffMode = 0x1, //<! дифференциальный режим включен    
                FrameMode = 0x2, //<! кадровый режим
                MulSwitchStart = 0x4, //<! переключение мультиплексора по старту
            };

            public enum DmaModeBit : uint// настройка режима сбора данных
            {
                Single = 0x0, //!< режим одиночного сбора буфера
                Persistent = 0x1, //!< сбор данных в непрерывном режиме
            };
            public void SetControl(params ControlBit[] array)
            {
                this.control = 0;
                foreach (ControlBit elem in array)
                    this.control |= (uint)elem;
            }
            public void SetDmaMode(params DmaModeBit[] array)
            {
                this.dmaMode = 0;
                foreach (DmaModeBit elem in array)
                    this.dmaMode |= (uint)elem;
            }
            public RshInitDMA()
            {

                dmaMode = 0;
                control = 0;
                frequencyPack = 0;
            }
        };

        public class RshInitMemory : RshInitADC // former ADCParametersMEMORY2
        {
            public RshSynchroChannel channelSynchro; //<! настройки канала внешней синхронизации

            public uint control; //!< специфические настройки для данного типа плат
            public uint beforeHistory;	//!< размер предыстории, может принимать значения от 0 до 15
            public uint startDelay;		//!< задержка старта
            public uint hysteresis;		//!< гистеризис
            public uint packetNumber;	//!< количество пакетов размера bufferSize


            public enum ControlBit : uint
            {
                FreqSingle = 0x0,	//!< обычная частота
                FreqDouble = 0x1,	//!< удвоенная частота
                FreqQuadro = 0x2	//!< учетверенная частота
            };
            public void SetControlSynchro(params ControlSynchroBit[] array)
            {
                this.controlSynchro = 0;
                foreach (ControlSynchroBit elem in array)
                    this.controlSynchro |= (uint)elem;
            }
            public void SetControl(params ControlBit[] array)
            {
                this.control = 0;
                foreach (ControlBit elem in array)
                    this.control |= (uint)elem;
            }
            public RshInitMemory()
            {
                control = 0;
                beforeHistory = 0;
                startDelay = 0;
                hysteresis = 0;
                packetNumber = 1;             
                channelSynchro = new RshSynchroChannel();
            }
        } ;

        public class RshInitGSPF
        {
            public uint startType;	//!< тип запуска платы
            public double frequency;//!< частота 
            public AttenuatorBit attenuator; //!<       
            public uint control;	//!< настройки платы

            public enum StartTypeBit : uint// возможные режимы старта платы
            {
                Program = 0x1, //!< программный запуск               
                External = 0x4, //!< использование внешней синхронизации             
                FrequencyExternal = 0x10, //!< использование внешней частоты дискретизации
              
            };
            public enum ControlBit : uint
            {
                FilterOff = 0x0,
                PlayOnce = 0x0,
                SynchroFront = 0x0,
                SynthesizerOff = 0x0,
                SynthesizerOn = 0x1,
                FilterOn = 0x2,
                PlayLoop = 0x4,
                SynchroDecline = 0x8             
            };

            public enum AttenuatorBit : uint
            {
                AttenuationOff = 0x0,
                Attenuation6dB = 0x1,
                Attenuation12db = 0x2,
                Attenuation18dB = 0x3,
                Attenuation24dB = 0x4,
                Attenuation30dB = 0x5,
                Attenuation36dB = 0x6,
                Attenuation42dB = 0x7
            };

            public RshInitGSPF()
            {
                startType = 1;
                frequency = 0;
                attenuator = 0;            
                control = 0;
            }
            public void SetStartType(params StartTypeBit[] array)
            {
                this.startType = 0;
                foreach (StartTypeBit elem in array)
                    this.startType |= (uint)elem;
            }
            public void SetControl(params ControlBit[] array)
            {
                this.control = 0;
                foreach (ControlBit elem in array)
                    this.control |= (uint)elem;
            }
        };

        public class RshInitVoltmeter
        {
            public uint startType;	//!< тип запуска
            public uint bufferSize;	// !< размер буфера в отсчётах (значение пересчитывается при инициализации в зависимости от сопутствующих настроек)
            public double frequency;	// !< частота дискретизации	
            public uint filter;		//!<
            public uint control;	//!< настройки платы

            public enum StartTypeBit : uint// возможные режимы старта платы
            {
                Program = 0x0, //!< программный запуск 
            };
            public enum ControlBit : uint
            {
                VoltageDC = 0x0, //!< измерение отношения постоянных напряжений
                VoltageAC = 0x1, //!< измерение переменного напряжения
                CurrentDC = 0x2, //!< измерение постоянного тока
                CurrentAC = 0x4  //!< измерение переменного тока
            };
            public RshInitVoltmeter()
            {
                startType = 0;
                bufferSize = 0;
                frequency = 0;
                filter = 0;
                control = 0;
            }
            public void SetStartType(params StartTypeBit[] array)
            {
                this.startType = 0;
                foreach (StartTypeBit elem in array)
                    this.startType |= (uint)elem;
            }
        };

        public class RshInitPort
        {
            public enum OperationTypeBit : uint
            {
                Read = 0,
                Write,
                WriteAND,
                WriteOR
            };

            public OperationTypeBit operationType;  //!< Read, Write, Mask with And, OR
            public uint portAddress;   //!< port number
            public uint portValue;     //!< port value

            public RshInitPort()
            {

                operationType = OperationTypeBit.Read;
                portAddress = 0;
                portValue = 0;
            }
        };

        public class RshInitDAC
        {
            public uint id;  //!< Идентификатор ЦАПа
            public double voltage;   //!< Напряжение, которое нужно выдать на ЦАП

            public RshInitDAC()
            {
                id = 0;
                voltage = 0;
            }
        };
        
        public class Device
        {

            private IntPtr deviceHandle;
            private Types.RshBufferS16 bufferS16;
            private Types.RshBufferU16 bufferU16;
            private Types.RshBufferS32 bufferS32;
            private Types.RshBufferDouble bufferDouble;

            private short[] tmpBufferShort = new short[1]; // буфер используется в GetData для копирования данных типа unsigned
            private int[] tmpBufferInt = new int[1];

            private uint operationStatus;
            public RSH_API OperationStatus
            {
                get
                {
                    return (RSH_API)(operationStatus & MASK_RSH_ERROR);
                }
            }
            private const uint MASK_RSH_ERROR = 0xffff0000;
            private const uint MASK_WINAPI_ERROR = 0x0000ffff;
            public Device()
            {
                deviceHandle = IntPtr.Zero;

                bufferS16 = new Types.RshBufferS16(0);
                bufferU16 = new Types.RshBufferU16(0);
                bufferS32 = new Types.RshBufferS32(0);
                bufferDouble = new Types.RshBufferDouble(0);
            }
            public Device(string deviceName)
            {
                try
                {
                    deviceHandle = IntPtr.Zero;

                    bufferU16 = new Types.RshBufferU16(0);
                    bufferS16 = new Types.RshBufferS16(0);
                    bufferS32 = new Types.RshBufferS32(0);
                    bufferDouble = new Types.RshBufferDouble(0);

                    EstablishDriverConnection(deviceName);
                }
                catch (Exception ex)
                {

                }
            }
            ~Device()
            {
                try
                {
                    Connector.UniDriverFreeBuffer(ref bufferS16);
                    Connector.UniDriverFreeBuffer(ref bufferU16);
                    Connector.UniDriverFreeBuffer(ref bufferS32);
                    Connector.UniDriverFreeBuffer(ref bufferDouble);
                    Connector.UniDriverCloseDeviceHandle(deviceHandle);
                }
                catch (Exception ex)
                {

                }
            }

            public RSH_API EstablishDriverConnection(string deviceName)
            {
                try
                {
                    operationStatus = Connector.UniDriverGetDeviceHandle(deviceName, out deviceHandle);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.Message.Contains("Unable to load DLL"))
                        return (RSH_API)(operationStatus = (uint)RSH_API.UNIDRIVER_DLLWASNOTLOADED);
                    else
                        return RSH_API.UNDEFINED;
                }
                return (RSH_API)(operationStatus & MASK_RSH_ERROR);
            }

            public RSH_API CloseDriverConnection()
            {
                try
                {
                    operationStatus = Connector.UniDriverCloseDeviceHandle(deviceHandle);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.Message.Contains("Unable to load DLL"))
                        return (RSH_API)(operationStatus = (uint)RSH_API.UNIDRIVER_DLLWASNOTLOADED);
                    else
                        return RSH_API.UNDEFINED;
                }
                return (RSH_API)(operationStatus & MASK_RSH_ERROR); 
            }

            public RSH_API Connect(uint idNumber, RSH_CONNECT_MODE mode = RSH_CONNECT_MODE.BASE)
            {
                if (deviceHandle == IntPtr.Zero) return RSH_API.DEVICE_DLLWASNOTLOADED;
                try
                {
                    operationStatus = Connector.UniDriverConnect(deviceHandle, idNumber, (uint)mode);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.Message.Contains("Unable to load DLL"))
                        return (RSH_API)(operationStatus = (uint)RSH_API.UNIDRIVER_DLLWASNOTLOADED);
                    else
                        return RSH_API.UNDEFINED;
                }
                return (RSH_API)(operationStatus & MASK_RSH_ERROR);
            }

            public RSH_API Init(RshInitDMA initStructure, RSH_INIT_MODE mode = RSH_INIT_MODE.INIT)
            {
                if (deviceHandle == IntPtr.Zero) return RSH_API.DEVICE_DLLWASNOTLOADED;

                Types.RshInitDMA iS = new Types.RshInitDMA(0); // для вызова своего конструктора

                iS.bufferSize = initStructure.bufferSize;
                iS.control = initStructure.control;
                iS.dmaMode = initStructure.dmaMode;
                iS.frequency = initStructure.frequency;
                iS.frequencyPack = initStructure.frequencyPack;
                iS.startType = initStructure.startType;
                iS.threshold = initStructure.threshold;
                iS.controlSynchro = initStructure.controlSynchro;

                for (int i = 0; i < initStructure.channels.Length; i++)
                {
                    iS.channels[i].control = initStructure.channels[i].control;
                    iS.channels[i].gain = initStructure.channels[i].gain;
                    iS.channels[i].delta = initStructure.channels[i].delta;
                }
                try
                {
                    operationStatus = Connector.UniDriverInit(deviceHandle, (uint)mode, ref iS);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.Message.Contains("Unable to load DLL"))
                        return (RSH_API)(operationStatus = (uint)RSH_API.UNIDRIVER_DLLWASNOTLOADED);
                    else
                        return RSH_API.UNDEFINED;
                }
                RSH_API st = (RSH_API)(operationStatus & MASK_RSH_ERROR);

                if (st == RSH_API.SUCCESS)
                {
                    initStructure.bufferSize = iS.bufferSize;
                    initStructure.control = iS.control;
                    initStructure.dmaMode = iS.dmaMode;
                    initStructure.frequency = iS.frequency;
                    initStructure.frequencyPack = iS.frequencyPack;
                    initStructure.startType = iS.startType;
                    initStructure.threshold = iS.threshold;
                    initStructure.controlSynchro = iS.controlSynchro;

                    for (int i = 0; i < initStructure.channels.Length; i++)
                    {
                        initStructure.channels[i].control = iS.channels[i].control;
                        initStructure.channels[i].gain = iS.channels[i].gain;
                        initStructure.channels[i].delta = iS.channels[i].delta;
                    }
                }

                return st;
            }
            public RSH_API Init(RshInitMemory initStructure, RSH_INIT_MODE mode = RSH_INIT_MODE.INIT)
            {
                if (deviceHandle == IntPtr.Zero) return RSH_API.DEVICE_DLLWASNOTLOADED;

                Types.RshInitMemory iS = new Types.RshInitMemory(0);

                iS.bufferSize = initStructure.bufferSize;
                iS.control = initStructure.control;
                iS.frequency = initStructure.frequency;
                iS.startType = initStructure.startType;
                iS.beforeHistory = initStructure.beforeHistory;
                iS.controlSynchro = initStructure.controlSynchro;
                iS.hysteresis = initStructure.hysteresis;
                iS.packetNumber = initStructure.packetNumber;
                iS.startDelay = initStructure.startDelay;
                iS.threshold = initStructure.threshold;
                iS.channelSynchro.control = initStructure.channelSynchro.control;
                iS.channelSynchro.gain = initStructure.channelSynchro.gain;


                for (int i = 0; i < initStructure.channels.Length; i++)
                {
                    iS.channels[i].control = initStructure.channels[i].control;
                    iS.channels[i].gain = initStructure.channels[i].gain;
                    iS.channels[i].delta = initStructure.channels[i].delta;
                }

                try
                {
                    operationStatus = Connector.UniDriverInit(deviceHandle, (uint)mode, ref iS);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.Message.Contains("Unable to load DLL"))
                        return (RSH_API)(operationStatus = (uint)RSH_API.UNIDRIVER_DLLWASNOTLOADED);
                    else
                        return RSH_API.UNDEFINED;
                }
                RSH_API st = (RSH_API)(operationStatus & MASK_RSH_ERROR);

                if (st == RSH_API.SUCCESS)
                {
                    initStructure.bufferSize = iS.bufferSize;
                    initStructure.control = iS.control;
                    initStructure.frequency = iS.frequency;
                    initStructure.startType = iS.startType;
                    initStructure.beforeHistory = iS.beforeHistory;
                    initStructure.controlSynchro = iS.controlSynchro;
                    initStructure.hysteresis = iS.hysteresis;
                    initStructure.packetNumber = iS.packetNumber;
                    initStructure.startDelay = iS.startDelay;
                    initStructure.threshold = iS.threshold;
                    initStructure.channelSynchro.control = iS.channelSynchro.control;
                    initStructure.channelSynchro.gain = iS.channelSynchro.gain;

                    for (int i = 0; i < initStructure.channels.Length; i++)
                    {
                        initStructure.channels[i].control = iS.channels[i].control;
                        initStructure.channels[i].gain = iS.channels[i].gain;
                        initStructure.channels[i].delta = iS.channels[i].delta;
                    }
                }

                return st;
            }
            public RSH_API Init(RshInitGSPF initStructure, RSH_INIT_MODE mode = RSH_INIT_MODE.INIT)
            {
                if (deviceHandle == IntPtr.Zero) return RSH_API.DEVICE_DLLWASNOTLOADED;

                Types.RshInitGSPF iS = new Types.RshInitGSPF(0);

                iS.attenuator = (uint)initStructure.attenuator;
                iS.control = initStructure.control;           
                iS.frequency = initStructure.frequency;
                iS.startType = initStructure.startType;

                try
                {
                    operationStatus = Connector.UniDriverInit(deviceHandle, (uint)mode, ref iS);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.Message.Contains("Unable to load DLL"))
                        return (RSH_API)(operationStatus = (uint)RSH_API.UNIDRIVER_DLLWASNOTLOADED);
                    else
                        return RSH_API.UNDEFINED;
                }
                RSH_API st = (RSH_API)(operationStatus & MASK_RSH_ERROR);

                if (st == RSH_API.SUCCESS)
                {
                    initStructure.attenuator = (RshInitGSPF.AttenuatorBit)iS.attenuator;
                    initStructure.control = iS.control;             
                    initStructure.frequency = iS.frequency;
                    initStructure.startType = iS.startType;
                }

                return st;
            }
            public RSH_API Init(RshInitVoltmeter initStructure, RSH_INIT_MODE mode = RSH_INIT_MODE.INIT)
            {
                if (deviceHandle == IntPtr.Zero) return RSH_API.DEVICE_DLLWASNOTLOADED;

                Types.RshInitVoltmeter iS = new Types.RshInitVoltmeter(0);

                iS.bufferSize = initStructure.bufferSize;
                iS.control = initStructure.control;
                iS.filter = initStructure.filter;
                iS.startType = initStructure.startType;

                try
                {
                    operationStatus = Connector.UniDriverInit(deviceHandle, (uint)mode, ref iS);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.Message.Contains("Unable to load DLL"))
                        return (RSH_API)(operationStatus = (uint)RSH_API.UNIDRIVER_DLLWASNOTLOADED);
                    else
                        return RSH_API.UNDEFINED;
                }
                RSH_API st = (RSH_API)(operationStatus & MASK_RSH_ERROR);

                if (st == RSH_API.SUCCESS)
                {
                    initStructure.bufferSize = iS.bufferSize;
                    initStructure.control = iS.control;
                    initStructure.filter = iS.filter;
                    initStructure.startType = iS.startType;
                }

                return st;
            }
            public RSH_API Init(RshInitPort initStructure, RSH_INIT_MODE mode = RSH_INIT_MODE.INIT)
            {
                if (deviceHandle == IntPtr.Zero) return RSH_API.DEVICE_DLLWASNOTLOADED;

                Types.RshInitPort iS = new Types.RshInitPort(0);

                iS.operationType = (uint)initStructure.operationType;
                iS.portAddress = initStructure.portAddress;
                iS.portValue = initStructure.portValue;

                try
                {
                    operationStatus = Connector.UniDriverInit(deviceHandle, (uint)mode, ref iS);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.Message.Contains("Unable to load DLL"))
                        return (RSH_API)(operationStatus = (uint)RSH_API.UNIDRIVER_DLLWASNOTLOADED);
                    else
                        return RSH_API.UNDEFINED;
                }
                RSH_API st = (RSH_API)(operationStatus & MASK_RSH_ERROR);

                if (st == RSH_API.SUCCESS)
                {
                    initStructure.operationType = (RshInitPort.OperationTypeBit)iS.operationType;
                    initStructure.portAddress = iS.portAddress;
                    initStructure.portValue = iS.portValue;
                }

                return st;
            }

            public RSH_API Init(RshInitDAC initStructure, RSH_INIT_MODE mode = RSH_INIT_MODE.INIT)
            {
                if (deviceHandle == IntPtr.Zero) return RSH_API.DEVICE_DLLWASNOTLOADED;

                Types.RshInitDAC iS = new Types.RshInitDAC(0);

                iS.id = initStructure.id;
                iS.voltage = initStructure.voltage;

                try
                {
                    operationStatus = Connector.UniDriverInit(deviceHandle, (uint)mode, ref iS);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.Message.Contains("Unable to load DLL"))
                        return (RSH_API)(operationStatus = (uint)RSH_API.UNIDRIVER_DLLWASNOTLOADED);
                    else
                        return RSH_API.UNDEFINED;
                }
                RSH_API st = (RSH_API)(operationStatus & MASK_RSH_ERROR);

                if (st == RSH_API.SUCCESS)
                {
                    initStructure.id = iS.id;
                    initStructure.voltage = iS.voltage;
                }

                return st;
            }

            public RSH_API Start()
            {
                if (deviceHandle == IntPtr.Zero) return RSH_API.DEVICE_DLLWASNOTLOADED;

                try
                {
                    operationStatus = Connector.UniDriverStart(deviceHandle);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.Message.Contains("Unable to load DLL"))
                        return (RSH_API)(operationStatus = (uint)RSH_API.UNIDRIVER_DLLWASNOTLOADED);
                    else
                        return RSH_API.UNDEFINED;
                }
                return (RSH_API)(operationStatus & MASK_RSH_ERROR);
            }
            public RSH_API Stop()
            {
                if (deviceHandle == IntPtr.Zero) return RSH_API.DEVICE_DLLWASNOTLOADED;
                try
                {
                    operationStatus = Connector.UniDriverStop(deviceHandle);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.Message.Contains("Unable to load DLL"))
                        return (RSH_API)(operationStatus = (uint)RSH_API.UNIDRIVER_DLLWASNOTLOADED);
                    else
                        return RSH_API.UNDEFINED;
                }
                return (RSH_API)(operationStatus & MASK_RSH_ERROR);
            }

            public RSH_API GetData(int[] buffer, RSH_DATA_MODE mode = RSH_DATA_MODE.NO_FLAGS)
            {
                if (deviceHandle == IntPtr.Zero) return RSH_API.DEVICE_DLLWASNOTLOADED;

                RSH_API st = RSH_API.SUCCESS;

                try
                {
                    st = (RSH_API)Connector.UniDriverAllocateBuffer(ref bufferS32, (uint)buffer.Length);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.Message.Contains("Unable to load DLL"))
                        return (RSH_API)(operationStatus = (uint)RSH_API.UNIDRIVER_DLLWASNOTLOADED);
                    else
                        return RSH_API.UNDEFINED;
                }

                if (st == RSH_API.SUCCESS)
                {

                    try
                    {
                        operationStatus = Connector.UniDriverGetData(deviceHandle, (uint)mode, ref bufferS32);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        if (ex.Message.Contains("Unable to load DLL"))
                            return (RSH_API)(operationStatus = (uint)RSH_API.UNIDRIVER_DLLWASNOTLOADED);
                        else
                            return RSH_API.UNDEFINED;
                    }
                    st = (RSH_API)(operationStatus & MASK_RSH_ERROR);

                    if (st != RSH_API.SUCCESS) return st;

                    System.Runtime.InteropServices.Marshal.Copy(bufferS32.ptr, buffer, 0, (int)bufferS32.size);
                }

                return st;
            }
            public RSH_API GetData(short[] buffer, RSH_DATA_MODE mode = RSH_DATA_MODE.NO_FLAGS)
            {
                if (deviceHandle == IntPtr.Zero) return RSH_API.DEVICE_DLLWASNOTLOADED;

                RSH_API st = RSH_API.SUCCESS;


                try
                {
                    st = (RSH_API)Connector.UniDriverAllocateBuffer(ref bufferS16, (uint)buffer.Length);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.Message.Contains("Unable to load DLL"))
                        return (RSH_API)(operationStatus = (uint)RSH_API.UNIDRIVER_DLLWASNOTLOADED);
                    else
                        return RSH_API.UNDEFINED;
                }

                if (st == RSH_API.SUCCESS)
                {
                    try
                    {
                        operationStatus = Connector.UniDriverGetData(deviceHandle, (uint)mode, ref bufferS16);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        if (ex.Message.Contains("Unable to load DLL"))
                            return (RSH_API)(operationStatus = (uint)RSH_API.UNIDRIVER_DLLWASNOTLOADED);
                        else
                            return RSH_API.UNDEFINED;
                    }
                    st = (RSH_API)(operationStatus & MASK_RSH_ERROR);

                    if (st != RSH_API.SUCCESS) return st;

                    System.Runtime.InteropServices.Marshal.Copy(bufferS16.ptr, buffer, 0, (int)bufferS16.size);
                }

                return st;
            }

            public RSH_API GetData(ushort[] buffer, RSH_DATA_MODE mode = RSH_DATA_MODE.NO_FLAGS)
            {
                if (deviceHandle == IntPtr.Zero) return RSH_API.DEVICE_DLLWASNOTLOADED;

                RSH_API st = RSH_API.SUCCESS;


                try
                {
                    st = (RSH_API)Connector.UniDriverAllocateBuffer(ref bufferU16, (uint)buffer.Length);
                    tmpBufferShort = new short[buffer.Length];
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.Message.Contains("Unable to load DLL"))
                        return (RSH_API)(operationStatus = (uint)RSH_API.UNIDRIVER_DLLWASNOTLOADED);
                    else
                        return RSH_API.UNDEFINED;
                }

                if (st == RSH_API.SUCCESS)
                {
                    try
                    {
                        operationStatus = Connector.UniDriverGetData(deviceHandle, (uint)mode, ref bufferU16);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        if (ex.Message.Contains("Unable to load DLL"))
                            return (RSH_API)(operationStatus = (uint)RSH_API.UNIDRIVER_DLLWASNOTLOADED);
                        else
                            return RSH_API.UNDEFINED;
                    }
                    st = (RSH_API)(operationStatus & MASK_RSH_ERROR);

                    if (st != RSH_API.SUCCESS) return st;

                    System.Runtime.InteropServices.Marshal.Copy(bufferU16.ptr, tmpBufferShort, 0, (int)bufferU16.size);
                    tmpBufferShort.CopyTo(buffer, 0);
                }

                return st;
            }

            public RSH_API GetData(double[] buffer, RSH_DATA_MODE mode = RSH_DATA_MODE.NO_FLAGS)
            {
                if (deviceHandle == IntPtr.Zero) return RSH_API.DEVICE_DLLWASNOTLOADED;

                RSH_API st = RSH_API.SUCCESS;


                try
                {
                    st = (RSH_API)Connector.UniDriverAllocateBuffer(ref bufferDouble, (uint)buffer.Length);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.Message.Contains("Unable to load DLL"))
                        return (RSH_API)(operationStatus = (uint)RSH_API.UNIDRIVER_DLLWASNOTLOADED);
                    else
                        return RSH_API.UNDEFINED;
                }

                if (st == RSH_API.SUCCESS)
                {
                    try
                    {
                        operationStatus = Connector.UniDriverGetData(deviceHandle, (uint)mode, ref bufferDouble);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        if (ex.Message.Contains("Unable to load DLL"))
                            return (RSH_API)(operationStatus = (uint)RSH_API.UNIDRIVER_DLLWASNOTLOADED);
                        else
                            return RSH_API.UNDEFINED;
                    }
                    st = (RSH_API)(operationStatus & MASK_RSH_ERROR);

                    if (st != RSH_API.SUCCESS) return st;

                    System.Runtime.InteropServices.Marshal.Copy(bufferDouble.ptr, buffer, 0, (int)bufferDouble.size);
                }

                return st;
            }

            public RSH_API SetData(short[] buffer, RSH_DATA_MODE mode = RSH_DATA_MODE.NO_FLAGS)
            {
                if (deviceHandle == IntPtr.Zero) return RSH_API.DEVICE_DLLWASNOTLOADED;

                RSH_API st = RSH_API.SUCCESS;


                try
                {
                    st = (RSH_API)Connector.UniDriverAllocateBuffer(ref bufferS16, (uint)buffer.Length);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.Message.Contains("Unable to load DLL"))
                        return (RSH_API)(operationStatus = (uint)RSH_API.UNIDRIVER_DLLWASNOTLOADED);
                    else
                        return RSH_API.UNDEFINED;
                }

                if (st == RSH_API.SUCCESS)
                {
                    try
                    {
                        System.Runtime.InteropServices.Marshal.Copy(buffer, 0, bufferS16.ptr, buffer.Length);
                        operationStatus = Connector.UniDriverGetData(deviceHandle, (uint)mode, ref bufferS16);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        if (ex.Message.Contains("Unable to load DLL"))
                            return (RSH_API)(operationStatus = (uint)RSH_API.UNIDRIVER_DLLWASNOTLOADED);
                        else
                            return RSH_API.UNDEFINED;
                    }
                    st = (RSH_API)(operationStatus & MASK_RSH_ERROR);

                    if (st != RSH_API.SUCCESS) return st;
                }

                return st;
            }

            public RSH_API Get(RSH_GET mode)
            {
                if (deviceHandle == IntPtr.Zero) return RSH_API.DEVICE_DLLWASNOTLOADED;

                RSH_API st = RSH_API.SUCCESS;

                Types.RshS32 tmp = new Types.RshS32(0);
                tmp.data = 0;
                try
                {
                    operationStatus = Connector.UniDriverGet(deviceHandle, (uint)mode, ref tmp);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.Message.Contains("Unable to load DLL"))
                        return (RSH_API)(operationStatus = (uint)RSH_API.UNIDRIVER_DLLWASNOTLOADED);
                    else
                        return RSH_API.UNDEFINED;
                }
                st = (RSH_API)(operationStatus & MASK_RSH_ERROR);

                return st;
            }

            public RSH_API Get(RSH_GET mode, ref double value)
            {
                if (deviceHandle == IntPtr.Zero) return RSH_API.DEVICE_DLLWASNOTLOADED;

                RSH_API st = RSH_API.SUCCESS;

                Types.RshDouble tmp = new Types.RshDouble(0);
                tmp.data = value;
                try
                {
                    operationStatus = Connector.UniDriverGet(deviceHandle, (uint)mode, ref tmp);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.Message.Contains("Unable to load DLL"))
                        return (RSH_API)(operationStatus = (uint)RSH_API.UNIDRIVER_DLLWASNOTLOADED);
                    else
                        return RSH_API.UNDEFINED;
                }
                st = (RSH_API)(operationStatus & MASK_RSH_ERROR);

                if (st == RSH_API.SUCCESS) value = tmp.data;

                return st;
            }
            public RSH_API Get(RSH_GET mode, ref uint value)
            {
                if (deviceHandle == IntPtr.Zero) return RSH_API.DEVICE_DLLWASNOTLOADED;

                RSH_API st = RSH_API.SUCCESS;

                Types.RshU32 tmp = new Types.RshU32(0);
                tmp.data = value;
                try
                {
                    operationStatus = Connector.UniDriverGet(deviceHandle, (uint)mode, ref tmp);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.Message.Contains("Unable to load DLL"))
                        return (RSH_API)(operationStatus = (uint)RSH_API.UNIDRIVER_DLLWASNOTLOADED);
                    else
                        return RSH_API.UNDEFINED;
                }
                st = (RSH_API)(operationStatus & MASK_RSH_ERROR);

                if (st == RSH_API.SUCCESS) value = tmp.data;

                return st;
            }

            public RSH_API Get(RSH_GET mode, ref int value)
            {
                if (deviceHandle == IntPtr.Zero) return RSH_API.DEVICE_DLLWASNOTLOADED;

                RSH_API st = RSH_API.SUCCESS;

                Types.RshS32 tmp = new Types.RshS32(0);
                tmp.data = value;
                try
                {
                    operationStatus = Connector.UniDriverGet(deviceHandle, (uint)mode, ref tmp);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.Message.Contains("Unable to load DLL"))
                        return (RSH_API)(operationStatus = (uint)RSH_API.UNIDRIVER_DLLWASNOTLOADED);
                    else
                        return RSH_API.UNDEFINED;
                }
                st = (RSH_API)(operationStatus & MASK_RSH_ERROR);

                if (st == RSH_API.SUCCESS) value = tmp.data;

                return st;
            }


            public RSH_API Get(RSH_GET mode, out string value)
            {
                value = "";

                if (deviceHandle == IntPtr.Zero) return RSH_API.DEVICE_DLLWASNOTLOADED;

                RSH_API st = RSH_API.SUCCESS;

                if (mode.ToString().Contains("UTF16"))
                {
                    Types.RshU16P tmp = new Types.RshU16P(0);
                    try
                    {
                        operationStatus = Connector.UniDriverGet(deviceHandle, (uint)mode, ref tmp);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        if (ex.Message.Contains("Unable to load DLL"))
                            return (RSH_API)(operationStatus = (uint)RSH_API.UNIDRIVER_DLLWASNOTLOADED);
                        else
                            return RSH_API.UNDEFINED;
                    }
                    st = (RSH_API)(operationStatus & MASK_RSH_ERROR);
                    if (st == RSH_API.SUCCESS) value = System.Runtime.InteropServices.Marshal.PtrToStringUni(tmp.data);
                }
                else
                {
                    Types.RshS8P tmp = new Types.RshS8P(0);
                    try
                    {
                        operationStatus = Connector.UniDriverGet(deviceHandle, (uint)mode, ref tmp);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        if (ex.Message.Contains("Unable to load DLL"))
                            return (RSH_API)(operationStatus = (uint)RSH_API.UNIDRIVER_DLLWASNOTLOADED);
                        else
                            return RSH_API.UNDEFINED;
                    }
                    st = (RSH_API)(operationStatus & MASK_RSH_ERROR);
                    if (st == RSH_API.SUCCESS) value = System.Runtime.InteropServices.Marshal.PtrToStringAnsi(tmp.data);
                }

                return st;
            }

            public RSH_API Get(RSH_GET mode, ref RshBoardPortInfo value)
            {
                if (deviceHandle == IntPtr.Zero) return RSH_API.DEVICE_DLLWASNOTLOADED;

                RSH_API st = RSH_API.SUCCESS;

                Types.RshBoardPortInfo tmp = new Types.RshBoardPortInfo(0);

                try
                {
                    operationStatus = Connector.UniDriverGet(deviceHandle, (uint)mode, ref tmp);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.Message.Contains("Unable to load DLL"))
                        return (RSH_API)(operationStatus = (uint)RSH_API.UNIDRIVER_DLLWASNOTLOADED);
                    else
                        return RSH_API.UNDEFINED;
                }
                st = (RSH_API)(operationStatus & MASK_RSH_ERROR);

                if (st == RSH_API.SUCCESS)
                {
                    if (tmp.totalConfs != 0)
                    {
                        value.confs = new RshPortInfo[tmp.totalConfs];
                        for (int i = 0; i < value.confs.Length; i++)
                        {
                            value.confs[i] = new RshPortInfo();
                            value.confs[i].address = tmp.confs[i].address;
                            value.confs[i].bitSize = tmp.confs[i].bitSize;
                            string str = System.Text.Encoding.UTF8.GetString(tmp.confs[i].name);
                            value.confs[i].name = str.Substring(0, str.IndexOf('\0'));
                        }
                    }

                    if (tmp.totalPorts != 0)
                    {
                        value.ports = new RshPortInfo[tmp.totalPorts];
                        for (int i = 0; i < value.ports.Length; i++)
                        {
                            value.ports[i] = new RshPortInfo();
                            value.ports[i].address = tmp.ports[i].address;
                            value.ports[i].bitSize = tmp.ports[i].bitSize;
                            string str = System.Text.Encoding.UTF8.GetString(tmp.ports[i].name);
                            value.ports[i].name = str.Substring(0, str.IndexOf('\0'));
                        }
                    }
                }
                return st;
            }
            public static RSH_API RshGetErrorDescription(RSH_API errorCode, out string value, RSH_LANGUAGE language)
            {
                value = "";
                uint os;
                RSH_API st = RSH_API.SUCCESS;

                Types.RshU16P tmp = new Types.RshU16P(0);
                try
                {
                    os = Connector.UniDriverGetError((uint)errorCode, ref tmp, (uint)language);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.Message.Contains("Unable to load DLL"))
                        return (RSH_API)(os = (uint)RSH_API.UNIDRIVER_DLLWASNOTLOADED);
                    else
                        return RSH_API.UNDEFINED;
                }
                st = (RSH_API)(os & MASK_RSH_ERROR);
                if (st == RSH_API.SUCCESS)
                    value = System.Runtime.InteropServices.Marshal.PtrToStringUni(tmp.data);

                return st;
            }

            public static RSH_API RshGetRegisteredDeviceName(uint index, out string value)
            {
                value = "";
                uint os;
                RSH_API st = RSH_API.SUCCESS;

                Types.RshU16P tmp = new Types.RshU16P(0);
                try
                {
                    os = Connector.UniDriverGetRegisteredDeviceName(index, ref tmp);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.Message.Contains("Unable to load DLL"))
                        return (RSH_API)(os = (uint)RSH_API.UNIDRIVER_DLLWASNOTLOADED);
                    else
                        return RSH_API.UNDEFINED;
                }
                st = (RSH_API)(os & MASK_RSH_ERROR);
                if (st == RSH_API.SUCCESS)
                    value = System.Runtime.InteropServices.Marshal.PtrToStringUni(tmp.data);

                return st;
            }
            /*
            public static RSH_API RshGetRegisteredDeviceName(uint index, out string[] value)
            {
                
                uint os;
                RSH_API st = RSH_API.SUCCESS;

                uint ind = 0;
                while (true)
                {

                    string value;

                    st = Device.RshGetRegisteredDeviceName(ind++, out value);
                    if (st != RSH_API.SUCCESS) break;

                    Console.WriteLine(value);
                }

                return st;
            }*/
        };

        /*
        [System.Runtime.InteropServices.ClassInterface(System.Runtime.InteropServices.ClassInterfaceType.AutoDual)]
        public struct vbaInitStructure
        {
            public double frequency;
            public double bufferSize;
            
            public int[] chGain = new int[32];		//!< коэффициент усиления
            public int[] chControl = new int[32];	//!< специфические настройки канала        
            public double[] chDelta = new double[32];	//!< смещениe (в вольтах)
        };
        */
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
}
