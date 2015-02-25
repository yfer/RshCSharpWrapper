using System.Runtime.InteropServices;

namespace RshCSharpWrapper.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct Double
    {
        private Names type; // data code
        public System.Double data;
        public Double(System.Double data)
        {
            type = Names.Double;
            this.data = data;
        }
    };
}
