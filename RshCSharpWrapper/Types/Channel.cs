using System.Runtime.InteropServices;

namespace RshCSharpWrapper.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct Channel   // настройка канала платы
    {
        public uint gain;		//!< коэффициент усиления
        public uint control;	//!< специфические настройки канала        
        public double delta;		//!< смещениe (в вольтах)
    };
}
