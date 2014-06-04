using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RshCSharpWrapper.RshDevice
{
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
}
