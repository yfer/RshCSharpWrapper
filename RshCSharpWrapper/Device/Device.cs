using System.Linq;
using RshCSharpWrapper.Types;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace RshCSharpWrapper.Device
{
    public class Device : IDisposable
    {
        private readonly Connector.DeviceHandle _handle;
        private BufferS8 bufferS8;
        private BufferS16 bufferS16;
        private BufferU16 bufferU16;
        private BufferS32 bufferS32;
        private BufferU32 bufferU32;
        private BufferDouble bufferDouble;

        private short[] tmpBufferShort = new short[1]; // буфер используется в GetData для копирования данных типа unsigned
        private int[] tmpBufferInt = new int[1];
        private double[] tmpBufferDouble = new double[1];

        private Device()
        {
            bufferS8 = new BufferS8(0);
            bufferS16 = new BufferS16(0);
            bufferU16 = new BufferU16(0);
            bufferS32 = new BufferS32(0);
            bufferU32 = new BufferU32();
            bufferDouble = new BufferDouble(0);
        }
        public Device(string deviceName):this()
        {
            Connector.GetDeviceHandle(deviceName, out _handle).ThrowIfNotSuccess();
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

            Connector.UniDriverFreeBuffer(ref bufferS8);
            Connector.UniDriverFreeBuffer(ref bufferS16);
            Connector.UniDriverFreeBuffer(ref bufferU16);
            Connector.UniDriverFreeBuffer(ref bufferS32);
            Connector.UniDriverFreeBuffer(ref bufferU32);
            Connector.UniDriverFreeBuffer(ref bufferDouble);
            Connector.CloseDeviceHandle(_handle).ThrowIfNotSuccess();

            disposed = true;
        }
        #endregion
       
        /// <summary>
        /// Подключиться к устройству
        /// </summary>
        /// <param name="id">Базовый адрес или серийный номер, выбирается режимом во втором параметре.</param>
        /// <param name="mode">Режим подключения, по базовому адресу(по умолчанию) или по серийному номеру.</param>
        public void Connect(uint id = 1, CONNECT_MODE mode = CONNECT_MODE.BASE)
        {            
            Connector.Connect(_handle, id, mode).ThrowIfNotSuccess();
        }

        //public API Init(InitDMA initStructure, INIT_MODE mode = INIT_MODE.INIT)
        //{
        //    uint operationStatus;
        //    if (deviceHandle == IntPtr.Zero) return API.DEVICE_DLLWASNOTLOADED;

        //    Types.InitDMA iS = new Types.InitDMA(0); // для вызова своего конструктора

        //    iS.bufferSize = initStructure.bufferSize;
        //    iS.control = initStructure.control;
        //    iS.dmaMode = initStructure.dmaMode;
        //    iS.frequency = initStructure.frequency;
        //    iS.frequencyPack = initStructure.frequencyPack;
        //    iS.startType = initStructure.startType;
        //    iS.threshold = initStructure.threshold;
        //    iS.controlSynchro = initStructure.controlSynchro;

        //    for (int i = 0; i < initStructure.channels.Length; i++)
        //    {
        //        iS.channels[i].control = initStructure.channels[i].control;
        //        iS.channels[i].gain = initStructure.channels[i].gain;
        //        iS.channels[i].delta = initStructure.channels[i].delta;
        //    }
        //    try
        //    {
        //        operationStatus = Connector.UniDriverInit(deviceHandle, (uint)mode, ref iS);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        if (ex.Message.Contains("Unable to load DLL"))
        //            return (API)(operationStatus = (uint)API.UNIDRIVER_DLLWASNOTLOADED);
        //        else
        //            return API.UNDEFINED;
        //    }
        //    API st = (API)(operationStatus & MASK_RSH_ERROR);

        //    if (st == API.SUCCESS)
        //    {
        //        initStructure.bufferSize = iS.bufferSize;
        //        initStructure.control = iS.control;
        //        initStructure.dmaMode = iS.dmaMode;
        //        initStructure.frequency = iS.frequency;
        //        initStructure.frequencyPack = iS.frequencyPack;
        //        initStructure.startType = iS.startType;
        //        initStructure.threshold = iS.threshold;
        //        initStructure.controlSynchro = iS.controlSynchro;

        //        for (int i = 0; i < initStructure.channels.Length; i++)
        //        {
        //            initStructure.channels[i].control = iS.channels[i].control;
        //            initStructure.channels[i].gain = iS.channels[i].gain;
        //            initStructure.channels[i].delta = iS.channels[i].delta;
        //        }
        //    }

        //    return st;
        //}

        public API Init(InitMemory initStructure, INIT_MODE mode = INIT_MODE.INIT)
        {
            API operationStatus;
            if (_handle == IntPtr.Zero) return API.DEVICE_DLLWASNOTLOADED;

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
                operationStatus = Connector.Init(_handle, (uint)mode, ref iS);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                if (ex.Message.Contains("Unable to load DLL"))
                    return API.UNIDRIVER_DLLWASNOTLOADED;
                return API.UNDEFINED;
            }
            
            if (operationStatus == API.SUCCESS)
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

            return operationStatus;
        }
        
        //public API Init(InitGSPF initStructure, INIT_MODE mode = INIT_MODE.INIT)
        //{
        //    uint operationStatus;
        //    if (deviceHandle == IntPtr.Zero) return API.DEVICE_DLLWASNOTLOADED;

        //    Types.InitGSPF iS = new Types.InitGSPF(0);

        //    iS.attenuator = (uint)initStructure.attenuator;
        //    iS.control = initStructure.control;
        //    iS.frequency = initStructure.frequency;
        //    iS.startType = initStructure.startType;

        //    try
        //    {
        //        operationStatus = Connector.UniDriverInit(deviceHandle, (uint)mode, ref iS);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        if (ex.Message.Contains("Unable to load DLL"))
        //            return (API)(operationStatus = (uint)API.UNIDRIVER_DLLWASNOTLOADED);
        //        else
        //            return API.UNDEFINED;
        //    }
        //    API st = (API)(operationStatus & MASK_RSH_ERROR);

        //    if (st == API.SUCCESS)
        //    {
        //        initStructure.attenuator = (InitGSPF.AttenuatorBit)iS.attenuator;
        //        initStructure.control = iS.control;
        //        initStructure.frequency = iS.frequency;
        //        initStructure.startType = iS.startType;
        //    }

        //    return st;
        //}
        //public API Init(InitVoltmeter initStructure, INIT_MODE mode = INIT_MODE.INIT)
        //{
        //    uint operationStatus;
        //    if (deviceHandle == IntPtr.Zero) return API.DEVICE_DLLWASNOTLOADED;

        //    Types.InitVoltmeter iS = new Types.InitVoltmeter(0);

        //    iS.bufferSize = initStructure.bufferSize;
        //    iS.control = initStructure.control;
        //    iS.filter = initStructure.filter;
        //    iS.startType = initStructure.startType;

        //    try
        //    {
        //        operationStatus = Connector.UniDriverInit(deviceHandle, (uint)mode, ref iS);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        if (ex.Message.Contains("Unable to load DLL"))
        //            return (API)(operationStatus = (uint)API.UNIDRIVER_DLLWASNOTLOADED);
        //        else
        //            return API.UNDEFINED;
        //    }
        //    API st = (API)(operationStatus & MASK_RSH_ERROR);

        //    if (st == API.SUCCESS)
        //    {
        //        initStructure.bufferSize = iS.bufferSize;
        //        initStructure.control = iS.control;
        //        initStructure.filter = iS.filter;
        //        initStructure.startType = iS.startType;
        //    }

        //    return st;
        //}
        //public API Init(InitPort initStructure, INIT_MODE mode = INIT_MODE.INIT)
        //{
        //    uint operationStatus;
        //    if (deviceHandle == IntPtr.Zero) return API.DEVICE_DLLWASNOTLOADED;

        //    Types.InitPort iS = new Types.InitPort(0);

        //    iS.operationType = (uint)initStructure.operationType;
        //    iS.portAddress = initStructure.portAddress;
        //    iS.portValue = initStructure.portValue;

        //    try
        //    {
        //        operationStatus = Connector.UniDriverInit(deviceHandle, (uint)mode, ref iS);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        if (ex.Message.Contains("Unable to load DLL"))
        //            return (API)(operationStatus = (uint)API.UNIDRIVER_DLLWASNOTLOADED);
        //        else
        //            return API.UNDEFINED;
        //    }
        //    API st = (API)(operationStatus & MASK_RSH_ERROR);

        //    if (st == API.SUCCESS)
        //    {
        //        initStructure.operationType = (InitPort.OperationTypeBit)iS.operationType;
        //        initStructure.portAddress = iS.portAddress;
        //        initStructure.portValue = iS.portValue;
        //    }

        //    return st;
        //}
        //public API Init(InitDAC initStructure, INIT_MODE mode = INIT_MODE.INIT)
        //{
        //    uint operationStatus;
        //    if (deviceHandle == IntPtr.Zero) return API.DEVICE_DLLWASNOTLOADED;

        //    Types.InitDAC iS = new Types.InitDAC(0);

        //    iS.id = initStructure.id;
        //    iS.voltage = initStructure.voltage;

        //    try
        //    {
        //        operationStatus = Connector.UniDriverInit(deviceHandle, (uint)mode, ref iS);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        if (ex.Message.Contains("Unable to load DLL"))
        //            return (API)(operationStatus = (uint)API.UNIDRIVER_DLLWASNOTLOADED);
        //        else
        //            return API.UNDEFINED;
        //    }
        //    API st = (API)(operationStatus & MASK_RSH_ERROR);

        //    if (st == API.SUCCESS)
        //    {
        //        initStructure.id = iS.id;
        //        initStructure.voltage = iS.voltage;
        //    }

        //    return st;
        //}

        public void Start()
        {
            Connector.Start(_handle).ThrowIfNotSuccess();
        }
        public void Stop()
        {
            Connector.Stop(_handle).ThrowIfNotSuccess();        
        }

        //public API GetData(int[] buffer, DATA_MODE mode = DATA_MODE.NO_FLAGS)
        //{
        //    uint operationStatus;
        //    if (deviceHandle == IntPtr.Zero) return API.DEVICE_DLLWASNOTLOADED;

        //    API st = API.SUCCESS;

        //    try
        //    {
        //        st = (API)Connector.UniDriverAllocateBuffer(ref bufferS32, (uint)buffer.Length);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        if (ex.Message.Contains("Unable to load DLL"))
        //            return (API)(operationStatus = (uint)API.UNIDRIVER_DLLWASNOTLOADED);
        //        else
        //            return API.UNDEFINED;
        //    }

        //    if (st == API.SUCCESS)
        //    {

        //        try
        //        {
        //            operationStatus = Connector.UniDriverGetData(deviceHandle, (uint)mode, ref bufferS32);
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex.Message);
        //            if (ex.Message.Contains("Unable to load DLL"))
        //                return (API)(operationStatus = (uint)API.UNIDRIVER_DLLWASNOTLOADED);
        //            else
        //                return API.UNDEFINED;
        //        }
        //        st = (API)(operationStatus & MASK_RSH_ERROR);

        //        if (st != API.SUCCESS) return st;

        //        System.Runtime.InteropServices.Marshal.Copy(bufferS32.ptr, buffer, 0, (int)bufferS32.size);
        //    }

        //    return st;
        //}
        //public API GetData(byte[] buffer, DATA_MODE mode = DATA_MODE.NO_FLAGS)
        //{
        //    uint operationStatus;
        //    if (deviceHandle == IntPtr.Zero) return API.DEVICE_DLLWASNOTLOADED;

        //    API st = API.SUCCESS;


        //    try
        //    {
        //        st = (API)Connector.UniDriverAllocateBuffer(ref bufferS8, (uint)buffer.Length);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        if (ex.Message.Contains("Unable to load DLL"))
        //            return (API)(operationStatus = (uint)API.UNIDRIVER_DLLWASNOTLOADED);
        //        else
        //            return API.UNDEFINED;
        //    }

        //    if (st == API.SUCCESS)
        //    {
        //        try
        //        {
        //            operationStatus = Connector.UniDriverGetData(deviceHandle, (uint)mode, ref bufferS8);
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex.Message);
        //            if (ex.Message.Contains("Unable to load DLL"))
        //                return (API)(operationStatus = (uint)API.UNIDRIVER_DLLWASNOTLOADED);
        //            else
        //                return API.UNDEFINED;
        //        }
        //        st = (API)(operationStatus & MASK_RSH_ERROR);

        //        if (st != API.SUCCESS) return st;

                
        //        System.Runtime.InteropServices.Marshal.Copy(bufferS8.ptr, buffer, 0, (int)bufferS8.size);
        //    }

        //    return st;
        //}

        //public API GetData(short[] buffer, DATA_MODE mode = DATA_MODE.NO_FLAGS)
        //{
        //    uint operationStatus;
        //    if (deviceHandle == IntPtr.Zero) return API.DEVICE_DLLWASNOTLOADED;

        //    API st = API.SUCCESS;


        //    try
        //    {
        //        st = (API)Connector.UniDriverAllocateBuffer(ref bufferS16, (uint)buffer.Length);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        if (ex.Message.Contains("Unable to load DLL"))
        //            return (API)(operationStatus = (uint)API.UNIDRIVER_DLLWASNOTLOADED);
        //        else
        //            return API.UNDEFINED;
        //    }

        //    if (st == API.SUCCESS)
        //    {
        //        try
        //        {
        //            operationStatus = Connector.UniDriverGetData(deviceHandle, (uint)mode, ref bufferS16);
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex.Message);
        //            if (ex.Message.Contains("Unable to load DLL"))
        //                return (API)(operationStatus = (uint)API.UNIDRIVER_DLLWASNOTLOADED);
        //            else
        //                return API.UNDEFINED;
        //        }
        //        st = (API)(operationStatus & MASK_RSH_ERROR);

        //        if (st != API.SUCCESS) return st;

        //        System.Runtime.InteropServices.Marshal.Copy(bufferS16.ptr, buffer, 0, (int)bufferS16.size);
        //    }

        //    return st;
        //}
        //public API GetData(char[] buffer, DATA_MODE mode = DATA_MODE.NO_FLAGS)
        //{
        //    uint operationStatus;
        //    if (deviceHandle == IntPtr.Zero) return API.DEVICE_DLLWASNOTLOADED;

        //    API st = API.SUCCESS;


        //    try
        //    {
        //        st = (API)Connector.UniDriverAllocateBuffer(ref bufferS8, (uint)buffer.Length);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        if (ex.Message.Contains("Unable to load DLL"))
        //            return (API)(operationStatus = (uint)API.UNIDRIVER_DLLWASNOTLOADED);
        //        else
        //            return API.UNDEFINED;
        //    }

        //    if (st == API.SUCCESS)
        //    {
        //        try
        //        {
        //            operationStatus = Connector.UniDriverGetData(deviceHandle, (uint)mode, ref bufferS8);
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex.Message);
        //            if (ex.Message.Contains("Unable to load DLL"))
        //                return (API)(operationStatus = (uint)API.UNIDRIVER_DLLWASNOTLOADED);
        //            else
        //                return API.UNDEFINED;
        //        }
        //        st = (API)(operationStatus & MASK_RSH_ERROR);

        //        if (st != API.SUCCESS) return st;

        //        System.Runtime.InteropServices.Marshal.Copy(bufferS8.ptr, buffer, 0, (int)bufferS8.size);
        //    }

        //    return st;
        //}
        //public API GetData(ushort[] buffer, DATA_MODE mode = DATA_MODE.NO_FLAGS)
        //{
        //    uint operationStatus;
        //    if (deviceHandle == IntPtr.Zero) return API.DEVICE_DLLWASNOTLOADED;

        //    API st = API.SUCCESS;


        //    try
        //    {
        //        st = (API)Connector.UniDriverAllocateBuffer(ref bufferU16, (uint)buffer.Length);
        //        tmpBufferShort = new short[buffer.Length];
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        if (ex.Message.Contains("Unable to load DLL"))
        //            return (API)(operationStatus = (uint)API.UNIDRIVER_DLLWASNOTLOADED);
        //        else
        //            return API.UNDEFINED;
        //    }

        //    if (st == API.SUCCESS)
        //    {
        //        try
        //        {
        //            operationStatus = Connector.UniDriverGetData(deviceHandle, (uint)mode, ref bufferU16);
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex.Message);
        //            if (ex.Message.Contains("Unable to load DLL"))
        //                return (API)(operationStatus = (uint)API.UNIDRIVER_DLLWASNOTLOADED);
        //            else
        //                return API.UNDEFINED;
        //        }
        //        st = (API)(operationStatus & MASK_RSH_ERROR);

        //        if (st != API.SUCCESS) return st;

        //        System.Runtime.InteropServices.Marshal.Copy(bufferU16.ptr, tmpBufferShort, 0, (int)bufferU16.size);
        //        tmpBufferShort.CopyTo(buffer, 0);
        //    }

        //    return st;
        //}
        //public API GetData(double[] buffer, DATA_MODE mode = DATA_MODE.NO_FLAGS)
        //{
        //    uint operationStatus;
        //    if (deviceHandle == IntPtr.Zero) return API.DEVICE_DLLWASNOTLOADED;

        //    API st = API.SUCCESS;


        //    try
        //    {
        //        st = (API)Connector.UniDriverAllocateBuffer(ref bufferDouble, (uint)buffer.Length);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        if (ex.Message.Contains("Unable to load DLL"))
        //            return (API)(operationStatus = (uint)API.UNIDRIVER_DLLWASNOTLOADED);
        //        else
        //            return API.UNDEFINED;
        //    }

        //    if (st == API.SUCCESS)
        //    {
        //        try
        //        {
        //            operationStatus = Connector.UniDriverGetData(deviceHandle, (uint)mode, ref bufferDouble);
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex.Message);
        //            if (ex.Message.Contains("Unable to load DLL"))
        //                return (API)(operationStatus = (uint)API.UNIDRIVER_DLLWASNOTLOADED);
        //            else
        //                return API.UNDEFINED;
        //        }
        //        st = (API)(operationStatus & MASK_RSH_ERROR);

        //        if (st != API.SUCCESS) return st;

        //        System.Runtime.InteropServices.Marshal.Copy(bufferDouble.ptr, buffer, 0, (int)bufferDouble.size);
        //    }

        //    return st;
        //}
        //public API SetData(short[] buffer, DATA_MODE mode = DATA_MODE.NO_FLAGS)
        //{
        //    uint operationStatus;
        //    if (deviceHandle == IntPtr.Zero) return API.DEVICE_DLLWASNOTLOADED;

        //    API st = API.SUCCESS;


        //    try
        //    {
        //        st = (API)Connector.UniDriverAllocateBuffer(ref bufferS16, (uint)buffer.Length);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        if (ex.Message.Contains("Unable to load DLL"))
        //            return (API)(operationStatus = (uint)API.UNIDRIVER_DLLWASNOTLOADED);
        //        else
        //            return API.UNDEFINED;
        //    }

        //    if (st == API.SUCCESS)
        //    {
        //        try
        //        {
        //            System.Runtime.InteropServices.Marshal.Copy(buffer, 0, bufferS16.ptr, buffer.Length);
        //            operationStatus = Connector.UniDriverGetData(deviceHandle, (uint)mode, ref bufferS16);
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex.Message);
        //            if (ex.Message.Contains("Unable to load DLL"))
        //                return (API)(operationStatus = (uint)API.UNIDRIVER_DLLWASNOTLOADED);
        //            else
        //                return API.UNDEFINED;
        //        }
        //        st = (API)(operationStatus & MASK_RSH_ERROR);

        //        if (st != API.SUCCESS) return st;
        //    }

        //    return st;
        //}

        public T Get<T>(GET mode, object param = null)
        {
            return (T)Get(mode, param);
        }

        /// <summary>
        /// Выборка параметров платы
        /// </summary>
        /// <param name="mode">Режим выборки данных</param>
        /// <param name="param">Если выбран режим выборки с входным параметром, то здесь необходимо его передавать на вход. Структуры из namespace Types</param>
        /// <returns>Возвращает данные в зависимости от выбранного режима</returns>
        public dynamic Get(GET mode, object param = null)
        {
            var api = API.SUCCESS;
            _handle.ThrowIfDeviceHandleNotOK();

            //Выясняем параметры работы выбранного режима
            var modeAttr = (ModeAttribute)Attribute.GetCustomAttribute(
                mode.GetType().GetField(mode.ToString()),
                typeof(ModeAttribute) 
                );

            if (modeAttr == null)
                throw new InvalidOperationException("We don't have information on this mode, communicate with developer to solve.");
            if (modeAttr.Input == (param == null))
                throw new InvalidOperationException("Does this mode wait 'param'? :" + modeAttr.Input + " but param is " + param);
            
            //Для передачи в RshUniDriver, в соответствии с типом данных с которым работает данная настройка.
            dynamic tmp = Activator.CreateInstance(modeAttr.Type);

            //Обращение к RshUniDriver и возвращение результата из неуправляемой памят
            var unmanagedAddr = Marshal.AllocHGlobal(Marshal.SizeOf(tmp));
            Marshal.StructureToPtr(tmp, unmanagedAddr, true);
            if (tmp is IBuffer)
                api = Connector.AllocateBuffer(unmanagedAddr, 32);
            if (api == API.SUCCESS)
                api = Connector.Get(_handle, mode, unmanagedAddr);            
            tmp = Marshal.PtrToStructure(unmanagedAddr, modeAttr.Type);
            var ret = tmp.ReturnValue();
            if (tmp is IBuffer)
                Connector.FreeBuffer(unmanagedAddr);
            Marshal.FreeHGlobal(unmanagedAddr);
            unmanagedAddr = IntPtr.Zero;

            api.ThrowIfNotSuccess();

            return ret;
            //Что возвращаем?
            //switch (mode_attr.Name)
            //{
            //    case Types.Names.BoardPortInfo:
            //        if (tmp.totalConfs != 0)
            //        {
            //            tmp.confs = new PortInfo[tmp.totalConfs];
            //            for (int i = 0; i < tmp.confs.Length; i++)
            //            {
            //                tmp.confs[i] = new PortInfo();
            //                tmp.confs[i].address = tmp.confs[i].address;
            //                tmp.confs[i].bitSize = tmp.confs[i].bitSize;
            //                string str = System.Text.Encoding.UTF8.GetString(tmp.confs[i].name);
            //                tmp.confs[i].name = str.Substring(0, str.IndexOf('\0'));
            //            }
            //        }

            //        if (tmp.totalPorts != 0)
            //        {
            //            tmp.ports = new PortInfo[tmp.totalPorts];
            //            for (int i = 0; i < tmp.ports.Length; i++)
            //            {
            //                tmp.ports[i] = new PortInfo();
            //                tmp.ports[i].address = tmp.ports[i].address;
            //                tmp.ports[i].bitSize = tmp.ports[i].bitSize;
            //                string str = System.Text.Encoding.UTF8.GetString(tmp.ports[i].name);
            //                tmp.ports[i].name = str.Substring(0, str.IndexOf('\0'));
            //            }
            //        }
            //        return tmp;
            //    default:
            //        return null;
            //}


            /*if (type == typeof(Types.BufferU32)) //TODO: Понять как работать с буферами
            {
                var tmp = new Types.BufferU32(0);                
                uint rec = 10;
                var operationStatus = Connector.UniDriverLVGetArrayUInt(deviceHandle, (uint)mode, 10, ref rec, ref tmp);
                ErrorHandling(operationStatus, ref result);
                //var vvv = Marshal.PtrToStructure(tmp.ptr,typeof(test));
                return tmp;
            }*/
        }

        /// <summary>
        /// Выяснить возможности платы
        /// </summary>
        /// <param name="caps">Какая возможность интересует</param>
        /// <returns>Поддерживается ли возможность</returns>
        public bool IsCapable(CAPS caps)
        {
            var tmp = new U32 { data = (uint)caps };
            try
            {
                Get(GET.DEVICE_IS_CAPABLE, tmp);
                return true;
            }
            catch (RshDeviceException ex)
            {
                return false;
            }            
        }       
                
        public static List<string> GetRegisteredDeviceNames()
        {
            return Connector.GetRegisteredDeviceNames().ToList();
        }
    };
}
