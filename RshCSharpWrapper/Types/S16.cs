using System;
using System.Runtime.InteropServices;

namespace RshCSharpWrapper.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct S16
    {
        private Names typeName; // data code
        public Int16 data;
        public S16(Int16 data)
        {
            typeName = Names.S16;
            this.data = data;
        }
    };
}
