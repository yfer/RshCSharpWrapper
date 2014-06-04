using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RshCSharpWrapper.Device
{
    public class InitADC
    {
        public uint startType;	// !< настройки типа старта платы
        public uint bufferSize;	// !< размер буфера в отсчётах (значение пересчитывается при инициализации в зависимости от сопутствующих настроек)
        public double frequency;	// !< частота дискретизации	
        public Channel[] channels; // параметры каналов
        public double threshold;		//!< уровень синхронизации в Вольтах
        public uint controlSynchro;	//!< специфические настройки синхронизации

        public enum ControlSynchroBit : uint// параметры синхронизации
        {
            FrequencySwitchOFF = 0x0, //!< предыстория и история собираются с одной частотой (ADC_CONTROL_ESW)
            SlopeFront = 0x1,	      //!< синхронизация по фронту
            SlopeDecline = 0x2,       //!< синхронизация по спаду
            FrequencySwitchOn = 0x4   //!< предыстория и история собираются с разными частотами (ADC_CONTROL_FSW)
        };
        public enum StartTypeBit : uint // режимы старта платы
        {
            Program = 0x1, //!< программный запуск
            Timer = 0x2, //!< запуск по таймеру
            External = 0x4, //!< использование внешней синхронизации
            Internal = 0x8, //!< использование внутренней синхронизации
            FrequencyExternal = 0x10, //!< использование внешней частоты дискретизации
            Master = 0x20 //!< старт от устройства-мастера в системах с несколькими устройствами  
        };
        public InitADC()
        {
            startType = 1;
            frequency = 0;
            bufferSize = 0;
            channels = new Channel[32];
            for (int i = 0; i < 32; i++)
                channels[i] = new Channel();

            threshold = 0.0;
            controlSynchro = 0;
        }
        public void SetStartType(params StartTypeBit[] array)
        {
            this.startType = 0;
            foreach (StartTypeBit elem in array)
                this.startType |= (uint)elem;
        }
    }

}
