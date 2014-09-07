using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace RshCSharpWrapper.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal class U8 : IReturn
    {
        private Names typeName = Names.U8;
        public byte data;
        public dynamic ReturnValue()
        {
            return data;
        }
    };
}
