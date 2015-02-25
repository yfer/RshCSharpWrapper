using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace RshCSharpWrapper.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct InitMemory
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

        public SynchroChannel channelSynchro; //<! настройки канала внешней синхронизации

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public Channel[] channels; // параметры каналов

        public InitMemory(UInt32 st)
        {
            typeName = Names.InitMemory;
            startType = 0;
            control = bufferSize = controlSynchro = 0;
            frequency = threshold = 0;
            beforeHistory = startDelay = startDelay = hysteresis = packetNumber = 0;
            channelSynchro = new SynchroChannel();
            channels = new Channel[32];
        }
    };
}
