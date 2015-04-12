using System;
using System.Runtime.InteropServices;

namespace RshCSharpWrapper.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class BufferU32 : IReturn, IBuffer
    {
        private Names typeName = Names.BufferU32;  //!< тип данных буфера
        public uint size = 0;  //!< данное поле используется после вызова UniDriverGetData(), чтобы отразить реальное количество скопированных данных в буфер
        public uint psize = 0; //!< количество элементов в буфере
        private uint id = 0; // уникальный идентификатор буфера (служебное поле)
        public IntPtr ptr = IntPtr.Zero;   //!< указатель на буфер

        public dynamic ReturnValue()
        {
            var tmpBufferInt = new int[(int)size];
            Marshal.Copy(ptr, tmpBufferInt, 0, (int)size);
            return tmpBufferInt;
        }
    };
}
