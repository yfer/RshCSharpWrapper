using System.Runtime.InteropServices;

namespace RshCSharpWrapper.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal class Double : IReturn
    {
        private Names type = Names.Double; // data code
        public System.Double data;
    
        public dynamic ReturnValue()
        {
            return data;
        }
    };
}
