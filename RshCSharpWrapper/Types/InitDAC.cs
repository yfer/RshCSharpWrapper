using System;
using System.Runtime.InteropServices;

namespace RshCSharpWrapper.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct InitDAC
    {
        private Names typeName;     // data code				URshInitDAC

        public uint id;  //!< Идентификатор ЦАПа
        public double voltage;   //!< Напряжение, которое нужно выдать на ЦАП

        public InitDAC(UInt32 ot)
        {
            typeName = Names.InitDAC;
            id = 0;
            voltage = 0;
        }
    };
}
