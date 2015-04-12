using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RshCSharpWrapper
{
    /// <summary>
    /// List of additional synchronization flags.
    /// Use flags combined by 'OR' statement to specify additional options in RshInitDMA::controlSynchro field
    /// </summary>
    public enum ControlSynchro : uint// параметры синхронизации
    {
        /// <summary>
        /// Sampling rates for history and prehistory are equal.
        /// Default option, work for all devices. SDK1 analog is ADC_CONTROL_ESW constant.
        /// See Also:
        /// CAPS.DEVICE_FREQUENCY_SWITCH_PREHISTORY
        /// </summary>
        FrequencySwitchOff = 0x0,

        /// <summary>
        /// Use signal front for synchronization.
        /// This field is only actual when synchonization mode is active (see RshInitDMA::startType).
        /// Mutually exclusive with RshInitDMA::SlopeDecline.
        /// </summary>
        SlopeFront = 0x1,	      //!< синхронизация по фронту  

        /// <summary>
        /// Use signal decline for synchronization.
        /// This field is only actual when synchonization mode is active (see RshInitDMA::startType).
        /// Mutually exclusive with RshInitDMA::SlopeFront.
        /// </summary>
        SlopeDecline = 0x2,       //!< синхронизация по спаду

        /// <summary>
        /// Sampling rates for history and prehistory are different (switch to low frequency).
        /// This flag can be used only for devices that support this feature ( CAPS.DEVICE_FREQUENCY_SWITCH_PREHISTORY). 
        /// When flag is active, sampling rate is changed to low frequency (F = Fmax/8) when synchronization event occures. 
        /// As a result, prehistory and main data will have different sampling rate.
        /// SDK1 analog is ADC_CONTROL_FSW constant.
        /// </summary>
        FrequencySwitchToMinimum = 0x4,   //!< предыстория и история собираются с разными частотами (ADC_CONTROL_FSW)

        /// <summary>
        /// Sampling rates for history and prehistory are different (switch to high frequency).
        /// This flag can be used only for devices that support this feature ( CAPS.DEVICE_FREQUENCY_SWITCH_PREHISTORY). 
        /// When flag is active, sampling rate is changed to high frequency when synchronization event occures. 
        /// As a result, prehistory and main data will have different sampling rate.
        /// </summary>
        FrequencySwitchToMaximum = 0x8
    };
}
