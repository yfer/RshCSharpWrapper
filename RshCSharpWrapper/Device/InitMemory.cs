namespace RshCSharpWrapper.Device
{
    //public class InitMemory : InitADC // former ADCParametersMEMORY2
    //{
    //    public SynchroChannel channelSynchro; //<! настройки канала внешней синхронизации

    //    public uint control; //!< специфические настройки для данного типа плат
    //    public uint beforeHistory;	//!< размер предыстории, может принимать значения от 0 до 15
    //    public uint startDelay;		//!< задержка старта
    //    public uint hysteresis;		//!< гистеризис
    //    public uint packetNumber;	//!< количество пакетов размера bufferSize


    //    public enum ControlBit : uint
    //    {
    //        FreqSingle = 0x0,	//!< обычная частота
    //        FreqDouble = 0x1,	//!< удвоенная частота
    //        FreqQuadro = 0x2	//!< учетверенная частота
    //    };
    //    public void SetControlSynchro(params ControlSynchroBit[] array)
    //    {
    //        controlSynchro = 0;
    //        foreach (ControlSynchroBit elem in array)
    //            controlSynchro |= (uint)elem;
    //    }
    //    public void SetControl(params ControlBit[] array)
    //    {
    //        control = 0;
    //        foreach (ControlBit elem in array)
    //            control |= (uint)elem;
    //    }
    //    public InitMemory()
    //    {
    //        control = 0;
    //        beforeHistory = 0;
    //        startDelay = 0;
    //        hysteresis = 0;
    //        packetNumber = 1;
    //        channelSynchro = new SynchroChannel();
    //    }
    //} ;
}
