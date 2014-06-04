using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace RshCSharpWrapper.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct RshS64
    {
        private Names type; // data code
        public Int64 data;
        public RshS64(Int64 data)
        {
            type = Names.rshS64;
            this.data = data;
        }
    };

}
