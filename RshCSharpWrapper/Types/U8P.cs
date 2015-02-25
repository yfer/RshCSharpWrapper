using System;
using System.Runtime.InteropServices;

namespace RshCSharpWrapper.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct U8P
    {
        private Names type; // data code
        public IntPtr data;
        public U8P(Int32 data)
        {
            type = Names.U8P;
            this.data = IntPtr.Zero;
        }
    };
}
