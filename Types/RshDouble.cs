using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace RshCSharpWrapper.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct RshDouble
    {
        private Names type; // data code
        public Double data;
        public RshDouble(Double data)
        {
            type = Names.rshDouble;
            this.data = data;
        }
    };
}
