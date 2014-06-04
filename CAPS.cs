﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RshCSharpWrapper
{
    /// <summary>
    /// Поддерживаемые платой функции.
    /// </summary>
    public enum CAPS : uint
    {
        DEVICE_PCI = 0,
        DEVICE_PCI_EXPRESS = 1,
        DEVICE_USB1_1 = 2,
        DEVICE_USB2_0 = 3,
        DEVICE_USB3_0 = 4,
        DEVICE_ETHERNET = 5,
        DEVICE_FREQUENCY_SYNTHESIZER = 15,
        DEVICE_TIMER_8254 = 16,
        DEVICE_MEMORY_PER_CHANNEL = 17,
        DEVICE_FREQUENCY_LIST = 18,
        DEVICE_SIZE_LIST = 19,
        DEVICE_HAS_DIGITAL_PORT = 20,
        DEVICE_GAIN_LIST = 21,
        DEVICE_GAINS_PER_CHANNEL = 22,
        DEVICE_PREHISTORY = 23,
        DEVICE_DOUBLE_FREQUENCY_MODE = 24,
        DEVICE_QUADRO_FREQUENCY_MODE = 25,
        DEVICE_AUTO_CALIBRATION = 26,
        DEVICE_SYNCHRO_INTERNAL = 27,
        DEVICE_SYNCHRO_EXTERNAL = 28,
        DEVICE_EXTERNAL_START = 29,
        DEVICE_HYSTERESIS = 30,
        DEVICE_EXT_SYNC_GAIN_LIST = 31,
        DEVICE_EXT_SYNC_FILTER_LOW = 32,
        DEVICE_EXT_SYNC_FILTER_HIGH = 33,
        DEVICE_EXT_SYNC_INPUT_RESIST_50_OHM = 34,
        DEVICE_EXT_SYNC_INPUT_RESIST_1_MOHM = 35,
        DEVICE_EXT_SYNC_COUPLING_AC_DC = 36,
        DEVICE_HAS_DAC_INSTALLED = 37,
        DEVICE_INPUT_LEVEL_ADJUSTMENT = 38,
        DEVICE_INPUT_COUPLING_AC_DC = 39,
        DEVICE_INPUT_RESIST_50_OHM = 40,
        DEVICE_INPUT_RESIST_1_MOHM = 41,
        DEVICE_ADC_MODE_SWITCH = 42,
        DEVICE_FRAME_FREQUENCY_MODE = 43,
        DEVICE_PACKET_MODE = 44,
        DEVICE_START_DELAY = 45,
        DEVICE_SLAVE_MASTER_SWITCH = 46,
        DEVICE_SYNCHRO_CHANNELS = 47,
        DEVICE_EXTERNAL_FREQUENCY = 48,
        DEVICE_FREQUENCY_SWITCH_PREHISTORY = 49,
        DEVICE_FREE_CHANNEL_SELECT_IN_EXT_MODE = 50,
        DEVICE_DIFFERENTIAL_INPUT_MODE = 51,
        DEVICE_FLASH_INFO_ONBOARD = 52,
        DEVICE_GPS_MODULE_INSTALLED = 53,
        DEVICE_AUTO_START_MODE = 54,
        SOFT_CALIBRATION_IS_AVAILABLE = 512,
        SOFT_GATHERING_IS_AVAILABLE = 513,
        SOFT_PGATHERING_IS_AVAILABLE = 514,
        SOFT_DIGITAL_PORT_IS_AVAILABLE = 515,
        SOFT_GENERATION_IS_AVAILABLE = 516,
        SOFT_INIT_MEMORY = 517,
        SOFT_INIT_DMA = 518,
        SOFT_INIT_GSPF = 519,
        SOFT_INIT_VOLTMETER = 520,
        SOFT_INIT_TIMER = 521,
        SOFT_STROBOSCOPE = 522,
        SOFT_INIT_DAC = 523,
        SOFT_INIT_PORT = 524,
    }
}