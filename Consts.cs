using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RshCSharpWrapper
{
	namespace Types
	{
		internal enum Names : uint
		{
			rshTypeUndefined = 0x0,
			rshU8 = 0xadc01001,
			rshS8 = 0xadc01002,
			rshU16 = 0xadc01003,
			rshS16 = 0xadc01004,
			rshU32 = 0xadc01005,
			rshS32 = 0xadc01006,
			rshU64 = 0xadc01007,
			rshS64 = 0xadc01008,
			rshFloat = 0xadc01009,
			rshDouble = 0xadc0100a,
			rshBool = 0xadc0100b,
			rshVoidP = 0xadc02001,
			rshU8P = 0xadc02002,
			rshS8P = 0xadc02003,
			rshU16P = 0xadc02004,
			rshS16P = 0xadc02005,
			rshU32P = 0xadc02006,
			rshS32P = 0xadc02007,
			rshU64P = 0xadc02008,
			rshS64P = 0xadc02009,
			rshFloatP = 0xadc0200a,
			rshDoubleP = 0xadc0200b,
			rshBoolP = 0xadc0200c,
			rshU8PP = 0xadc0200d,
			rshS8PP = 0xadc0200e,
			rshU16PP = 0xadc0200f,
			rshS16PP = 0xadc02010,
			rshU32PP = 0xadc02011,
			rshS32PP = 0xadc02012,
			rshU64PP = 0xadc02013,
			rshS64PP = 0xadc02014,
			rshFloatPP = 0xadc02015,
			rshDoublePP = 0xadc02016,
			rshBoolPP = 0xadc02017,
			rshBufferTypeU8 = 0xadc03001,
			rshBufferTypeS8 = 0xadc03002,
			rshBufferTypeU16 = 0xadc03003,
			rshBufferTypeS16 = 0xadc03004,
			rshBufferTypeU32 = 0xadc03005,
			rshBufferTypeS32 = 0xadc03006,
			rshBufferTypeU64 = 0xadc03007,
			rshBufferTypeS64 = 0xadc03008,
			rshBufferTypeFloat = 0xadc03009,
			rshBufferTypeDouble = 0xadc0300a,
			rshBufferTypeBool = 0xadc0300b,
			rshBufferTypeChannel = 0xadc0300c,
			rshBufferTypePortInfo = 0xadc0300d,
			rshBufferTypeSetting = 0xadc0300e,
			rshBufferTypeSettingChannel = 0xadc0300f,
			rshDBufferTypeU8 = 0xadc03010,
			rshDBufferTypeS8 = 0xadc03011,
			rshDBufferTypeU16 = 0xadc03012,
			rshDBufferTypeS16 = 0xadc03013,
			rshDBufferTypeU32 = 0xadc03014,
			rshDBufferTypeS32 = 0xadc03015,
			rshDBufferTypeU64 = 0xadc03016,
			rshDBufferTypeS64 = 0xadc03017,
			rshDBufferTypeFloat = 0xadc03018,
			rshDBufferTypeDouble = 0xadc03019,
			rshDBufferTypeBool = 0xadc0301a,
			rshBufferTypeU8P = 0xadc0301b,
			rshBufferTypeDeviceBaseInfo = 0xadc0301c,
			rshBufferTypeDeviceFullInfo = 0xadc0301d,
			rshBufferTypeChannelVoltage = 0xadc0301e,
			rshBufferTypeCalibrationItem = 0xadc0301f,
			rshBufferTypeCalibrationGroup = 0xadc03020,
			rshInitADC = 0xadc04001,
			rshInitGSPF = 0xadc04002,
			rshInitDMA = 0xadc04003,
			rshInitMemory = 0xadc04004,
			rshInitVoltmeter = 0xadc04005,
			rshInitPort = 0xadc04006,
			rshInitPacket = 0xadc04007,
			rshInitDAC = 0xadc04008,
			rshInitTimer = 0xadc04009,
			rshRegister = 0xadc05001,
			rshPort = 0xadc05002,
			rshGatheringParameters = 0xadc05003,
			rshDeviceActiveList = 0xadc05004,
			rshOnboardBaseInfo = 0xadc05005,
			rshDeviceBaseInfo = 0xadc05006,
			rshDeviceFullInfo = 0xadc05007,
			rshDeviceBuffer = 0xadc05008,
			rshPortInfo = 0xadc05009,
			rshBoardPortInfo = 0xadc0500a,
			rshIFactory = 0xadc0500b,
			rshIRSHDevice = 0xadc0500c,
			rshChannel = 0xadc0500d,
			rshSynchroChannel = 0xadc0500e,
			rshCalibrationParameters = 0xadc0500f,
			rshCalibrationControl = 0xadc05010,
			rshIDebug = 0xadc05011,
			rshChannelVoltage = 0xadc05012,
			rshDeviceKey = 0xadc05013,
			rshCalibrationChannelParameter = 0xadc05014,
			rshCalibrationItemBase = 0xadc05015,
			rshCalibrationItemEntity = 0xadc05016,
			rshCalibrationItemRegister = 0xadc05017,
			rshCalibrationItemButton = 0xadc05018,
			rshCalibrationItemFilePath = 0xadc05019,
			rshBoardInfoDMA = 0xadc06001,
			rshBoardInfoMemory = 0xadc06002,
			rshBoardInfoDAC = 0xadc06003,
			rshBoardInfoDP = 0xadc06004,
			rshFRDACTune = 0xadc06005,
			rshDPADataFFTComplex = 0xadc07001,
			rshDPADataWindowFunction = 0xadc07002,
			rshDPADataFindGap = 0xadc07003,
			rshDPADataFindFront = 0xadc07004,
			rshDPADataGeneratorSignalBase = 0xadc07005,
		}
	}

	/// <summary>
	/// Возвращаемые функциями статусные коды.
	/// </summary>
	public enum RSH_API : uint
	{
		/// <summary>
		/// Ошибок нет.
		/// </summary>
		SUCCESS = 0x0,
		/// <summary>
		/// Неизвестная ошибка.
		/// </summary>
		UNDEFINED = 0x10000,
		/// <summary>
		/// Устройство не найдено в системе.
		/// </summary>
		DEVICE_NOTFOUND = 0x1010000,
		/// <summary>
		/// Устройство не было инициализировано.
		/// </summary>
		DEVICE_NOTINITIALIZED = 0x1020000,
		/// <summary>
		/// Не удалось загрузить библиотеку абстракции.
		/// </summary>
		DEVICE_DLLWASNOTLOADED = 0x1030000,
		/// <summary>
		/// Неверный индекс слота для устройства.
		/// </summary>
		DEVICE_WRONGPCIINDEX = 0x1040000,
		/// <summary>
		/// Неверный индекс USB входа для устройства.
		/// </summary>
		DEVICE_WRONGUSBINDEX = 0x1050000,
		/// <summary>
		/// На шине PCI не обнаружено ни одной поддерживаемой платы.
		/// </summary>
		DEVICE_NOBOARDONPCIBUS = 0x1060000,
		/// <summary>
		/// На шине USB не обнаружено ни одной поддерживаемой платы.
		/// </summary>
		DEVICE_NOBOARDONUSBBUS = 0x1070000,
		/// <summary>
		/// Неверно заданы входные параметры функции.
		/// </summary>
		DEVICE_PLXREGISTERSARENOTMAPPED = 0x1080000,
		/// <summary>
		/// Не удается получить данные с устройства.
		/// </summary>
		DEVICE_CANTGETDATA = 0x1090000,
		/// <summary>
		/// Не удается записать данные в устройство.
		/// </summary>
		DEVICE_CANTSETDATA = 0x10a0000,
		/// <summary>
		/// Не удается провести инициализацию устройства.
		/// </summary>
		DEVICE_CANTINITIALIZE = 0x10b0000,
		/// <summary>
		/// Не удается запустить устройство.
		/// </summary>
		DEVICE_CANTSTART = 0x10c0000,
		/// <summary>
		/// Не удается остановить устройство.
		/// </summary>
		DEVICE_CANTSTOP = 0x10d0000,
		/// <summary>
		/// Не удается создать экземпляр устройства.
		/// </summary>
		DEVICE_CANTCREATEINSTANCE = 0x10e0000,
		/// <summary>
		/// Нет экземпляра устройства.
		/// </summary>
		DEVICE_NOINSTANCE = 0x10f0000,
		/// <summary>
		/// Не загружен XILINX.
		/// </summary>
		DEVICE_LOADXILINX = 0x1100000,
		/// <summary>
		/// Функция не поддерживается платой.
		/// </summary>
		DEVICE_FUNCTION_NOTSUPPORTED = 0x1110000,
		/// <summary>
		/// Внутренний буфер не инициализирован.
		/// </summary>
		DEVICE_INTBUFFERNOTINITIALIZED = 0x1120000,
		/// <summary>
		/// Ревизия устройства не обнаружена.
		/// </summary>
		DEVICE_REVISIONNOTFOUND = 0x1130000,
		/// <summary>
		/// Неверный номер таймера устройства.
		/// </summary>
		DEVICE_WRONGTIMERNUMBER = 0x1140000,
		/// <summary>
		/// Устройство не было запущено.
		/// </summary>
		DEVICE_WASNOTSTARTED = 0x1150000,
		/// <summary>
		/// АЦП устройства остановлено по программному триггеру.
		/// </summary>
		DEVICE_STOPPEDWITHTRIGGER = 0x1160000,
		/// <summary>
		/// Не удалось выполнить команду IOCTL при работе с драйвером устройства.
		/// </summary>
		DEVICE_IOCTLFAILED = 0x1170000,
		/// <summary>
		/// К устройству не подключено питание.
		/// </summary>
		DEVICE_NOPOWER = 0x1180000,
		/// <summary>
		/// Несоответствие vid или pid.
		/// </summary>
		DEVICE_WRONGVIDORPID = 0x1190000,
		/// <summary>
		/// Устройство было ранее захвачено.
		/// </summary>
		DEVICE_ALREADYCAPTURED = 0x11a0000,
		/// <summary>
		/// Нарушена флеш память устройства.
		/// </summary>
		DEVICE_BADFLASH = 0x11b0000,
		/// <summary>
		/// Не удаётся завершить поток.
		/// </summary>
		THREAD_CANTTERMINATE = 0x2010000,
		/// <summary>
		/// Не удаётся создать поток.
		/// </summary>
		THREAD_CANTCREATE = 0x2020000,
		/// <summary>
		/// Сбор данных в потоке активен.
		/// </summary>
		THREAD_GATHERING_INPROCESS = 0x2030000,
		/// <summary>
		/// Сбор данных в потоке остановлен.
		/// </summary>
		THREAD_GATHERING_STOPPED = 0x2040000,
		/// <summary>
		/// Не удалось открыть файл.
		/// </summary>
		FILE_CANTOPEN = 0x3010000,
		/// <summary>
		/// Не удалось создать файл.
		/// </summary>
		FILE_CANTCREATE = 0x3020000,
		/// <summary>
		/// Имя файла не задано.
		/// </summary>
		FILE_NAMENOTDEFINED = 0x3030000,
		/// <summary>
		/// Файл с указанным именем уже существует.
		/// </summary>
		FILE_ALREADYEXISTS = 0x3040000,
		/// <summary>
		/// Не удалось записать данные в файл.
		/// </summary>
		FILE_CANTWRITE = 0x3050000,
		/// <summary>
		/// Не удалось прочитать данные из файла.
		/// </summary>
		FILE_CANTREAD = 0x3060000,
		/// <summary>
		/// Не удалось закрыть файл.
		/// </summary>
		FILE_CANTCLOSE = 0x3070000,
		/// <summary>
		/// Не удалось загрузить динамическую библиотеку.
		/// </summary>
		DLL_WASNOTLOADED = 0x4010000,
		/// <summary>
		/// Версия dll не поддерживается.
		/// </summary>
		DLL_VERSIONNOTSUPPORTED = 0x4020000,
		/// <summary>
		/// В загруженной dll не был обнаружен класс StaticFactory.
		/// </summary>
		DLL_NOFACTORY = 0x4030000,
		/// <summary>
		/// Критическая секция уже занята другим потоком.
		/// </summary>
		CRITSECTION_ALREADY_OWNED = 0x5010000,
		/// <summary>
		/// Критическая секция не инициализирована.
		/// </summary>
		CRITSECTION_NOTINITIALIZED = 0x5020000,
		/// <summary>
		/// Время ожидания наступления события истекло.
		/// </summary>
		EVENT_WAITTIMEOUT = 0x6010000,
		/// <summary>
		/// Не удалось активировать функцию ожидания события.
		/// </summary>
		EVENT_WAITFAILED = 0x6020000,
		/// <summary>
		/// Событие не инициализировано.
		/// </summary>
		EVENT_NOTINITIALIZED = 0x6030000,
		/// <summary>
		/// Не удалось деактивировать событие.
		/// </summary>
		EVENT_CANTRESET = 0x6040000,
		/// <summary>
		/// Не удалось активировать событие.
		/// </summary>
		EVENT_CANTSET = 0x6050000,
		/// <summary>
		/// Не удалось инициализировать событие.
		/// </summary>
		EVENT_CANTCREATE = 0x6060000,
		/// <summary>
		/// Адрес входного параметра равен 0.
		/// </summary>
		PARAMETER_ZEROADDRESS = 0x7010000,
		/// <summary>
		/// Параметр не инициализирован.
		/// </summary>
		PARAMETER_NOTINITIALIZED = 0x7020000,
		/// <summary>
		/// Параметр не поддерживается.
		/// </summary>
		PARAMETER_NOTSUPPORTED = 0x7030000,
		/// <summary>
		/// Неверный входной параметр.
		/// </summary>
		PARAMETER_INVALID = 0x7040000,
		/// <summary>
		/// Параметр данного типа данных не поддерживается.
		/// </summary>
		PARAMETER_DATATYPENOTSUPPORTED = 0x7050000,
		/// <summary>
		/// Тип запуска устройства не поддерживается.
		/// </summary>
		PARAMETER_STARTTYPEINVALID = 0x7060000,
		/// <summary>
		/// Не выбраны активные каналы.
		/// </summary>
		PARAMETER_CHANNELWASNOTSELECTED = 0x7070000,
		/// <summary>
		/// Каналов больше, чем поддерживается.
		/// </summary>
		PARAMETER_TOOMANYCHANNELS = 0x7080000,
		/// <summary>
		/// В структуре инициализации присутствуют не все каналы.
		/// </summary>
		PARAMETER_NOTENOUGHCHANNELS = 0x7090000,
		/// <summary>
		/// Неверный номер таймера
		/// </summary>
		PARAMETER_WRONGTIMERNUMBER = 0x70a0000,
		/// <summary>
		/// Неверный идентификатор устройства во входном параметре.
		/// </summary>
		PARAMETER_WRONGDEVICEHANDLE = 0x70b0000,
		/// <summary>
		/// Неверная комбинация активных каналов.
		/// </summary>
		PARAMETER_WRONGCHANNELCOMBINATION = 0x70c0000,
		/// <summary>
		/// Неверное количество каналов.
		/// </summary>
		PARAMETER_WRONGCHANNELNUMBER = 0x70d0000,
		/// <summary>
		/// Режим старта не поддерживается.
		/// </summary>
		PARAMETER_STARTMODENOTSUPPORTED = 0x70e0000,
		/// <summary>
		/// Режим конвертации данных не поддерживается.
		/// </summary>
		PARAMETER_DATAMODENOTSUPPORTED = 0x70f0000,
		/// <summary>
		/// Режим подключения не поддерживается.
		/// </summary>
		PARAMETER_CONNECTMODENOTSUPPORTED = 0x7100000,
		/// <summary>
		/// Режим работы устройства не поддерживается.
		/// </summary>
		PARAMETER_CONTROLINVALID = 0x7110000,
		/// <summary>
		/// входной предикат не поддерживается
		/// </summary>
		PARAMETER_WRONGPREDICATE = 0x7a50000,
		/// <summary>
		/// Значение параметра находится вне области допустимых значений.
		/// </summary>
		PARAMETER_OUTOFRANGE = 0x7a90000,
		/// <summary>
		/// Порядковый номер устройства задан неверно.
		/// </summary>
		PARAMETER_INVALIDDEVICEBASEINDEX = 0x7aa0000,
		/// <summary>
		/// Core Library указанного типа не существует.
		/// </summary>
		COREDLL_NOTEXISTS = 0x8010000,
		/// <summary>
		/// Core Library не была загружена.
		/// </summary>
		COREDLL_WASNOTLOADED = 0x8020000,
		/// <summary>
		/// В Core Library не найден StaticFactory.
		/// </summary>
		COREDLL_DLLNOFACTORY = 0x8030000,
		/// <summary>
		/// Core Library интерфейс не соответствует.
		/// </summary>
		COREDLL_INTERFACEDOESNOTMATCH = 0x8040000,
		/// <summary>
		/// Не удается открыть ветку реестра для Core Library.
		/// </summary>
		COREDLL_REGISTRYKEYCANTOPEN = 0x8050000,
		/// <summary>
		/// Не удается найти запись в реестре с полным путем к Core Library.
		/// </summary>
		COREDLL_REGISTRYPATHRECNOTFOUND = 0x8060000,
		/// <summary>
		/// Версия Core Library не поддерживается библиотекой абстракции.
		/// </summary>
		COREDLL_UNSUPPORTEDVERSION = 0x8070000,
		/// <summary>
		/// Внутренний поток сбора данных не остановлен.
		/// </summary>
		COREDLL_GATHERINGINPROCESS = 0x8110000,
		/// <summary>
		/// Сбор данных не был запущен.
		/// </summary>
		COREDLL_GATHERINGDIDNOTSTART = 0x8120000,
		/// <summary>
		/// Поток непрерывного сбора активен
		/// </summary>
		COREDLL_PERSISTENTGTHREADISACTIVE = 0x8130000,
		/// <summary>
		/// Данные не получены, буфер не заполнен
		/// </summary>
		COREDLL_COLLECTINGBUFFERZEROSIZE = 0x8140000,
		/// <summary>
		/// Не найдена ревизия устройства
		/// </summary>
		COREDLL_DEVICEREVISIONNOTFOUND = 0x8150000,
		/// <summary>
		/// Ревизия устройства не поддерживается.
		/// </summary>
		COREDLL_DEVICEREVISIONNOTSUPPORTED = 0x8160000,
		/// <summary>
		/// RSH_API_COREDLL_WRONGPORTNUMBER
		/// </summary>
		COREDLL_WRONGPORTNUMBER = 0x8170000,
		/// <summary>
		/// RSH_API_COREDLL_WRONGTIMERNUMBER
		/// </summary>
		COREDLL_WRONGTIMERNUMBER = 0x8180000,
		/// <summary>
		/// RSH_API_COREDLL_REGSPACEDOESNOTEXIST.
		/// </summary>
		COREDLL_REGSPACEDOESNOTEXIST = 0x8190000,
		/// <summary>
		/// Не задано пользовательское событие.
		/// </summary>
		COREDLL_USERBUFFEREVENTNOTDEFINED = 0x81a0000,
		/// <summary>
		/// Время ожидания готовности буфера истекло.
		/// </summary>
		COREDLL_USERBUFFERWAITTIMEOUT = 0x81b0000,
		/// <summary>
		/// Не удалось создать экземпляр класса PLX9054.
		/// </summary>
		COREDLL_CANTCREATEPLX9054CLASS = 0x8310000,
		/// <summary>
		/// Не удалось создать экземпляр класса PLX9050.
		/// </summary>
		COREDLL_CANTCREATEPLX9050CLASS = 0x8320000,
		/// <summary>
		/// Не удалось создать экземпляр класса PLX8311.
		/// </summary>
		COREDLL_CANTCREATEPLX8311CLASS = 0x8330000,
		/// <summary>
		/// Не удалось создать экземпляр класса RSHUSB.
		/// </summary>
		COREDLL_CANTCREATERSHUSBCLASS = 0x8340000,
		/// <summary>
		/// Не удалось создать экземпляр класса RSHVISA.
		/// </summary>
		COREDLL_CANTCREATERSHVISACLASS = 0x8350000,
		/// <summary>
		/// Функция не определена.
		/// </summary>
		FUNCTION_NOTDEFINED = 0x9010000,
		/// <summary>
		/// Произошла ошибка внутри функции.
		/// </summary>
		FUNCTION_ERRORHAPPEND = 0x9020000,
		/// <summary>
		/// Функция не поддерживается.
		/// </summary>
		FUNCTION_NOTSUPPORTED = 0x9030000,
		/// <summary>
		/// Get-код не определен внутри функции ::Get.
		/// </summary>
		FUNCTION_GETCODENOTDEFINED = 0x9040000,
		/// <summary>
		/// Буфер не инициализирован.
		/// </summary>
		BUFFER_NOTINITIALIZED = 0xa010000,
		/// <summary>
		/// Физический размер буфера равен нулю. Вероятно буфер не был инициализирован.
		/// </summary>
		BUFFER_ZEROSIZE = 0xa020000,
		/// <summary>
		/// Формат входного и выходного буфера не совпадает.
		/// </summary>
		BUFFER_INANDOUTMISMATCH = 0xa030000,
		/// <summary>
		/// Буфер с таким типом данных не поддерживается.
		/// </summary>
		BUFFER_WRONGDATATYPE = 0xa040000,
		/// <summary>
		/// Ошибка при проведении вычислений.
		/// </summary>
		BUFFER_PROCESSING_ERROR = 0xa050000,
		/// <summary>
		/// Объем данных в буфере превышает допустимый размер.
		/// </summary>
		BUFFER_SIZEISEXCEEDED = 0xa060000,
		/// <summary>
		/// Буфер пуст.
		/// </summary>
		BUFFER_ISEMPTY = 0xa070000,
		/// <summary>
		/// Размер копируемого буфера не соответствует размеру буфера, в который производится копирование.
		/// </summary>
		BUFFER_SIZEMISMATCH = 0xa080000,
		/// <summary>
		/// Буфер не заполнен до конца.
		/// </summary>
		BUFFER_NOTCOMPLETED = 0xa090000,
		/// <summary>
		/// Попытка выделения памяти размером 0 байт.
		/// </summary>
		BUFFER_ALLOCATIONZEROSIZE = 0xa0a0000,
		/// <summary>
		/// Размер буфера недостаточен для того, чтобы вместить все данные.
		/// </summary>
		BUFFER_INSUFFICIENTSIZE = 0xa0b0000,
		/// <summary>
		/// Объект не найден.
		/// </summary>
		OBJECT_NOTFOUND = 0xb010000,
		/// <summary>
		/// Ссылка на объект не найдена.
		/// </summary>
		OBJECT_REFERENCENOTFOUND = 0xb020000,
		/// <summary>
		/// Объект изменился.
		/// </summary>
		OBJECT_HASCHANGED = 0xb030000,
		/// <summary>
		/// Объект уже существует.
		/// </summary>
		OBJECT_ALREADYEXISTS = 0xb040000,
		/// <summary>
		/// Неподдерживаемый тип объекта.
		/// </summary>
		OBJECT_UNSUPPORTEDTYPE = 0xb050000,
		/// <summary>
		/// Не найдена запись в реестре.
		/// </summary>
		REGISTRY_KEYCANTOPEN = 0xc010000,
		/// <summary>
		/// Не найдена запись path в реестре.
		/// </summary>
		REGISTRY_PATHRECNOTFOUND = 0xc020000,
		/// <summary>
		/// Не найдена запись UIName в реестре.
		/// </summary>
		REGISTRY_UINAMERECNOTFOUND = 0xc030000,
		/// <summary>
		/// Интерфейс объекта в Dll не соответсвует запрашиваемому.
		/// </summary>
		INTERFACE_DOESNOTMATCH = 0xd010000,
		/// <summary>
		/// Не удается создать экземпляр объекта в фабрике.
		/// </summary>
		INTERFACE_CANTCREATEINSTANCE = 0xd020000,
		/// <summary>
		/// Интерфейс не был инициализирован.
		/// </summary>
		INTERFACE_WASNOTINITIALIZED = 0xd030000,
		/// <summary>
		/// Ошибка работы с памятью.
		/// </summary>
		MEMORY_ERROR = 0xe010000,
		/// <summary>
		/// Не удалось выделить память.
		/// </summary>
		MEMORY_ALLOCATIONERROR = 0xe020000,
		/// <summary>
		/// Сбой при копировании из одной области памяти в другую.
		/// </summary>
		MEMORY_COPYERROR = 0xe030000,
		/// <summary>
		/// Cбой в работе PLX API.
		/// </summary>
		PLXAPI_FAILED = 0xf010000,
		/// <summary>
		/// Параметр 0 PLX API.
		/// </summary>
		PLXAPI_NULLPARAM = 0xf020000,
		/// <summary>
		/// Функция PLX API не поддерживается.
		/// </summary>
		PLXAPI_UNSUPPORTEDFUNCTION = 0xf030000,
		/// <summary>
		/// В системе нет активного драйвера устройства.
		/// </summary>
		PLXAPI_NOACTIVEDRIVER = 0xf040000,
		/// <summary>
		/// PLX API - Ошибка доступа к конфигурации
		/// </summary>
		PLXAPI_CONFIGACCESSFAILED = 0xf050000,
		/// <summary>
		/// PLX API - неправильная информация об устройстве
		/// </summary>
		PLXAPI_INVALIDDEVICEINFO = 0xf060000,
		/// <summary>
		/// Версия PLX-драйвера не соответсвует версии используемой PLX-API.
		/// </summary>
		PLXAPI_INVALIDDRIVERVERSION = 0xf070000,
		/// <summary>
		/// RSH_API_PLXAPI_INVALIDOFFSET
		/// </summary>
		PLXAPI_INVALIDOFFSET = 0xf080000,
		/// <summary>
		/// RSH_API_PLXAPI_INVALIDDATA
		/// </summary>
		PLXAPI_INVALIDDATA = 0xf090000,
		/// <summary>
		/// RSH_API_PLXAPI_INVALIDSIZE
		/// </summary>
		PLXAPI_INVALIDSIZE = 0xf0a0000,
		/// <summary>
		/// RSH_API_PLXAPI_INVALIDADDRESS
		/// </summary>
		PLXAPI_INVALIDADDRESS = 0xf0b0000,
		/// <summary>
		/// RSH_API_PLXAPI_INVALIDACCESSTYPE
		/// </summary>
		PLXAPI_INVALIDACCESSTYPE = 0xf0c0000,
		/// <summary>
		/// RSH_API_PLXAPI_INVALIDINDEX
		/// </summary>
		PLXAPI_INVALIDINDEX = 0xf0d0000,
		/// <summary>
		/// RSH_API_PLXAPI_INVALIDPOWERSTATE
		/// </summary>
		PLXAPI_INVALIDPOWERSTATE = 0xf0e0000,
		/// <summary>
		/// RSH_API_PLXAPI_INVALIDIOPSPACE
		/// </summary>
		PLXAPI_INVALIDIOPSPACE = 0xf0f0000,
		/// <summary>
		/// RSH_API_PLXAPI_INVALIDHANDLE
		/// </summary>
		PLXAPI_INVALIDHANDLE = 0xf100000,
		/// <summary>
		/// RSH_API_PLXAPI_INVALIDPCISPACE
		/// </summary>
		PLXAPI_INVALIDPCISPACE = 0xf110000,
		/// <summary>
		/// RSH_API_PLXAPI_INVALIDBUSINDEX
		/// </summary>
		PLXAPI_INVALIDBUSINDEX = 0xf120000,
		/// <summary>
		/// RSH_API_PLXAPI_INSUFFICIENTRESOURCES
		/// </summary>
		PLXAPI_INSUFFICIENTRESOURCES = 0xf130000,
		/// <summary>
		/// PLX API Время ожидания готовности функции истекло.
		/// </summary>
		PLXAPI_WAITTIMEOUT = 0xf140000,
		/// <summary>
		/// RSH_API_PLXAPI_WAITCANCELED
		/// </summary>
		PLXAPI_WAITCANCELED = 0xf150000,
		/// <summary>
		/// RSH_API_PLXAPI_DMACHANNELUNAVAILABLE
		/// </summary>
		PLXAPI_DMACHANNELUNAVAILABLE = 0xf160000,
		/// <summary>
		/// RSH_API_PLXAPI_DMACHANNELINVALID
		/// </summary>
		PLXAPI_DMACHANNELINVALID = 0xf170000,
		/// <summary>
		/// RSH_API_PLXAPI_DMADONE
		/// </summary>
		PLXAPI_DMADONE = 0xf180000,
		/// <summary>
		/// PLX API - ПДП приостановлен.
		/// </summary>
		PLXAPI_DMAPAUSED = 0xf190000,
		/// <summary>
		/// PLX API - Канал ПДП занят.
		/// </summary>
		PLXAPI_DMAINPROGRESS = 0xf1a0000,
		/// <summary>
		/// PLX API - Неверная команда DMA.
		/// </summary>
		PLXAPI_DMACOMMANDINVALID = 0xf1b0000,
		/// <summary>
		/// RSH_API_PLXAPI_DMAINVALIDCHANNELPRIORITY
		/// </summary>
		PLXAPI_DMAINVALIDCHANNELPRIORITY = 0xf1c0000,
		/// <summary>
		/// RSH_API_PLXAPI_DMASGLPAGESGETERROR
		/// </summary>
		PLXAPI_DMASGLPAGESGETERROR = 0xf1d0000,
		/// <summary>
		/// RSH_API_PLXAPI_DMASGLPAGESLOCKERROR
		/// </summary>
		PLXAPI_DMASGLPAGESLOCKERROR = 0xf1e0000,
		/// <summary>
		/// RSH_API_PLXAPI_MUFIFOEMPTY
		/// </summary>
		PLXAPI_MUFIFOEMPTY = 0xf1f0000,
		/// <summary>
		/// RSH_API_PLXAPI_MUFIFOFULL
		/// </summary>
		PLXAPI_MUFIFOFULL = 0xf200000,
		/// <summary>
		/// RSH_API_PLXAPI_POWERDOWN
		/// </summary>
		PLXAPI_POWERDOWN = 0xf210000,
		/// <summary>
		/// RSH_API_PLXAPI_HSNOTSUPPORTED
		/// </summary>
		PLXAPI_HSNOTSUPPORTED = 0xf220000,
		/// <summary>
		/// RSH_API_PLXAPI_VPDNOTSUPPORTED
		/// </summary>
		PLXAPI_VPDNOTSUPPORTED = 0xf230000,
		/// <summary>
		/// RSH_API_PLXAPI_DEVICEINUSE
		/// </summary>
		PLXAPI_DEVICEINUSE = 0xf240000,
		/// <summary>
		/// RSH_API_PLXAPI_DEVICEDISABLED
		/// </summary>
		PLXAPI_DEVICEDISABLED = 0xf250000,
		/// <summary>
		/// RSH_API_PLXAPI_LASTERROR
		/// </summary>
		PLXAPI_LASTERROR = 0xf260000,
		/// <summary>
		/// RSH_API_PLXAPI_DEVICENOTINITIALIZED
		/// </summary>
		PLXAPI_DEVICENOTINITIALIZED = 0xf270000,
		/// <summary>
		/// PLX API - не удалось создать объект устройства
		/// </summary>
		PLXAPI_CANTCREATEDEVICEOBJECT = 0xf280000,
		/// <summary>
		/// Ошибка синтаксиса в скрипте
		/// </summary>
		SCRIPT_SYNTAXERROR = 0x10010000,
		/// <summary>
		/// RSH_API_SCRIPT_CANTEVALUATE
		/// </summary>
		SCRIPT_CANTEVALUATE = 0x10020000,
		/// <summary>
		/// RSH_API_SCRIPT_STARTFUNCTIONDOESNOTEXIST
		/// </summary>
		SCRIPT_STARTFUNCTIONDOESNOTEXIST = 0x10030000,
		/// <summary>
		/// Заданная функция не существует
		/// </summary>
		SCRIPT_FUNCTIONDOESNOTEXIST = 0x10040000,
		/// <summary>
		/// Не удалось открыть базу данных
		/// </summary>
		DATABASE_CANTOPEN = 0x11010000,
		/// <summary>
		/// База данных не откыта
		/// </summary>
		DATABASE_WASNOTOPENED = 0x11020000,
		/// <summary>
		/// Не удалось создать таблицу в базе данных
		/// </summary>
		DATABASE_CANTCREATETABLE = 0x11030000,
		/// <summary>
		/// Не удалось выполнить команду select
		/// </summary>
		DATABASE_CANTSELECTFROMTABLE = 0x11040000,
		/// <summary>
		/// Таблица пуста
		/// </summary>
		DATABASE_TABLEISEMPTY = 0x11050000,
		/// <summary>
		/// не удалось осуществить запись в базу данных
		/// </summary>
		DATABASE_CANTWRITERECORD = 0x11060000,
		/// <summary>
		/// Не удалось удалить запись из таблицы
		/// </summary>
		DATABASE_CANTDELETEFROMTABLE = 0x11070000,
		/// <summary>
		/// Запись уже существует в базе данных
		/// </summary>
		DATABASE_RECORDALREADYEXISTS = 0x11080000,
		/// <summary>
		/// Неправильный предикат
		/// </summary>
		DATABASE_WRONGPREDICATE = 0x11090000,
		/// <summary>
		/// Запись не найдена в базе данных
		/// </summary>
		DATABASE_RECORDNOTFOUND = 0x110a0000,
		/// <summary>
		/// Не найдено устройство типа вольтметр
		/// </summary>
		RSHLAB_VOLTMETERNOTFOUND = 0xfb010000,
		/// <summary>
		/// Не найдено устройство типа генератор
		/// </summary>
		RSHLAB_GENERATORNOTFOUND = 0xfb020000,
		/// <summary>
		/// Не найдено целевое устройство
		/// </summary>
		RSHLAB_TARGETDEVICENOTFOUND = 0xfb030000,
		/// <summary>
		/// Не удалось загрузить библиотеку RshUniDriver.dll
		/// </summary>
		UNIDRIVER_DLLWASNOTLOADED = 0xfc010000,
		/// <summary>
		/// библиотека DM.dll не загружена
		/// </summary>
		DM_DLLWASNOTLOADED = 0xfd010000,
		/// <summary>
		/// Не удалось загрузить алгоритмическую библиотеку DPA.dll
		/// </summary>
		DPA_DLLWASNOTLOADED = 0xfe010000,
		/// <summary>
		/// В сигнале не найден момент синхронизации удовлетворяющий заданным параметрам
		/// </summary>
		DPA_FINDTRIGGER_NOTFOUND = 0xfe020000,
		/// <summary>
		/// Тип структуры не соответсвует выполняемому алгоритму.
		/// </summary>
		DPA_FUNCTION_CLASS_MISMATCH = 0xfe030000,
		/// <summary>
		/// Алгоритмический класс выбранного типа не определен в библиотеке DPA.
		/// </summary>
		DPA_FUNCTION_CLASS_NOTDEFINED = 0xfe040000,
		/// <summary>
		/// Не удалось подключиться к драйверу VISA.
		/// </summary>
		VISA_CANTCONNECTTODRIVER = 0xff010000,
		/// <summary>
		/// Неизвестная ошибка при работе с сетью.
		/// </summary>
		NET_GENERALFAILURE = 0x12010000,
		/// <summary>
		/// Не удалось создать сокет.
		/// </summary>
		NET_COULDNTCREATESOCKET = 0x12020000,
		/// <summary>
		/// Не удалось создать event.
		/// </summary>
		NET_COULDNTCREATEEVENT = 0x12030000,
		/// <summary>
		/// Не удалось выполнить функцию select.
		/// </summary>
		NET_EVENTSELECTFAILED = 0x12040000,
		/// <summary>
		/// Не удалось открыть UDP сокет.
		/// </summary>
		NET_UDPSOCKETBINDFAILED = 0x12050000,
		/// <summary>
		/// Не удалось выполнить подключение через TCP сокет.
		/// </summary>
		NET_TCPSOCKETCONNECTFAILED = 0x12060000,
		/// <summary>
		/// Не удалось выполнить операцию получения данных из сокета.
		/// </summary>
		NET_SOCKETRECEIVEDATAFAILED = 0x12070000,
		/// <summary>
		/// Не удалось выполнить операцию отправки данных.
		/// </summary>
		NET_SOCKETSENDDATAFAILED = 0x12080000,
		/// <summary>
		/// Не удалось выполнить операцию закрытия сокета.
		/// </summary>
		NET_CLOSESOCKETFAILED = 0x12090000,
		/// <summary>
		/// Поле RshCalibrationItemBase::id не соответсвует ни одному RshCalibrationItem определённому внутри dll.
		/// </summary>
		CALIBRATION_ITEMNOTFOUND = 0x13010000,
	}

	/// <summary>
	/// Поддерживаемые платой функции.
	/// </summary>
	public enum RSH_CAPS : uint
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