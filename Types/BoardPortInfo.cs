using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace RshCSharpWrapper.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct BoardPortInfo
    {
        private Names typeName;     // data code
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public PortInfo[] confs;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public PortInfo[] ports;
        public uint totalConfs;
        public uint totalPorts;
        public BoardPortInfo(UInt32 st)
        {
            typeName = Names.BoardPortInfo;
            confs = new PortInfo[32];
            ports = new PortInfo[32];
            for (int i = 0; i < 32; i++)
            {
                confs[i] = new PortInfo(0);
                ports[i] = new PortInfo(0);
            }
            totalConfs = 0;
            totalPorts = 0;
        }
    };
}
