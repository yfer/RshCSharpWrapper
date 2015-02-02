using System;
using System.Runtime.InteropServices;

namespace RshCSharpWrapper.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal class U64 : IReturn
    {
        private Names type = Names.U64;
        public UInt64 data;
        public dynamic ReturnValue()
        {
            return data;
        }
    };
}
