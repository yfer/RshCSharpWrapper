using System.Runtime.InteropServices;

namespace RshCSharpWrapper.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal class S8 : IReturn
    {
        private Names typeName = Names.S8;
        public sbyte data;
        public dynamic ReturnValue()
        {
            return data;
        }
    };
}
