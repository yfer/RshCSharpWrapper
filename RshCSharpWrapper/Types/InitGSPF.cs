using System;
using System.Runtime.InteropServices;

namespace RshCSharpWrapper.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct InitGSPF
    {
        private Names typeName;     // data code				URshInitMemoryType

        public uint startType;	//!< тип запуска платы
        public double frequency;	//!< частота 
        public uint attenuator;		//!<
        public uint control;	//!< настройки платы
        public InitGSPF(UInt32 st)
        {
            typeName = Names.InitGSPF;
            startType = 0;	//!< тип запуска платы
            control = attenuator = 0;
            frequency = 0;
        }
    } ;
}
