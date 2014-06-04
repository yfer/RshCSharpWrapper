using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RshCSharpWrapper.RshDevice
{
    public enum RSH_DATA_MODE
    {
        NO_FLAGS = 0x0,
        CONTAIN_DIGITAL_INPUT = 0x00001,
        GSPF_TTL = 0x10000
    };
}
