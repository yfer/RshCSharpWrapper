﻿using System;
using System.Runtime.InteropServices;

namespace RshCSharpWrapper.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal class BufferS16 : IReturn, IBuffer
    {
        private Names typeName = Names.BufferS16;  //!< тип данных буфера
        public uint size;  //!< данное поле используется после вызова UniDriverGetData(), чтобы отразить реальное количество скопированных данных в буфер
        public uint psize; //!< количество элементов в буфере
        private uint id;
        public IntPtr ptr;   //!< указатель на буфер
        
        public dynamic ReturnValue()
        {
            var tmpBufferInt = new short[(int)size];
            Marshal.Copy(ptr, tmpBufferInt, 0, (int)size);
            return tmpBufferInt;
        }
    };
}
