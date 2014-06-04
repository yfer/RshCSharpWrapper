using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace RshCSharpWrapper.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct RshInitGSPF
    {
        private Names typeName;     // data code				URshInitMemoryType

        public uint startType;	//!< тип запуска платы
        public double frequency;	//!< частота 
        public uint attenuator;		//!<
        public uint control;	//!< настройки платы
        public RshInitGSPF(UInt32 st)
        {
            typeName = Names.rshInitGSPF;
            startType = 0;	//!< тип запуска платы
            control = attenuator = 0;
            frequency = 0;
        }
    } ;
}
