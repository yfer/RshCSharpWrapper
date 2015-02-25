using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace RshCSharpWrapper.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct U8
    {
        private Names typeName; // data code
        public byte data;
        public U8(byte data)
        {
            typeName = Names.U8;
            this.data = data;
        }
    };
}
