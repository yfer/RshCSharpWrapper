using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace RshCSharpWrapper.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class InitMemory : IInit
    {
        /// <summary>
        /// data code URshInitMemoryType
        /// </summary>
        private Names typeName = Names.InitMemory;     
        
        /// <summary>
        /// Настройки типа старта платы
        /// </summary>
        internal uint startType = 0;	

        public StartType StartType
        {
            get { return (StartType)startType; }
            set { startType = (uint)value; }
        }        

        public uint bufferSize = 0;	 // !< размер буфера в отсчётах (значение пересчитывается при инициализации в зависимости от сопутствующих настроек)
        public double frequency = 0;	// !< частота дискретизации	

        internal uint control = 0;

        public Control Control
        {
            get { return (Control) control; }
            set { control = (uint)value; }
        }        

        public uint beforeHistory = 0;	//!< размер предыстории, может принимать значения от 0 до 15
        public uint startDelay = 0;		//!< задержка старта
        public uint hysteresis = 0;		//!< гистеризис
        public uint packetNumber = 0;	//!< количество пакетов размера bufferSize

        public double threshold = 0;		//!< уровень синхронизации в Вольтах
        internal uint controlSynchro = 0;	//!< специфические настройки синхронизации

        public ControlSynchro ControlSynchro
        {
            get { return (ControlSynchro)controlSynchro; }
            set { controlSynchro = (uint)value; }
        }

        public double Frequency
        {
            get { return frequency; }
            set { frequency = value; }
        }

        public SynchroChannel channelSynchro = new SynchroChannel(); //<! настройки канала внешней синхронизации

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public Channel[] channels = new Channel[32]; // параметры каналов

    };
}
