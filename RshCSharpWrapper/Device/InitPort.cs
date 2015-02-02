namespace RshCSharpWrapper.Device
{
    public class InitPort
    {
        public enum OperationTypeBit : uint
        {
            Read = 0,
            Write,
            WriteAND,
            WriteOR
        };

        public OperationTypeBit operationType;  //!< Read, Write, Mask with And, OR
        public uint portAddress;   //!< port number
        public uint portValue;     //!< port value

        public InitPort()
        {

            operationType = OperationTypeBit.Read;
            portAddress = 0;
            portValue = 0;
        }
    };
}
