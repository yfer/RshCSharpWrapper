using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace RshCSharpWrapper.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct Double
    {
        private Names type; // data code
        public System.Double data;
        public Double(System.Double data)
        {
            type = Names.Double;
            this.data = data;
        }
    };
}
