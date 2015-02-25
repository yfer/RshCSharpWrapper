namespace RshCSharpWrapper.Device
{
    public class InitDAC
    {
        public uint id;  //!< Идентификатор ЦАПа
        public double voltage;   //!< Напряжение, которое нужно выдать на ЦАП

        public InitDAC()
        {
            id = 0;
            voltage = 0;
        }
    };
}
