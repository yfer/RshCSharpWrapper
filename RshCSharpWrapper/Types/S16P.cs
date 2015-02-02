using System;
using System.Runtime.InteropServices;

namespace RshCSharpWrapper.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct S16P
    {
        private Names type; // data code
        public IntPtr data;
        public S16P(Int32 data)
        {
            type = Names.S16P;
            this.data = IntPtr.Zero;
        }
    };
}
