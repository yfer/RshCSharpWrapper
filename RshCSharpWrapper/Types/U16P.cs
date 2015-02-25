using System;
using System.Runtime.InteropServices;

namespace RshCSharpWrapper.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct U16P
    {
        private Names type; // data code
        public IntPtr data;
        public U16P(Int32 data)
        {
            type = Names.U16P;
            this.data = IntPtr.Zero;
        }
    };
}
