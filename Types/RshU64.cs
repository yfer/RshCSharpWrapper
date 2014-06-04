using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace RshCSharpWrapper.Types
{

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct RshU64
    {
        private Names type; // data code
        public UInt64 data;
        public RshU64(UInt64 data)
        {
            type = Names.rshU64;
            this.data = data;
        }
    };
}
