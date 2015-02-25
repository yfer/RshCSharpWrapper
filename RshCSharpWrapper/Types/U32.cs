using System;
using System.Runtime.InteropServices;

namespace RshCSharpWrapper.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct U32
    {
        private Names type; // data code
        public UInt32 data;
        public U32(UInt32 data)
        {
            type = Names.U32;
            this.data = data;
        }
    };
}
