using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

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
