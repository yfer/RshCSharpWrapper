using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

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
