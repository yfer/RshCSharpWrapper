using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace RshCSharpWrapper.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct PortInfo
    {
        public uint address;    //!< регистр отвечающий за порт
        public byte bitSize;    //!< разрядность порта 
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] name;     //!< название порта
        public PortInfo(UInt32 st)
        {
            address = 0;
            bitSize = 0;
            name = new byte[32];
        }
    };
}
