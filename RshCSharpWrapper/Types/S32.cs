using System;
using System.Runtime.InteropServices;

namespace RshCSharpWrapper.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct S32
    {
        private Names type; // data code
        public Int32 data;
        public S32(Int32 data)
        {
            type = Names.S32;
            this.data = data;
        }
    };
}
