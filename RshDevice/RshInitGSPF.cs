using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RshCSharpWrapper.RshDevice
{
    public class RshInitGSPF
    {
        public uint startType;	//!< тип запуска платы
        public double frequency;//!< частота 
        public AttenuatorBit attenuator; //!<       
        public uint control;	//!< настройки платы

        public enum StartTypeBit : uint// возможные режимы старта платы
        {
            Program = 0x1, //!< программный запуск               
            External = 0x4, //!< использование внешней синхронизации             
            FrequencyExternal = 0x10, //!< использование внешней частоты дискретизации

        };
        public enum ControlBit : uint
        {
            FilterOff = 0x0,
            PlayOnce = 0x0,
            SynchroFront = 0x0,
            SynthesizerOff = 0x0,
            SynthesizerOn = 0x1,
            FilterOn = 0x2,
            PlayLoop = 0x4,
            SynchroDecline = 0x8
        };

        public enum AttenuatorBit : uint
        {
            AttenuationOff = 0x0,
            Attenuation6dB = 0x1,
            Attenuation12db = 0x2,
            Attenuation18dB = 0x3,
            Attenuation24dB = 0x4,
            Attenuation30dB = 0x5,
            Attenuation36dB = 0x6,
            Attenuation42dB = 0x7
        };

        public RshInitGSPF()
        {
            startType = 1;
            frequency = 0;
            attenuator = 0;
            control = 0;
        }
        public void SetStartType(params StartTypeBit[] array)
        {
            this.startType = 0;
            foreach (StartTypeBit elem in array)
                this.startType |= (uint)elem;
        }
        public void SetControl(params ControlBit[] array)
        {
            this.control = 0;
            foreach (ControlBit elem in array)
                this.control |= (uint)elem;
        }
    };
}
