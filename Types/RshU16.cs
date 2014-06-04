using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace RshCSharpWrapper.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct RshU16
    {
        private Names typeName; // data code
        public UInt16 data;
        public RshU16(UInt16 data)
        {
            typeName = Names.rshU16;
            this.data = data;
        }
    };
}
