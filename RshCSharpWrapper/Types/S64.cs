using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace RshCSharpWrapper.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct S64
    {
        private Names type; // data code
        public Int64 data;
        public S64(Int64 data)
        {
            type = Names.S64;
            this.data = data;
        }
    };
}
