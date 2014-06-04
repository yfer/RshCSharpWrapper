using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace RshCSharpWrapper.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct RshS8P
    {
        private Names type; // data code
        public IntPtr data;
        public RshS8P(Int32 data)
        {
            type = Names.rshS8P;
            this.data = IntPtr.Zero;
        }
    };
}
