using System;
using System.Runtime.InteropServices;

namespace RshCSharpWrapper.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct U16
    {
        private Names typeName; // data code
        public UInt16 data;
        public U16(UInt16 data)
        {
            typeName = Names.U16;
            this.data = data;
        }
    };
}
