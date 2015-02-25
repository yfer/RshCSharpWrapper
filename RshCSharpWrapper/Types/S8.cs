﻿using System.Runtime.InteropServices;

namespace RshCSharpWrapper.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct S8
    {
        private Names typeName; // data code
        public sbyte data;
        public S8(sbyte data)
        {
            typeName = Names.S8;
            this.data = data;
        }
    };
}
