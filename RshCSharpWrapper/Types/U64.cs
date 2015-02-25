using System;
using System.Runtime.InteropServices;

namespace RshCSharpWrapper.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct U64
    {
        private Names type; // data code
        public UInt64 data;
        public U64(UInt64 data)
        {
            type = Names.U64;
            this.data = data;
        }
    };
}
