using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RshCSharpWrapper
{
    /// <summary>
    /// List of additional flags.
    /// Use this flags to specify additional options in InitMemory.Control field.
    /// </summary>
    public enum Control : uint
    {
        /// <summary>
        /// Normal mode.
        /// Double and quadro frequency modes are not used. This flag is default and can be used for all devices.
        /// Mutually exclusive with FreqDouble and FreqQuadro
        /// </summary>
        FreqSingle = 0x0,

        /// <summary>
        /// Auto start off.
        /// Automatic start is turned off. This is default value. 
        /// This flag is actual only for devices which support RSH_CAPS_DEVICE_AUTO_START_MODE mode.
        /// </summary>
        AutoStartOff = 0x0,

        /// <summary>
        /// Double sampling rate.
        /// When this flag is active, device will work in double frequency mode. 
        /// This flag can be set only for devices that support this feature (RSH_CAPS_DEVICE_DOUBLE_FREQUENCY_MODE). 
        /// Mutually exclusive with FreqSingle and FreqQuadro
        /// </summary>
        FreqDouble = 0x1,

        /// <summary>
        /// Quadro sampling rate.
        /// When this flag is active, device will work in quadro frequency mode. 
        /// This flag can be set only for devices that support this feature (RSH_CAPS_DEVICE_QUADRO_FREQUENCY_MODE). 
        /// Mutually exclusive with FreqSingle and FreqDouble
        /// </summary>
        FreqQuadro = 0x2,


        /// <summary>
        /// Auto start on.
        /// Automatic start is turned on. 
        /// This flag is actual only for devices which support RSH_CAPS_DEVICE_AUTO_START_MODE mode.
        /// When this mode is active, device hardware will start data acquisition process automatically, using current settings. 
        /// One can call Device.Start() method only once, and the just obtain data until end (need to call Device.Stop() to terminate process).
        /// </summary>
        AutoStartOn = 0x4
    };
}
