using System;
using System.Runtime.InteropServices;

namespace RshCSharpWrapper.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct S8P
    {
        private Names type; // data code
        public IntPtr data;
        public S8P(Int32 data)
        {
            type = Names.S8P;
            this.data = IntPtr.Zero;
        }
    };
}
