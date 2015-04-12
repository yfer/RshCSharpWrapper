using System;
using System.Runtime.InteropServices;

namespace RshCSharpWrapper.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal class S8P : IReturn, IString
    {
        private Names type = Names.S8P;
        public IntPtr data = IntPtr.Zero;
        public dynamic ReturnValue()
        {
            return Marshal.PtrToStringAnsi(data);
        }
    };
}
