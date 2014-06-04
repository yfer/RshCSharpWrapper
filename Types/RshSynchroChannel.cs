using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace RshCSharpWrapper.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct RshSynchroChannel   // настройка канала платы
    {
        public uint gain;		//!< коэффициент усиления
        public uint control;	//!< специфические настройки канала        
    };

}
