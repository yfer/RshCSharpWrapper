using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace RshCSharpWrapper.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct InitVoltmeter
    {
        private Names typeName;     // data code				URshInitMemoryType

        public uint startType;	//!< тип запуска
        public uint bufferSize;	// !< размер буфера в отсчётах (значение пересчитывается при инициализации в зависимости от сопутствующих настроек)
        public uint filter;		//!<
        public uint control;	//!< настройки платы
        public InitVoltmeter(UInt32 st)
        {
            typeName = Names.InitVoltmeter;
            startType = 0;	//!< тип запуска
            bufferSize = filter = control = 0;
        }
    };
}
