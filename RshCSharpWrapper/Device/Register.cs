﻿namespace RshCSharpWrapper.Device
{
    public class Register
    {
        public uint size;
        public uint offset;
        public uint value;

        public Register()
        {
            size = 1;
            offset = 0;
            value = 0;
        }
    }
}
