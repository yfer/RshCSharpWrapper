using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RshCSharpWrapper.RshDevice
{
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
}
