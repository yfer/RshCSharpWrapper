using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace RshCSharpWrapper.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal class S8P : IReturn
    {
        private Names type = Names.S8P;
        public IntPtr data = IntPtr.Zero;
        public dynamic ReturnValue()
        {
            return Marshal.PtrToStringAnsi(data);
        }
    };
}
