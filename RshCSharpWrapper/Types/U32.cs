using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace RshCSharpWrapper.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class U32
    {
        private Names type = Names.U32; // data code
        public UInt32 data;
    };
}
