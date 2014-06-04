using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RshCSharpWrapper.RshDevice
{
    public class RshInitPort
    {
        public enum OperationTypeBit : uint
        {
            Read = 0,
            Write,
            WriteAND,
            WriteOR
        };

        public OperationTypeBit operationType;  //!< Read, Write, Mask with And, OR
        public uint portAddress;   //!< port number
        public uint portValue;     //!< port value

        public RshInitPort()
        {

            operationType = OperationTypeBit.Read;
            portAddress = 0;
            portValue = 0;
        }
    };
}
