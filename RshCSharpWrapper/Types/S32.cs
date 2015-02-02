using System;
using System.Runtime.InteropServices;

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
