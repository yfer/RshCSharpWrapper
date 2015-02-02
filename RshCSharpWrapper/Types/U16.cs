using System;
using System.Runtime.InteropServices;

namespace RshCSharpWrapper.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal class U16 : IReturn
    {
        private Names typeName = Names.U16;
        public UInt16 data;
        public dynamic ReturnValue()
        {
            return data;
        }
    };
}
