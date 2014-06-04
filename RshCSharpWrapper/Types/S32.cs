using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

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
