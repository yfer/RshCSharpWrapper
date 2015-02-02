using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

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

        public BufferU32()
        {
        }

        public dynamic ReturnValue()
        {
            var tmpBufferInt = new int[(int)size];
            System.Runtime.InteropServices.Marshal.Copy(ptr, tmpBufferInt, 0, (int)size);
            return tmpBufferInt;
        }
    };
}
