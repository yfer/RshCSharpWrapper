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

        public Device(string deviceName)
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

        public void Init(IInit initStructure, INIT_MODE mode = INIT_MODE.INIT)
        {  
            _handle.ThrowIfDeviceHandleNotOK();
            var size = Marshal.SizeOf(initStructure.GetType());
            var buff = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(initStructure, buff, true);
            var api = Connector.Init(_handle, mode, buff);
            Marshal.PtrToStructure(buff, initStructure);
            Marshal.FreeHGlobal(buff);
            api.ThrowIfNotSuccess();
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

        public enum DataTypeEnum
        {
            Int8,
            UInt8,
            Int16,
            //UInt16,
            Int32,
            //UInt32,
            Double
        }
        public dynamic GetData(DataTypeEnum type, uint size, DATA_MODE mode = DATA_MODE.NO_FLAGS)
        {
            _handle.ThrowIfDeviceHandleNotOK();

            dynamic buffer;
            switch (type)
            {
                case DataTypeEnum.Int8:
                    buffer = new BufferS8();
                    break;
                case DataTypeEnum.UInt8:
                    buffer = new BufferS8();
                    break;
                case DataTypeEnum.Int16:
                    buffer = new BufferS16();
                break;
                //case DataTypEnum.UInt16:
                //    buffer = new BufferU16();
                //break;
                case DataTypeEnum.Int32:
                    buffer = new BufferS32();
                break;
                //case DataTypEnum.UInt32:
                //    buffer = new BufferU32();
                //break;
                case DataTypeEnum.Double:
                    buffer = new BufferDouble();
                break;
                default:
                    throw new InvalidOperationException();
            }
            
            IntPtr bufptr = Marshal.AllocHGlobal(Marshal.SizeOf(buffer));
            Marshal.StructureToPtr(buffer, bufptr, true);
            Connector.AllocateBuffer(bufptr, size).ThrowIfNotSuccess();
            Connector.GetData(_handle, mode, bufptr).ThrowIfNotSuccess();
            switch (type)
            {
                case DataTypeEnum.Int8:
                    buffer = Marshal.PtrToStructure(bufptr, typeof(BufferS8));
                    break;
                case DataTypeEnum.UInt8:
                    buffer = Marshal.PtrToStructure(bufptr, typeof(BufferU8));
                    break;
                case DataTypeEnum.Int16:
                    buffer = Marshal.PtrToStructure(bufptr, typeof(BufferS16));
                    break;
                //case DataTypEnum.UInt16:
                //    buffer = Marshal.PtrToStructure(bufptr, typeof(BufferU16));
                //    break;
                case DataTypeEnum.Int32:
                    buffer = Marshal.PtrToStructure(bufptr, typeof(BufferS32));
                    break;
                //case DataTypEnum.UInt32:
                //    buffer = Marshal.PtrToStructure(bufptr, typeof(BufferU32));
                //    break;
                case DataTypeEnum.Double:
                    buffer = Marshal.PtrToStructure(bufptr, typeof(BufferDouble));
                    break;
            }
            var ret = buffer.ReturnValue();
            Connector.FreeBuffer(bufptr).ThrowIfNotSuccess();
            return ret;
        }
        
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
            dynamic tmp = param ?? Activator.CreateInstance(modeAttr.Type);

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
