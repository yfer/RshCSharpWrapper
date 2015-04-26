using System;
using System.Runtime.InteropServices;

namespace RshCSharpWrapper.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class BufferU32 : IReturn, IBuffer
    {
        private Names typeName = Names.BufferU32;  //!< тип данных буфера
        public uint size;  //!< данное поле используется после вызова UniDriverGetData(), чтобы отразить реальное количество скопированных данных в буфер
        public uint psize; //!< количество элементов в буфере
        private uint id; // уникальный идентификатор буфера (служебное поле)
        public IntPtr ptr;   //!< указатель на буфер

        public dynamic ReturnValue()
        {
            var tmpBufferInt = new int[(int)size];
            Marshal.Copy(ptr, tmpBufferInt, 0, (int)size);
            return tmpBufferInt;
        }
    };
}
