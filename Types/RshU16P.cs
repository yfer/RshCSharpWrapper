using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace RshCSharpWrapper.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct RshU16P
    {
        private Names type; // data code
        public IntPtr data;
        public RshU16P(Int32 data)
        {
            type = Names.rshU16P;
            this.data = IntPtr.Zero;
        }
    };
}
