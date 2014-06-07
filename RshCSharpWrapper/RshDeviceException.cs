using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RshCSharpWrapper
{
    public class RshDeviceException : Exception
    {
        public API code;
        public RshDeviceException(API code) { this.code = code; }
    }
}
