using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace RshCSharpWrapper.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct RshU8
    {
        private Names typeName; // data code
        public byte data;
        public RshU8(byte data)
        {
            typeName = Names.rshU8;
            this.data = data;
        }
    };
}
