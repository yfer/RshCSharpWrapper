using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RshCSharpWrapper.RshDevice
{
    public class RshSynchroChannel  // настройка канала внешней синхронизации
    {
        public uint gain;		//!< коэффициент усиления
        public uint control;	//!< специфические настройки канала 

        public enum ControlBit : uint	// специфические настройки канала
        {
            FilterOff = 0x0, //!< фильтр не используется
            Resist1MO = 0x0, //!< сопротивление входа 1 МОм
            DC = 0x0, //!< состояние входa открытый

            FilterLow = 0x1, //!< Фильтр ФНЧ включен
            FilterHigh = 0x3, //!< Фильтр ФВЧ включен
            AC = 0x4, //!< состояние входa закрытый
            Resist50Om = 0x8  //!< сопротивление входa 50 Ом)
        };
        public void SetControl(params ControlBit[] array)
        {
            this.control = 0;
            foreach (ControlBit elem in array)
                this.control |= (uint)elem;
        }
    }
}
