using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

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
