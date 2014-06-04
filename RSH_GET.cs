﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RshCSharpWrapper
{
    /// <summary>
    /// Коды для получения дополнительной информации об устройстве и библиотеке.
    /// </summary>
    public enum RSH_GET : uint
    {
        BUFFER_READY = 0x10001,
        WAIT_BUFFER_READY_EVENT = 0x20001,
        WAIT_GATHERING_COMPLETE = 0x20002,
        WAIT_NANO_DELAY = 0x20003,
        DEVICE_PID = 0x30001,
        DEVICE_VID = 0x30002,
        DEVICE_NAME_VERBOSE = 0x30003,
        DEVICE_NAME_VERBOSE_UTF16 = 0x30004,
        DEVICE_IS_CAPABLE = 0x30005,
        DEVICE_BASE_LIST = 0x30006,
        DEVICE_BASE_LIST_EXT = 0x30007,
        DEVICE_MIN_FREQUENCY = 0x30008,
        DEVICE_MAX_FREQUENCY = 0x30009,
        DEVICE_MIN_AMP_LSB = 0x3000a,
        DEVICE_MAX_AMP_LSB = 0x3000b,
        DEVICE_FREQUENCY_LIST = 0x3000c,
        DEVICE_DATA_SIZE_BYTES = 0x3000d,
        DEVICE_DATA_BITS = 0x3000e,
        DEVICE_NUMBER_CHANNELS = 0x3000f,
        DEVICE_NUMBER_CHANNELS_BASE = 0x30010,
        DEVICE_GAIN_LIST = 0x30011,
        DEVICE_GAIN_LIST_50_OHM = 0x30012,
        DEVICE_GAIN_LIST_1_MOHM = 0x30013,
        DEVICE_MEMORY_SIZE = 0x30014,
        DEVICE_SIZE_LIST = 0x30015,
        DEVICE_SIZE_LIST_SINGLE = 0x30016,
        DEVICE_SIZE_LIST_DOUBLE = 0x30017,
        DEVICE_SIZE_LIST_QUADRO = 0x30018,
        DEVICE_PACKET_LIST = 0x30019,
        DEVICE_INPUT_RANGE_VOLTS = 0x3001a,
        DEVICE_OUTPUT_RANGE_VOLTS = 0x3001b,
        DEVICE_EXT_SYNC_GAINLIST = 0x3001c,
        DEVICE_EXT_SYNC_GAIN_LIST_50_OHM = 0x3001d,
        DEVICE_EXT_SYNC_GAIN_LIST_1_MOHM = 0x3001e,
        DEVICE_EXT_SYNC_INPUT_RANGE_VOLTS = 0x3001f,
        DEVICE_PORT_INFO = 0x30020,
        DEVICE_SERIAL_NUMBER = 0x30021,
        DEVICE_PREHISTORY_SIZE = 0x30022,
        DEVICE_ACTIVE_CHANNELS_NUMBER = 0x30023,
        DEVICE_PLUG_STATUS = 0x30024,
        DEVICE_ACTIVE_LIST = 0x30025,
        DEVICE_AUTO_CALIBRATION_SET = 0x30026,
        DEVICE_ICP_POWER_SET = 0x30027,
        DEVICE_AVR_MODE_SET = 0x30028,
        DEVICE_REGISTER_BOARD = 0x30029,
        DEVICE_REGISTER_BOARD_SET = 0x3002a,
        DEVICE_REGISTER_BOARD_SPACE1 = 0x3002b,
        DEVICE_REGISTER_BOARD_SPACE1_SET = 0x3002c,
        DEVICE_REGISTER_BOARD_SPACE2 = 0x3002d,
        DEVICE_REGISTER_BOARD_SPACE2_SET = 0x3002e,
        DEVICE_MIN_SAMPLES_PER_CHANNEL = 0x3002f,
        DEVICE_MAX_SAMPLES_PER_CHANNEL = 0x30030,
        DEVICE_RESET = 0x30031,
        DEVICE_POWER_STATUS = 0x30032,
        DEVICE_ACTIVE_LIST_EXT = 0x30033,
        DEVICE_GPS_DATA = 0x30034,
        DEVICE_GPS_DATA_UTF16 = 0x30035,
        DEVICE_AUTO_START_INTERVAL_SET = 0x30036,
        DEVICE_POWER_SOURCE_VOLTAGE = 0x30037,
        SDK_VERSION_MAJOR = 0x40001,
        SDK_VERSION_MINOR = 0x40002,
        SDK_VERSION_STRING = 0x40003,
        SDK_COPYRIGHT_STRING = 0x40004,
        SDK_COPYRIGHT_STRING_UTF16 = 0x40005,
        SDK_VERSION_STRING_UTF16 = 0x40006,
        LIBRARY_VERSION_MAJOR = 0x50001,
        LIBRARY_VERSION_MINOR = 0x50002,
        LIBRARY_VERSION_BUILD = 0x50003,
        LIBRARY_VERSION_DATE = 0x50004,
        LIBRARY_INTERFACE_NAME = 0x50005,
        LIBRARY_INTERFACE_NAME_UTF16 = 0x50006,
        LIBRARY_MODULE_NAME = 0x50007,
        LIBRARY_MODULE_NAME_UTF16 = 0x50008,
        LIBRARY_PATH = 0x50009,
        LIBRARY_PATH_UTF16 = 0x5000a,
        LIBRARY_FILENAME = 0x5000b,
        LIBRARY_FILENAME_UTF16 = 0x5000c,
        LIBRARY_VERSION_STR = 0x5000d,
        LIBRARY_VERSION_STR_UTF16 = 0x5000e,
        LIBRARY_DESCRIPTION = 0x5000f,
        LIBRARY_DESCRIPTION_UTF16 = 0x50010,
        LIBRARY_PRODUCT_NAME = 0x50011,
        LIBRARY_PRODUCT_NAME_UTF16 = 0x50012,
        CORELIB_VERSION_MAJOR = 0x60001,
        CORELIB_VERSION_MINOR = 0x60002,
        CORELIB_VERSION_BUILD = 0x60003,
        CORELIB_VERSION_DATE = 0x60004,
        CORELIB_INTERFACE_NAME = 0x60005,
        CORELIB_INTERFACE_NAME_UTF16 = 0x60006,
        CORELIB_MODULE_NAME = 0x60007,
        CORELIB_MODULE_NAME_UTF16 = 0x60008,
        CORELIB_PATH = 0x60009,
        CORELIB_PATH_UTF16 = 0x6000a,
        CORELIB_FILENAME = 0x6000b,
        CORELIB_FILENAME_UTF16 = 0x6000c,
        CORELIB_VERSION_STR = 0x6000d,
        CORELIB_VERSION_STR_UTF16 = 0x6000e,
        CORELIB_DESCRIPTION = 0x6000f,
        CORELIB_DESCRIPTION_UTF16 = 0x60010,
        CORELIB_PRODUCT_NAME = 0x60011,
        CORELIB_PRODUCT_NAME_UTF16 = 0x60012,
        CORELIB_VERSION_INTERNAL_API = 0x60013,
        CORELIB_VERSION_INTERNAL_API_STR = 0x60014,
        CORELIB_VERSION_INTERNAL_API_STR_UTF16 = 0x60015,
        DPA_FFT_NEW_FFT_PLAN_ESTIMATE_FORWARD_SET = 0xb0001,
        DPA_FFT_NEW_FFT_PLAN_ESTIMATE_BACKWARD_SET = 0xb0002,
        DPA_FFT_NEW_FFT_PLAN_MEASURE_FORWARD_SET = 0xb0003,
        DPA_FFT_NEW_FFT_PLAN_MEASURE_BACKWARD_SET = 0xb0004,
        DPA_FFT_NEW_FFT_PLAN_PATIENT_FORWARD_SET = 0xb0005,
        DPA_FFT_NEW_FFT_PLAN_PATIENT_BACKWARD_SET = 0xb0006,
        LIBRARY_FREE_RESOURCES = 0x10050001,
        DEVICE_STATE = 0x10030009
    }
}
