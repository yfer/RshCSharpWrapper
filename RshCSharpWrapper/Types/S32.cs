using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace RshCSharpWrapper.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal class S32
    {
        private Names type = Names.S32;
        public Int32 data;
        public dynamic ret()
        {
            return data;
        }
    };
}
