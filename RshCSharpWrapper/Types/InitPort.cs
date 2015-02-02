using System;
using System.Runtime.InteropServices;

namespace RshCSharpWrapper.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct InitPort
    {
        private Names typeName;     // data code				URshInitMemoryType

        public uint operationType;  //!< Read, Write, Mask with And, OR
        public uint portAddress;   //!< port number
        public uint portValue;     //!< port value

        public InitPort(UInt32 ot)
        {
            typeName = Names.InitPort;
            operationType = portAddress = portValue = 0;
        }
    };
}
