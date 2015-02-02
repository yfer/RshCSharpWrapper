using System;
using System.Runtime.InteropServices;

namespace RshCSharpWrapper.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal class S64 : IReturn
    {
        private Names type = Names.S64;
        public Int64 data;
        public dynamic ReturnValue()
        {
            return data;
        }
    };
}
