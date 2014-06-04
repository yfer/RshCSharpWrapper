using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace RshCSharpWrapper.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct RshS16
    {
        private Names typeName; // data code
        public Int16 data;
        public RshS16(Int16 data)
        {
            typeName = Names.rshS16;
            this.data = data;
        }
    };
}
