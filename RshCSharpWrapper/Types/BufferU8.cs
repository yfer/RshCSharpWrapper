﻿using System;
using System.Runtime.InteropServices;

namespace RshCSharpWrapper.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct BufferU8
    {
        private Names typeName;  //!< тип данных буфера
        public uint size;  //!< данное поле используется после вызова UniDriverGetData(), чтобы отразить реальное количество скопированных данных в буфер
        public uint psize; //!< количество элементов в буфере
        private uint id;
        public IntPtr ptr;   //!< указатель на буфер

        public BufferU8(uint size)
        {
            typeName = Names.BufferU8;
            this.size = size;
            psize = 0;
            ptr = IntPtr.Zero;
            id = 0;
        }
    };
}
