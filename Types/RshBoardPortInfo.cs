using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace RshCSharpWrapper.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct RshBoardPortInfo
    {
        private Names typeName;     // data code
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public RshPortInfo[] confs;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public RshPortInfo[] ports;
        public uint totalConfs;
        public uint totalPorts;
        public RshBoardPortInfo(UInt32 st)
        {
            typeName = Names.rshBoardPortInfo;
            confs = new RshPortInfo[32];
            ports = new RshPortInfo[32];
            for (int i = 0; i < 32; i++)
            {
                confs[i] = new RshPortInfo(0);
                ports[i] = new RshPortInfo(0);
            }
            totalConfs = 0;
            totalPorts = 0;
        }
    };
}
