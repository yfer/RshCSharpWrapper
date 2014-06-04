using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RshCSharpWrapper.RshDevice
{
    public class RshInitDAC
    {
        public uint id;  //!< Идентификатор ЦАПа
        public double voltage;   //!< Напряжение, которое нужно выдать на ЦАП

        public RshInitDAC()
        {
            id = 0;
            voltage = 0;
        }
    };
}
