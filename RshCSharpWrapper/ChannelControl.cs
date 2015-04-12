using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RshCSharpWrapper
{
    public enum ChannelControl : uint	// специфические настройки канала
    {
        NotUsed = 0x0,	//!< канал не используется при оцифровке
        NoSynchro = 0x0,	//!< по данному каналу не осуществляется синхронизация
        Resist1MOm = 0x0,	//!< сопротивление входа 1 МОм
        DC = 0x0,	//!< состояние входa открытый

        Used = 0x1,	//!< канал используется
        Synchro = 0x2,	//!< синхронизация по данному каналу
        AC = 0x4,	//!< состояние входa закрытый
        Resist50Om = 0x8,	//!< сопротивление входа 50 Ом

        FirstChannel = 0x10000, //!< для некоторых плат данный флаг задаёт канал, который будет оцифрован первым

    };
}
