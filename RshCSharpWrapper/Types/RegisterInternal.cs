using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace RshCSharpWrapper.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct RegisterInternal
    {
        private Names typeName;

        public uint size;
        public uint offset;
        public uint value;

        public RegisterInternal(UInt32 ot)
        {
            typeName = Names.Register;
            size = 1;
            offset = 0;
            value = 0;
        }
    }
}
