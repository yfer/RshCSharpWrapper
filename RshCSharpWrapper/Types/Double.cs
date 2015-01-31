using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace RshCSharpWrapper.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal class Double : IReturn
    {
        private Names type = Names.Double; // data code
        public System.Double data;
    
        public dynamic ReturnValue()
        {
            return data;
        }
    };
}
