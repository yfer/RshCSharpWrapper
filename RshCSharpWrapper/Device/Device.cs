using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace RshCSharpWrapper.Device
{
    public class Device : IDisposable
    {
        private IntPtr deviceHandle;
        private Types.BufferS16 bufferS16;
        private Types.BufferU16 bufferU16;
        private Types.BufferS32 bufferS32;
        private Types.BufferDouble bufferDouble;

        private short[] tmpBufferShort = new short[1]; // буфер используется в GetData для копирования данных типа unsigned
        private int[] tmpBufferInt = new int[1];

        private const uint MASK_RSH_ERROR = 0xffff0000;
        private const uint MASK_WINAPI_ERROR = 0x0000ffff;
        public Device()
        {
            deviceHandle = IntPtr.Zero;

            bufferS16 = new Types.BufferS16(0);
            bufferU16 = new Types.BufferU16(0);
            bufferS32 = new Types.BufferS32(0);
            bufferDouble = new Types.BufferDouble(0);
        }
        public Device(string deviceName):this()
        {
            EstablishDriverConnection(deviceName);
        }

        #region Valid implimentation of unmanaged resource destructor and IDisposable() http://msdn.microsoft.com/en-us/library/system.idisposable.aspx
        bool disposed = false;
        ~Device()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here. 
                //
            }

            // Free any unmanaged objects here. 
            //

            Connector.UniDriverFreeBuffer(ref bufferS16);
            Connector.UniDriverFreeBuffer(ref bufferU16);
            Connector.UniDriverFreeBuffer(ref bufferS32);
            Connector.UniDriverFreeBuffer(ref bufferDouble);
            Connector.UniDriverCloseDeviceHandle(deviceHandle);

            disposed = true;
        }
        #endregion

        public API EstablishDriverConnection(string deviceName)
        {
            uint operationStatus;
            try
            {
                operationStatus = Connector.UniDriverGetDeviceHandle(deviceName, out deviceHandle);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                if (ex.Message.Contains("Unable to load DLL"))
                    return (API)(operationStatus = (uint)API.UNIDRIVER_DLLWASNOTLOADED);
                else
                    return API.UNDEFINED;
            }
            return (API)(operationStatus & MASK_RSH_ERROR);
        }

        public API CloseDriverConnection()
        {
            uint operationStatus;
            try
            {
                operationStatus = Connector.UniDriverCloseDeviceHandle(deviceHandle);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                if (ex.Message.Contains("Unable to load DLL"))
                    return (API)(operationStatus = (uint)API.UNIDRIVER_DLLWASNOTLOADED);
                else
                    return API.UNDEFINED;
            }
            return (API)(operationStatus & MASK_RSH_ERROR);
        }
       
        public API Connect(uint idNumber, CONNECT_MODE mode = CONNECT_MODE.BASE)
        {
            uint operationStatus;
            if (deviceHandle == IntPtr.Zero) return API.DEVICE_DLLWASNOTLOADED;
            try
            {
                operationStatus = Connector.UniDriverConnect(deviceHandle, idNumber, (uint)mode);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                if (ex.Message.Contains("Unable to load DLL"))
                    return (API)(operationStatus = (uint)API.UNIDRIVER_DLLWASNOTLOADED);
                else
                    return API.UNDEFINED;
            }
            return (API)(operationStatus & MASK_RSH_ERROR);
        }

        public API Init(InitDMA initStructure, INIT_MODE mode = INIT_MODE.INIT)
        {
            uint operationStatus;
            if (deviceHandle == IntPtr.Zero) return API.DEVICE_DLLWASNOTLOADED;

            Types.InitDMA iS = new Types.InitDMA(0); // для вызова своего конструктора

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
                    return (API)(operationStatus = (uint)API.UNIDRIVER_DLLWASNOTLOADED);
                else
                    return API.UNDEFINED;
            }
            API st = (API)(operationStatus & MASK_RSH_ERROR);

            if (st == API.SUCCESS)
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
        public API Init(InitMemory initStructure, INIT_MODE mode = INIT_MODE.INIT)
        {
            uint operationStatus;
            if (deviceHandle == IntPtr.Zero) return API.DEVICE_DLLWASNOTLOADED;

            Types.InitMemory iS = new Types.InitMemory(0);

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
                    return (API)(operationStatus = (uint)API.UNIDRIVER_DLLWASNOTLOADED);
                else
                    return API.UNDEFINED;
            }
            API st = (API)(operationStatus & MASK_RSH_ERROR);

            if (st == API.SUCCESS)
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
        public API Init(InitGSPF initStructure, INIT_MODE mode = INIT_MODE.INIT)
        {
            uint operationStatus;
            if (deviceHandle == IntPtr.Zero) return API.DEVICE_DLLWASNOTLOADED;

            Types.InitGSPF iS = new Types.InitGSPF(0);

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
                    return (API)(operationStatus = (uint)API.UNIDRIVER_DLLWASNOTLOADED);
                else
                    return API.UNDEFINED;
            }
            API st = (API)(operationStatus & MASK_RSH_ERROR);

            if (st == API.SUCCESS)
            {
                initStructure.attenuator = (InitGSPF.AttenuatorBit)iS.attenuator;
                initStructure.control = iS.control;
                initStructure.frequency = iS.frequency;
                initStructure.startType = iS.startType;
            }

            return st;
        }
        public API Init(InitVoltmeter initStructure, INIT_MODE mode = INIT_MODE.INIT)
        {
            uint operationStatus;
            if (deviceHandle == IntPtr.Zero) return API.DEVICE_DLLWASNOTLOADED;

            Types.InitVoltmeter iS = new Types.InitVoltmeter(0);

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
                    return (API)(operationStatus = (uint)API.UNIDRIVER_DLLWASNOTLOADED);
                else
                    return API.UNDEFINED;
            }
            API st = (API)(operationStatus & MASK_RSH_ERROR);

            if (st == API.SUCCESS)
            {
                initStructure.bufferSize = iS.bufferSize;
                initStructure.control = iS.control;
                initStructure.filter = iS.filter;
                initStructure.startType = iS.startType;
            }

            return st;
        }
        public API Init(InitPort initStructure, INIT_MODE mode = INIT_MODE.INIT)
        {
            uint operationStatus;
            if (deviceHandle == IntPtr.Zero) return API.DEVICE_DLLWASNOTLOADED;

            Types.InitPort iS = new Types.InitPort(0);

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
                    return (API)(operationStatus = (uint)API.UNIDRIVER_DLLWASNOTLOADED);
                else
                    return API.UNDEFINED;
            }
            API st = (API)(operationStatus & MASK_RSH_ERROR);

            if (st == API.SUCCESS)
            {
                initStructure.operationType = (InitPort.OperationTypeBit)iS.operationType;
                initStructure.portAddress = iS.portAddress;
                initStructure.portValue = iS.portValue;
            }

            return st;
        }
        public API Init(InitDAC initStructure, INIT_MODE mode = INIT_MODE.INIT)
        {
            uint operationStatus;
            if (deviceHandle == IntPtr.Zero) return API.DEVICE_DLLWASNOTLOADED;

            Types.InitDAC iS = new Types.InitDAC(0);

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
                    return (API)(operationStatus = (uint)API.UNIDRIVER_DLLWASNOTLOADED);
                else
                    return API.UNDEFINED;
            }
            API st = (API)(operationStatus & MASK_RSH_ERROR);

            if (st == API.SUCCESS)
            {
                initStructure.id = iS.id;
                initStructure.voltage = iS.voltage;
            }

            return st;
        }

        public API Start()
        {
            uint operationStatus;
            if (deviceHandle == IntPtr.Zero) return API.DEVICE_DLLWASNOTLOADED;

            try
            {
                operationStatus = Connector.UniDriverStart(deviceHandle);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                if (ex.Message.Contains("Unable to load DLL"))
                    return (API)(operationStatus = (uint)API.UNIDRIVER_DLLWASNOTLOADED);
                else
                    return API.UNDEFINED;
            }
            return (API)(operationStatus & MASK_RSH_ERROR);
        }
        public API Stop()
        {
            uint operationStatus;
            if (deviceHandle == IntPtr.Zero) return API.DEVICE_DLLWASNOTLOADED;
            try
            {
                operationStatus = Connector.UniDriverStop(deviceHandle);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                if (ex.Message.Contains("Unable to load DLL"))
                    return (API)(operationStatus = (uint)API.UNIDRIVER_DLLWASNOTLOADED);
                else
                    return API.UNDEFINED;
            }
            return (API)(operationStatus & MASK_RSH_ERROR);
        }

        public API GetData(int[] buffer, DATA_MODE mode = DATA_MODE.NO_FLAGS)
        {
            uint operationStatus;
            if (deviceHandle == IntPtr.Zero) return API.DEVICE_DLLWASNOTLOADED;

            API st = API.SUCCESS;

            try
            {
                st = (API)Connector.UniDriverAllocateBuffer(ref bufferS32, (uint)buffer.Length);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                if (ex.Message.Contains("Unable to load DLL"))
                    return (API)(operationStatus = (uint)API.UNIDRIVER_DLLWASNOTLOADED);
                else
                    return API.UNDEFINED;
            }

            if (st == API.SUCCESS)
            {

                try
                {
                    operationStatus = Connector.UniDriverGetData(deviceHandle, (uint)mode, ref bufferS32);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.Message.Contains("Unable to load DLL"))
                        return (API)(operationStatus = (uint)API.UNIDRIVER_DLLWASNOTLOADED);
                    else
                        return API.UNDEFINED;
                }
                st = (API)(operationStatus & MASK_RSH_ERROR);

                if (st != API.SUCCESS) return st;

                System.Runtime.InteropServices.Marshal.Copy(bufferS32.ptr, buffer, 0, (int)bufferS32.size);
            }

            return st;
        }
        public API GetData(short[] buffer, DATA_MODE mode = DATA_MODE.NO_FLAGS)
        {
            uint operationStatus;
            if (deviceHandle == IntPtr.Zero) return API.DEVICE_DLLWASNOTLOADED;

            API st = API.SUCCESS;


            try
            {
                st = (API)Connector.UniDriverAllocateBuffer(ref bufferS16, (uint)buffer.Length);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                if (ex.Message.Contains("Unable to load DLL"))
                    return (API)(operationStatus = (uint)API.UNIDRIVER_DLLWASNOTLOADED);
                else
                    return API.UNDEFINED;
            }

            if (st == API.SUCCESS)
            {
                try
                {
                    operationStatus = Connector.UniDriverGetData(deviceHandle, (uint)mode, ref bufferS16);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.Message.Contains("Unable to load DLL"))
                        return (API)(operationStatus = (uint)API.UNIDRIVER_DLLWASNOTLOADED);
                    else
                        return API.UNDEFINED;
                }
                st = (API)(operationStatus & MASK_RSH_ERROR);

                if (st != API.SUCCESS) return st;

                System.Runtime.InteropServices.Marshal.Copy(bufferS16.ptr, buffer, 0, (int)bufferS16.size);
            }

            return st;
        }
        public API GetData(ushort[] buffer, DATA_MODE mode = DATA_MODE.NO_FLAGS)
        {
            uint operationStatus;
            if (deviceHandle == IntPtr.Zero) return API.DEVICE_DLLWASNOTLOADED;

            API st = API.SUCCESS;


            try
            {
                st = (API)Connector.UniDriverAllocateBuffer(ref bufferU16, (uint)buffer.Length);
                tmpBufferShort = new short[buffer.Length];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                if (ex.Message.Contains("Unable to load DLL"))
                    return (API)(operationStatus = (uint)API.UNIDRIVER_DLLWASNOTLOADED);
                else
                    return API.UNDEFINED;
            }

            if (st == API.SUCCESS)
            {
                try
                {
                    operationStatus = Connector.UniDriverGetData(deviceHandle, (uint)mode, ref bufferU16);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.Message.Contains("Unable to load DLL"))
                        return (API)(operationStatus = (uint)API.UNIDRIVER_DLLWASNOTLOADED);
                    else
                        return API.UNDEFINED;
                }
                st = (API)(operationStatus & MASK_RSH_ERROR);

                if (st != API.SUCCESS) return st;

                System.Runtime.InteropServices.Marshal.Copy(bufferU16.ptr, tmpBufferShort, 0, (int)bufferU16.size);
                tmpBufferShort.CopyTo(buffer, 0);
            }

            return st;
        }
        public API GetData(double[] buffer, DATA_MODE mode = DATA_MODE.NO_FLAGS)
        {
            uint operationStatus;
            if (deviceHandle == IntPtr.Zero) return API.DEVICE_DLLWASNOTLOADED;

            API st = API.SUCCESS;


            try
            {
                st = (API)Connector.UniDriverAllocateBuffer(ref bufferDouble, (uint)buffer.Length);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                if (ex.Message.Contains("Unable to load DLL"))
                    return (API)(operationStatus = (uint)API.UNIDRIVER_DLLWASNOTLOADED);
                else
                    return API.UNDEFINED;
            }

            if (st == API.SUCCESS)
            {
                try
                {
                    operationStatus = Connector.UniDriverGetData(deviceHandle, (uint)mode, ref bufferDouble);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.Message.Contains("Unable to load DLL"))
                        return (API)(operationStatus = (uint)API.UNIDRIVER_DLLWASNOTLOADED);
                    else
                        return API.UNDEFINED;
                }
                st = (API)(operationStatus & MASK_RSH_ERROR);

                if (st != API.SUCCESS) return st;

                System.Runtime.InteropServices.Marshal.Copy(bufferDouble.ptr, buffer, 0, (int)bufferDouble.size);
            }

            return st;
        }
        public API SetData(short[] buffer, DATA_MODE mode = DATA_MODE.NO_FLAGS)
        {
            uint operationStatus;
            if (deviceHandle == IntPtr.Zero) return API.DEVICE_DLLWASNOTLOADED;

            API st = API.SUCCESS;


            try
            {
                st = (API)Connector.UniDriverAllocateBuffer(ref bufferS16, (uint)buffer.Length);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                if (ex.Message.Contains("Unable to load DLL"))
                    return (API)(operationStatus = (uint)API.UNIDRIVER_DLLWASNOTLOADED);
                else
                    return API.UNDEFINED;
            }

            if (st == API.SUCCESS)
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
                        return (API)(operationStatus = (uint)API.UNIDRIVER_DLLWASNOTLOADED);
                    else
                        return API.UNDEFINED;
                }
                st = (API)(operationStatus & MASK_RSH_ERROR);

                if (st != API.SUCCESS) return st;
            }

            return st;
        }

        /// <summary>
        /// Выборка параметров платы
        /// </summary>
        /// <param name="mode">Режим выборки данных</param>
        /// <param name="value">Если выбран режим выборки с входным параметром, то здесь необходимо его передавать на вход. Структуры из namespace Types</param>
        /// <returns>Возвращает данные в зависимости от выбранного режима</returns>
        public dynamic Get(GET mode, ValueType value = null)
        {
            API? result = null;
            return Get(mode, ref result, value);
        }

        delegate void ErrorHandlingDelegate(uint operationStatus, ref API? result);

        /// <summary>
        /// Выборка параметров платы
        /// </summary>
        /// <param name="mode">Режим выборки данных</param>
        /// <param name="result">Если нам надо узнать код/результат операции. Вызов с переданным null будет генерировать new RshDeviceException(API) если result!=API.SUCCESS</param>
        /// <param name="value">Если выбран режим выборки с входным параметром, то здесь необходимо его передавать на вход. Структуры из namespace Types</param>
        /// <returns>Возвращает данные в зависимости от выбранного режима</returns>
        public dynamic Get(GET mode, ref API? result, ValueType value = null)
        {
            if (deviceHandle == IntPtr.Zero)
                throw new RshDeviceException(API.DEVICE_DLLWASNOTLOADED);
                        
            //get metadata for selected mode
            var attr = (CorrespondingTypeAttribute) Attribute.GetCustomAttribute(
                typeof(GET).GetField(Enum.GetName(typeof(GET), mode)), 
                typeof(CorrespondingTypeAttribute)
                );

            bool input = attr.input;
            Type type = attr.type;
            if (input && value == null) 
                throw new ArgumentNullException("value must be provided for " + mode + " mode");

            ErrorHandlingDelegate ErrorHandling = (uint opStatus, ref API? res) =>
            {
                API st = (API)(opStatus & MASK_RSH_ERROR);
                if (res.HasValue)
                    res = st;
                else if (st != API.SUCCESS)
                    throw new RshDeviceException(st);
            };

            dynamic tmp = null;

            if (type == typeof(Types.S8P))
                tmp = input ? (Types.S8P)value : new Types.S8P(0);
            if (type == typeof(Types.U16P))
                tmp = input ? (Types.U16P)value : new Types.U16P(0);
            if (type == typeof(Types.Double))
                tmp = input ? (Types.Double)value : new Types.Double(0);
            if (type == typeof(Types.U32))
                tmp = input ? (Types.U32)value : new Types.U32(0);
            if (type == typeof(Types.S32))
                tmp = input ? (Types.S32)value : new Types.S32(0);

            int size = Marshal.SizeOf(tmp);
            IntPtr unmanagedAddr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(tmp, unmanagedAddr, true);
                
            var operationStatus = Connector.UniDriverGet(deviceHandle, (uint)mode, unmanagedAddr);
                
            tmp = Marshal.PtrToStructure(unmanagedAddr, type);
            Marshal.FreeHGlobal(unmanagedAddr);
            unmanagedAddr = IntPtr.Zero;

            ErrorHandling(operationStatus, ref result);
            
            if (type == typeof(Types.S8P))
                return Marshal.PtrToStringAnsi(tmp.data);
            if (type == typeof(Types.U16P))
                return Marshal.PtrToStringUni(tmp.data);
            if (type == typeof(Types.Double))
                return tmp.data;
            if (type == typeof(Types.U32))
                return tmp.data;
            if (type == typeof(Types.S32))
                return tmp.data;

            /*if (type == typeof(Types.BufferU32)) //TODO: Понять как работать с буферами
            {
                var tmp = new Types.BufferU32(0);                
                uint rec = 10;
                var operationStatus = Connector.UniDriverLVGetArrayUInt(deviceHandle, (uint)mode, 10, ref rec, ref tmp);
                ErrorHandling(operationStatus, ref result);
                //var vvv = Marshal.PtrToStructure(tmp.ptr,typeof(test));
                return tmp;
            }*/
            return null;
        }

        public bool IsCapable(CAPS caps)
        {
            API? result = API.SUCCESS;
            var tmp = new Types.U32(0) { data = (uint)caps };
            Get(GET.DEVICE_IS_CAPABLE, ref result, tmp);
            return result == API.SUCCESS;
        }       
       
        //public API Get(GET mode, ref BoardPortInfo value)
        //{
        //    uint operationStatus;
        //    if (deviceHandle == IntPtr.Zero) return API.DEVICE_DLLWASNOTLOADED;

        //    API st = API.SUCCESS;

        //    Types.BoardPortInfo tmp = new Types.BoardPortInfo(0);

        //    try
        //    {
        //        operationStatus = Connector.UniDriverGet(deviceHandle, (uint)mode, ref tmp);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        if (ex.Message.Contains("Unable to load DLL"))
        //            return (API)(operationStatus = (uint)API.UNIDRIVER_DLLWASNOTLOADED);
        //        else
        //            return API.UNDEFINED;
        //    }
        //    st = (API)(operationStatus & MASK_RSH_ERROR);

        //    if (st == API.SUCCESS)
        //    {
        //        if (tmp.totalConfs != 0)
        //        {
        //            value.confs = new PortInfo[tmp.totalConfs];
        //            for (int i = 0; i < value.confs.Length; i++)
        //            {
        //                value.confs[i] = new PortInfo();
        //                value.confs[i].address = tmp.confs[i].address;
        //                value.confs[i].bitSize = tmp.confs[i].bitSize;
        //                string str = System.Text.Encoding.UTF8.GetString(tmp.confs[i].name);
        //                value.confs[i].name = str.Substring(0, str.IndexOf('\0'));
        //            }
        //        }

        //        if (tmp.totalPorts != 0)
        //        {
        //            value.ports = new PortInfo[tmp.totalPorts];
        //            for (int i = 0; i < value.ports.Length; i++)
        //            {
        //                value.ports[i] = new PortInfo();
        //                value.ports[i].address = tmp.ports[i].address;
        //                value.ports[i].bitSize = tmp.ports[i].bitSize;
        //                string str = System.Text.Encoding.UTF8.GetString(tmp.ports[i].name);
        //                value.ports[i].name = str.Substring(0, str.IndexOf('\0'));
        //            }
        //        }
        //    }
        //    return st;
        //}
        
        public static API RshGetErrorDescription(API errorCode, out string value, LANGUAGE language)
        {
            value = "";
            uint os;
            API st = API.SUCCESS;

            Types.U16P tmp = new Types.U16P(0);
            try
            {
                os = Connector.UniDriverGetError((uint)errorCode, ref tmp, (uint)language);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                if (ex.Message.Contains("Unable to load DLL"))
                    return (API)(os = (uint)API.UNIDRIVER_DLLWASNOTLOADED);
                else
                    return API.UNDEFINED;
            }
            st = (API)(os & MASK_RSH_ERROR);
            if (st == API.SUCCESS)
                value = System.Runtime.InteropServices.Marshal.PtrToStringUni(tmp.data);

            return st;
        }
        
        public static API RshGetRegisteredDeviceName(uint index, out string value)
        {
            value = "";
            uint os;
            API st = API.SUCCESS;

            Types.U16P tmp = new Types.U16P(0);
            try
            {
                os = Connector.UniDriverGetRegisteredDeviceName(index, ref tmp);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                if (ex.Message.Contains("Unable to load DLL"))
                    return (API)(os = (uint)API.UNIDRIVER_DLLWASNOTLOADED);
                else
                    return API.UNDEFINED;
            }
            st = (API)(os & MASK_RSH_ERROR);
            if (st == API.SUCCESS)
                value = System.Runtime.InteropServices.Marshal.PtrToStringUni(tmp.data);

            return st;
        }
        
        /*
        public static API RshGetRegisteredDeviceName(uint index, out string[] value)
        {
                
            uint os;
            API st = API.SUCCESS;

            uint ind = 0;
            while (true)
            {

                string value;

                st = Device.RshGetRegisteredDeviceName(ind++, out value);
                if (st != API.SUCCESS) break;

                Console.WriteLine(value);
            }

            return st;
        }*/
    };
}
