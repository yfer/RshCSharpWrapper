using System;
using System.Runtime.InteropServices;

namespace RshCSharpWrapper.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal class U16P : IReturn
    {
        private Names type = Names.U16P;
        public IntPtr data = IntPtr.Zero;
        public dynamic ReturnValue()
        {
            return Marshal.PtrToStringUni(data);
        }
    };
}
