﻿namespace RshCSharpWrapper.Device
{
    public class InitVoltmeter
    {
        public uint startType;	//!< тип запуска
        public uint bufferSize;	// !< размер буфера в отсчётах (значение пересчитывается при инициализации в зависимости от сопутствующих настроек)
        public double frequency;	// !< частота дискретизации	
        public uint filter;		//!<
        public uint control;	//!< настройки платы

        public enum StartTypeBit : uint// возможные режимы старта платы
        {
            Program = 0x0, //!< программный запуск 
        };
        public enum ControlBit : uint
        {
            VoltageDC = 0x0, //!< измерение отношения постоянных напряжений
            VoltageAC = 0x1, //!< измерение переменного напряжения
            CurrentDC = 0x2, //!< измерение постоянного тока
            CurrentAC = 0x4  //!< измерение переменного тока
        };
        public InitVoltmeter()
        {
            startType = 0;
            bufferSize = 0;
            frequency = 0;
            filter = 0;
            control = 0;
        }
        public void SetStartType(params StartTypeBit[] array)
        {
            startType = 0;
            foreach (StartTypeBit elem in array)
                startType |= (uint)elem;
        }
    };
}
