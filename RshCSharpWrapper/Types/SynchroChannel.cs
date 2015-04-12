using System.Runtime.InteropServices;

namespace RshCSharpWrapper.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SynchroChannel   // настройка канала платы
    {
        public uint gain;		//!< коэффициент усиления
        public uint control;	//!< специфические настройки канала        
    };
}
