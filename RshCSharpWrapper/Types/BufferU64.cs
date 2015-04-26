using System;
using System.Runtime.InteropServices;

namespace RshCSharpWrapper.Types
{
    //TODO: Convert to class like BufferU32
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct BufferU64
    {
        private Names typeName;  //!< тип данных буфера
        public uint size;  //!< данное поле используется после вызова UniDriverGetData(), чтобы отразить реальное количество скопированных данных в буфер
        public uint psize; //!< количество элементов в буфере
        private uint id;
        public IntPtr ptr;   //!< указатель на буфер

        public BufferU64(uint size)
        {
            typeName = Names.BufferU64;
            this.size = size;
            psize = 0;
            ptr = IntPtr.Zero;
            id = 0;
        }
    };
}
