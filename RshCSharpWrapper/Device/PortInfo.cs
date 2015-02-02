namespace RshCSharpWrapper.Device
{
    public class PortInfo
    {
        public uint address;    //!< регистр отвечающий за порт
        public byte bitSize;    //!< разрядность порта     
        public string name;     //!< название порта
        public PortInfo()
        {
            address = 0;
            bitSize = 0;
            name = "";
        }
    };
}
