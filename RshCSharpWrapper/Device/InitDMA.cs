namespace RshCSharpWrapper.Device
{
    public class InitDMA : InitADC
    {
        public uint dmaMode;	//!< режим работы DMA	
        public uint control;	//!< специфические настройки для данного типа плат (например, диф режим)
        public double frequencyPack;	// !< частота дискретизации	внутри пачки
        public enum ControlBit : uint	// настройка режима работы платы
        {
            StandardMode = 0x0, //<! обычный режим работы
            DiffMode = 0x1, //<! дифференциальный режим включен    
            FrameMode = 0x2, //<! кадровый режим
            MulSwitchStart = 0x4, //<! переключение мультиплексора по старту
        };

        public enum DmaModeBit : uint// настройка режима сбора данных
        {
            Single = 0x0, //!< режим одиночного сбора буфера
            Persistent = 0x1, //!< сбор данных в непрерывном режиме
        };
        public void SetControl(params ControlBit[] array)
        {
            control = 0;
            foreach (ControlBit elem in array)
                control |= (uint)elem;
        }
        public void SetDmaMode(params DmaModeBit[] array)
        {
            dmaMode = 0;
            foreach (DmaModeBit elem in array)
                dmaMode |= (uint)elem;
        }
        public InitDMA()
        {

            dmaMode = 0;
            control = 0;
            frequencyPack = 0;
        }
    };
}
