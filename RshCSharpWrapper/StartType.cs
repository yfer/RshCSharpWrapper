using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RshCSharpWrapper
{
    /// <summary>
    /// Start mode list.
    /// This enum entities can be used to specify how to start ADC process.
    /// To do so, set one of them as value for startType field.
    /// </summary>
    public enum StartType : uint
    {
        /// <summary>
        /// Program start.
        /// Conversation will start as soon as command will be acquired by the device.
        /// That means, ADC will start as soon as IRshDevice::Start() method is called.
        /// Remarks:
        /// "As soon" is not immediately, because there is always some delays for functions calls, data transfer and device responce.
        /// </summary>
        Program = 0x1,

        /// <summary>
        /// Timer start.
        /// Start data acquisition process using internal timer.
        /// Deprecated:
        /// This flag is not used in any library at the moment. In SDK1 some devices used Program mode, some Timer mode for the same thing.
        /// May be this flag will be removed in the future.
        /// </summary>
        Timer = 0x2,

        /// <summary>
        /// Start data acquisition on external trigger.
        /// Use external trigger input as source for data acquisition start command.
        /// Remarks:
        /// There are two different mechanisms that can be activated by this flag: 
        /// using external trigger input (see RSH_CAPS_DEVICE_SYNCHRO_EXTERNAL) 
        /// or external start input (see RSH_CAPS_DEVICE_EXTERNAL_START).
        /// </summary>
        External = 0x4,

        /// <summary>
        /// Internal synchronization.
        /// Use analog input channels as source for trigger to start ADC.
        /// Remarks:
        /// One can check if device supports this mode using RSH_CAPS_DEVICE_SYNCHRO_INTERNAL.
        /// Usually, this feature is used by "Memory" devices.
        /// See Also:
        /// RshChannel::Synchro | RshInitMemory::threshold
        /// </summary>
        Internal = 0x8,

        /// <summary>
        /// Use external frequency source for sampling.
        /// External frequency will be used for sampling ADC. See RSH_CAPS_DEVICE_EXTERNAL_FREQUENCY for more details.
        /// </summary>
        FrequencyExternal = 0x10,

        /// <summary>
        /// Use master device as start trigger source.
        /// This flag may be used in systems where two or more devieces are started synchronously from one source. One device usually is master device, and all other are slave devices.
        /// See Also:
        /// RSH_CAPS_DEVICE_SLAVE_MASTER_SWITCH
        /// </summary>
        Master = 0x20
    };
}
