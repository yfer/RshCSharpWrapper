using System;
using System.Runtime.InteropServices;

namespace RshCSharpWrapper.Types
{
    /// <summary>
    /// Unsigned Int 32
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class U32 : IReturn
    {
        private Names type = Names.U32;
        public UInt32 data;
        public dynamic ReturnValue()
        {
            return data;
        }
    };
}
