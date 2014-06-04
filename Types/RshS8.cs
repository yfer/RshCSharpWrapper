using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace RshCSharpWrapper.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct RshS8
    {
        private Names typeName; // data code
        public sbyte data;
        public RshS8(sbyte data)
        {
            typeName = Names.rshS8;
            this.data = data;
        }
    };
}
