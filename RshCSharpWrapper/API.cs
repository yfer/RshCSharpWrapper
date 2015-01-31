using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RshCSharpWrapper
{

    /// <summary>
    /// Возвращаемые функциями статусные коды.
    /// </summary>
    public enum API : uint
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
        /// Размер буфера задан неверно.
        /// </summary>
        BUFFER_WRONGSIZE = 0xa0c0000,
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
        /// Серийный номер платы не прописан в EEPROM.
        /// </summary>
        PLXAPI_EEPROMNOSERIAL = 0xf290000,
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
}
