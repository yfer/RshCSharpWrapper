using System;
using System.Runtime.InteropServices;

namespace RshCSharpWrapper.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct BufferU32
    {
        private Names typeName;  //!< тип данных буфера
        public uint size;  //!< данное поле используется после вызова UniDriverGetData(), чтобы отразить реальное количество скопированных данных в буфер
        public uint psize; //!< количество элементов в буфере
        private uint id; // кникальный идентификатор буфера (служебное поле)
        public IntPtr ptr;   //!< указатель на буфер

        public BufferU32(uint size)
        {
            typeName = Names.BufferTypeU32;
            this.size = size;
            this.psize = 0;
            this.ptr = IntPtr.Zero;
            this.id = 0;
        }
    };
}
