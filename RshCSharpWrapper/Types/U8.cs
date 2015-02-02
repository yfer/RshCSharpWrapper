using System.Runtime.InteropServices;

namespace RshCSharpWrapper.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal class U8 : IReturn
    {
        private Names typeName = Names.U8;
        public byte data;
        public dynamic ReturnValue()
        {
            return data;
        }
    };
}
