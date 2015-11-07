using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RshCSharpWrapper
{
    [Flags]
    public enum ChannelControl : uint	// специфические настройки канала
    {
        /// <summary>
        /// канал не используется при оцифровке
        /// </summary>
        NotUsed = 0x0,
        
        /// <summary>
        /// по данному каналу не осуществляется синхронизация
        /// </summary>
        NoSynchro = 0x0,
        
        /// <summary>
        /// сопротивление входа 1 МОм
        /// </summary>
        Resist1MOm = 0x0,
        
        /// <summary>
        /// состояние входa открытый
        /// </summary>
        DC = 0x0,

        /// <summary>
        /// канал используется
        /// </summary>
        Used = 0x1,

        /// <summary>
        /// синхронизация по данному каналу
        /// </summary>
        Synchro = 0x2,

        /// <summary>
        /// состояние входa закрытый
        /// </summary>
        AC = 0x4,

        /// <summary>
        /// сопротивление входа 50 Ом
        /// </summary>
        Resist50Om = 0x8,

        /// <summary>
        /// для некоторых плат данный флаг задаёт канал, который будет оцифрован первым
        /// </summary>
        FirstChannel = 0x10000,

    };
}
