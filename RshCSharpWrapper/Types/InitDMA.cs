using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace RshCSharpWrapper.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct InitDMA
    {
        private Names typeName;     // data code				URshInitMemoryType

        public uint startType;	// !< настройки типа старта платы
        public uint bufferSize;	// !< размер буфера в отсчётах (значение пересчитывается при инициализации в зависимости от сопутствующих настроек)
        public double frequency;	// !< частота дискретизации	

        public uint dmaMode;    //!< режим работы DMA	

        public uint control;	//!< специфические настройки для данного типа плат (например, диф режим)
        public double frequencyPack;		// !< частота дискретизации	внутри пачки

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public Channel[] channels; // параметры каналов

        public double threshold;		//!< уровень синхронизации в Вольтах
        public uint controlSynchro;	//!< специфические настройки синхронизации

        public InitDMA(UInt32 st)
        {
            typeName = Names.InitDMA;
            startType = 0;
            control = bufferSize = dmaMode = 0;
            frequency = frequencyPack = 0;
            threshold = 0.0;
            controlSynchro = 0;
            channels = new Channel[32];
        }
    };
}
