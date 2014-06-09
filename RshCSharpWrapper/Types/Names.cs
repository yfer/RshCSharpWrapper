﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RshCSharpWrapper.Types
{
    public enum Names : uint
    {
        TypeUndefined = 0x0,
        [CorrespondingType(typeof(U8))]
        U8 = 0xadc01001,
        [CorrespondingType(typeof(S8))]
        S8 = 0xadc01002,
        [CorrespondingType(typeof(U16))]
        U16 = 0xadc01003,
        [CorrespondingType(typeof(S16))]
        S16 = 0xadc01004,
        [CorrespondingType(typeof(U32))]
        U32 = 0xadc01005,
        [CorrespondingType(typeof(S32))]
        S32 = 0xadc01006,
        [CorrespondingType(typeof(U64))]
        U64 = 0xadc01007,
        [CorrespondingType(typeof(S64))]
        S64 = 0xadc01008,
        Float = 0xadc01009,
        [CorrespondingType(typeof(Types.Double))]
        Double = 0xadc0100a,
        Bool = 0xadc0100b,
        VoidP = 0xadc02001,
        [CorrespondingType(typeof(U8P))]
        U8P = 0xadc02002,
        [CorrespondingType(typeof(S8P))]
        S8P = 0xadc02003,
        [CorrespondingType(typeof(U16P))]
        U16P = 0xadc02004,
        [CorrespondingType(typeof(S16P))]
        S16P = 0xadc02005,
        U32P = 0xadc02006,
        S32P = 0xadc02007,
        U64P = 0xadc02008,
        S64P = 0xadc02009,
        FloatP = 0xadc0200a,
        DoubleP = 0xadc0200b,
        BoolP = 0xadc0200c,
        U8PP = 0xadc0200d,
        S8PP = 0xadc0200e,
        U16PP = 0xadc0200f,
        S16PP = 0xadc02010,
        U32PP = 0xadc02011,
        S32PP = 0xadc02012,
        U64PP = 0xadc02013,
        S64PP = 0xadc02014,
        FloatPP = 0xadc02015,
        DoublePP = 0xadc02016,
        BoolPP = 0xadc02017,
        BufferU8 = 0xadc03001,
        BufferS8 = 0xadc03002,
        BufferU16 = 0xadc03003,
        BufferS16 = 0xadc03004,
        BufferU32 = 0xadc03005,
        BufferS32 = 0xadc03006,
        BufferU64 = 0xadc03007,
        BufferS64 = 0xadc03008,
        BufferFloat = 0xadc03009,
        BufferDouble = 0xadc0300a,
        BufferBool = 0xadc0300b,
        BufferChannel = 0xadc0300c,
        BufferPortInfo = 0xadc0300d,
        BufferSetting = 0xadc0300e,
        BufferSettingChannel = 0xadc0300f,
        DBufferU8 = 0xadc03010,
        DBufferS8 = 0xadc03011,
        DBufferU16 = 0xadc03012,
        DBufferS16 = 0xadc03013,
        DBufferU32 = 0xadc03014,
        DBufferS32 = 0xadc03015,
        DBufferU64 = 0xadc03016,
        DBufferS64 = 0xadc03017,
        DBufferFloat = 0xadc03018,
        DBufferDouble = 0xadc03019,
        DBufferBool = 0xadc0301a,
        BufferU8P = 0xadc0301b,
        BufferDeviceBaseInfo = 0xadc0301c,
        BufferDeviceFullInfo = 0xadc0301d,
        BufferChannelVoltage = 0xadc0301e,
        BufferCalibrationItem = 0xadc0301f,
        BufferCalibrationGroup = 0xadc03020,
        InitADC = 0xadc04001,
        InitGSPF = 0xadc04002,
        InitDMA = 0xadc04003,
        InitMemory = 0xadc04004,
        InitVoltmeter = 0xadc04005,
        InitPort = 0xadc04006,
        InitPacket = 0xadc04007,
        InitDAC = 0xadc04008,
        InitTimer = 0xadc04009,
        Register = 0xadc05001,
        Port = 0xadc05002,
        GatheringParameters = 0xadc05003,
        DeviceActiveList = 0xadc05004,
        OnboardBaseInfo = 0xadc05005,
        DeviceBaseInfo = 0xadc05006,
        DeviceFullInfo = 0xadc05007,
        DeviceBuffer = 0xadc05008,
        PortInfo = 0xadc05009,
        BoardPortInfo = 0xadc0500a,
        IFactory = 0xadc0500b,
        IRSHDevice = 0xadc0500c,
        Channel = 0xadc0500d,
        SynchroChannel = 0xadc0500e,
        CalibrationParameters = 0xadc0500f,
        CalibrationControl = 0xadc05010,
        IDebug = 0xadc05011,
        ChannelVoltage = 0xadc05012,
        DeviceKey = 0xadc05013,
        CalibrationChannelParameter = 0xadc05014,
        CalibrationItemBase = 0xadc05015,
        CalibrationItemEntity = 0xadc05016,
        CalibrationItemRegister = 0xadc05017,
        CalibrationItemButton = 0xadc05018,
        CalibrationItemFilePath = 0xadc05019,
        BoardInfoDMA = 0xadc06001,
        BoardInfoMemory = 0xadc06002,
        BoardInfoDAC = 0xadc06003,
        BoardInfoDP = 0xadc06004,
        FRDACTune = 0xadc06005,
        DPADataFFTComplex = 0xadc07001,
        DPADataWindowFunction = 0xadc07002,
        DPADataFindGap = 0xadc07003,
        DPADataFindFront = 0xadc07004,
        DPADataGeneratorSignalBase = 0xadc07005,
    }

    [System.AttributeUsage(System.AttributeTargets.All)]
    public class CorrespondingTypeAttribute : System.Attribute
    {
        public Type Type;
        public CorrespondingTypeAttribute(Type type)
        {
            this.Type = type;
        }
    }
}
