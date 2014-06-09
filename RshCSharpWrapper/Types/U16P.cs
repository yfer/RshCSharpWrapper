using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace RshCSharpWrapper.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal class U16P
    {
        private Names type = Names.U16P; // data code
        public IntPtr data = IntPtr.Zero;
        /*public U16P(Int32 data)
        {
            type = Names.U16P;
            this.data = IntPtr.Zero;
        }*/
    };
}
