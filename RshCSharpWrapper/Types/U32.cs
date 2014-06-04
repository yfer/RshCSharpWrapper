using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace RshCSharpWrapper.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct U32
    {
        private Names type; // data code
        public UInt32 data;
        public U32(UInt32 data)
        {
            type = Names.U32;
            this.data = data;
        }
    };
}
