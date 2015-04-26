using System;
using System.Runtime.InteropServices;

namespace RshCSharpWrapper.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal class BufferU16 : IReturn, IBuffer
    {
        private Names typeName = Names.BufferU16;  //!< тип данных буфера
        public uint size;  //!< данное поле используется после вызова UniDriverGetData(), чтобы отразить реальное количество скопированных данных в буфер
        public uint psize; //!< количество элементов в буфере
        private uint id;
        public IntPtr ptr;   //!< указатель на буфер

        public dynamic ReturnValue()
        {
            var tmpBufferInt = new ushort[(int)size];
            var temp = new short[(int)size];
            Marshal.Copy(ptr, temp, 0, (int)size);
            Buffer.BlockCopy(temp, 0, tmpBufferInt, 0, (int) size);
            return tmpBufferInt;
        }
    };
}
