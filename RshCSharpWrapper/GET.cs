using System;
using System.Collections.Generic;
using RshCSharpWrapper.Types;
using Double = RshCSharpWrapper.Types.Double;

namespace RshCSharpWrapper
{
    /// <summary>
    /// Коды для получения дополнительной информации об устройстве и библиотеке.
    /// </summary>
    /// Таблицы соответствий взяты отсюда: http://rudshel.ru/soft/SDK2/Doc/RSHUNIDRIVER_C_RU/html/_rsh_consts_8h.html#a89a326bf9f936379d19de8e46e4c56d5
    public enum GET : uint
    {
        /// <summary>
        /// Проверка готовности данных в случае одиночного преобразования.
        /// Тип данных: [out] ::RSH_U32
        /// Полученные данные: 1 - было получено прерывание по готовности данных, 0 - прерывание не было получено. Если перед вызовом метода Device.Get() с данным кодом был запущен сбор данных, можно узнать, готова ли уже очередная порция данных.
        /// Прим.
        /// Данный код проверяет текущее (на момент вызова метода Device.Get()) состояние события, если нужно организовать цикл ожидания готовности данных, лучше воспользоваться кодом RSH_GET_WAIT_BUFFER_READY_EVENT.
        /// </summary>
        [Mode(typeof(U32))]
        BUFFER_READY = 0x10001,
        
        /// <summary>
        /// Ожидание завершения процесса сбора и передачи данных.
        /// Тип данных: [in] ::RSH_U32
        /// После запуска процесса сбора данных, можно вызвать метод Device.Get() с этим параметром и ожидать события готовности данных. Второй параметр в методе Device.Get() задает максимальное время ожидания (таймаут) в мс. Можно использовать константу RSH_INFINITE_WAIT_TIME для бесконечного ожидания.
        /// Прим.
        /// По сути, данный метод аналогичен вызову функции WaitForSingleObject из WinAPI, но его реализация кроссплатформенная.
        /// Предупреждения
        /// Вызов данного метода блокирует вызывающий поток до тех пор, пока не будет получено событие готовности данных, или таймаут! Если используется константа RSH_INFINITE_WAIT_TIME, единственный способ отменить ожидание и разблокировать поток - это вызов метода IRshDevice::Stop().
        /// </summary>
        [Mode(typeof(U32), Input = true)]
        WAIT_BUFFER_READY_EVENT = 0x20001,

        /// <summary>
        /// Ожидание завершения процесса непрервыного сбора данных.
        /// Тип данных: [in] ::RSH_U32
        /// После вызова метода IRshDevice::Stop() при работе в непрерывном режиме может пройти какое-то время до того момента, когда сбор будет фактически остановлен. Используя данную константу можно быть уверенным в том, что процесс сбора данных полностью остановлен, прежде чем выполнять какие-либо другие действия.
        /// Второй параметр в методе Device.Get() задает максимальное время ожидания (таймаут) в мс.Можно использовать константу RSH_INFINITE_WAIT_TIME для бесконечного ожидания.
        /// Прим.
        /// В большинстве случаев можно обойтись без вызова данного метода, но он может быть очень полезен для синхронизации потоков в сложных приложениях.
        /// </summary>
        [Mode(typeof(U32), Input = true)]
        WAIT_GATHERING_COMPLETE = 0x20002,
        
        WAIT_NANO_DELAY = 0x20003,
        WAIT_INTERRUPT0 = 0x20004,
        WAIT_INTERRUPT1 = 0x20005,
        /// <summary>
        /// Получение идентификационного кода устройства.
        /// Тип данных: [out] ::RSH_U32
        /// Каждое устройство расширения, подключаемое к компьютеру, имеет уникальный (для данной модели устройства) код устройства (product ID или PID) и код производителя (vendor ID или VID). Операционная система использует данные коды для идентифиакции устройства и выбора драйвера для него.
        /// Используя метод Device.Get() с данной константой, можно получить код оборудования для устройства.
        /// </summary>
        [Mode(typeof(U32))]
        DEVICE_PID = 0x30001,
        
        /// <summary>
        /// Получение идентификационного кода производителя устройства.
        /// Тип данных: [out] ::RSH_U32
        /// Каждое устройство расширения, подключаемое к компьютеру, имеет уникальный (для данной модели устройства) код устройства (product ID или PID) и код производителя (vendor ID или VID). Операционная система использует данные коды для идентифиакции устройства и выбора драйвера для него.
        /// Используя метод Device.Get() с данной константой, можно получить код производителя устройства.
        /// </summary>
        [Mode(typeof(U32))]
        DEVICE_VID = 0x30002,
        
        /// <summary>
        /// Получение полного имени библиотеки абстракции.
        /// Тип данных: [out] ::RSH_S8P
        /// Получение указателя на строковую константу с именем библиотеки абстракции. Так как возвращается указатель, выделять память под строку дополнительно не нужно.
        /// </summary>
        [Mode(typeof(S8P))]
        DEVICE_NAME_VERBOSE = 0x30003,
        
        /// <summary>
        /// Аналог RSH_GET_DEVICE_NAME_VERBOSE в формате юникод.
        /// Тип данных: [out] ::RSH_U16P
        /// Получение строки с названием библиотеки в формате UTF-16.
        /// </summary>
        [Mode(typeof(U16P))]
        DEVICE_NAME_VERBOSE_UTF16 = 0x30004,
        
        /// <summary>
        /// Вместо этого свойства используйте Device.IsCapable()
        /// 
        /// Определение возможностей устройства и библиотеки.
        /// Тип данных: [in] ::RSH_U32
        /// Используя данную константу, можно проверить, поддерживает ли устройство и библиотека различные аппаратные и программные режимы работы и возможности. Код свойства, поддержку которого нужно проверить, должен передаваться в качестве второго параметра метода Device.Get().
        /// Прим.
        /// Полный список свойств можно посмотреть здесь.
        /// </summary>
        [Mode(typeof(U32), Input = true)]
        DEVICE_IS_CAPABLE = 0x30005,
        
        /// <summary>
        /// Получение списка допустимых базовых адресов.
        /// Тип данных: [out] ::RSH_BUFFER_U32
        /// Если в системе установлено несколько устройств одного типа, для выбора конкретного устройства используется базовый адрес. Базовые адреса выдаются операционной системой, и зависят от слота (порта) подключения, а также порядка включения устройств.
        /// Используя данную константу, можно получить этот список в виде массива целых чисел.
        /// Прим.
        /// Полученные базовые адреса можно использовать в методе IRshDevice::Connect().
        /// </summary>
        [Mode(typeof(BufferU32))]
        DEVICE_BASE_LIST = 0x30006,

        /// <summary>
        /// Получение списка устройств с дополнительной информацией.
        /// Тип данных: [out] ::RSH_BUFFER_DEVICE_BASE_INFO
        /// Данная константа используется для тех же целей, что и RSH_GET_DEVICE_BASE_LIST. Но, в отличие от нее, возвращается не просто список допустимых базовых адресов, а массив структур RshDeviceBaseInfo. Структура RshDeviceBaseInfo содержит, помимо базового адреса, дополнительную информацию о подключенном устройстве - используемый PCI слот, коды оборудования и производителя, ревизию, заводской номер.
        /// </summary>
        DEVICE_BASE_LIST_EXT = 0x30007,
        
        
        /// <summary>
        /// Минимально возможная частота дискретизации, генерируемая таймером
        /// Тип данных: [out] ::RSH_DOUBLE
        /// </summary>
        [Mode(typeof(BufferDouble))]
        DEVICE_MIN_FREQUENCY = 0x30008,
        
        /// <summary>
        /// Максимально возможная частота дискретизации, генерируемая таймером
        /// Тип данных: [out] ::RSH_DOUBLE
        /// </summary>
        [Mode(typeof(BufferDouble))]
        DEVICE_MAX_FREQUENCY = 0x30009,
        
        /// <summary>
        /// Минимальное значение амплитуды (МЗР)
        /// Тип данных: [out] ::RSH_S32
        /// </summary>
        [Mode(typeof(S32))]
        DEVICE_MIN_AMP_LSB = 0x3000a,
        
        /// <summary>
        /// Максимальное значение амплитуды (МЗР)
        /// Тип данных: [out] ::RSH_S32
        /// </summary>
        [Mode(typeof(S32))]
        DEVICE_MAX_AMP_LSB = 0x3000b,
        
        /// <summary>
        /// Таблица допустимых частот квантования
        /// Тип данных: [out] ::RSH_BUFFER_DOUBLE
        /// </summary>
        [Mode(typeof(BufferDouble))]
        DEVICE_FREQUENCY_LIST = 0x3000c,
        
        /// <summary>
        /// Размер в байтах, необходимый для записи одного значения
        /// Тип данных: [out] ::RSH_U32
        /// </summary>
        [Mode(typeof(U32))]
        DEVICE_DATA_SIZE_BYTES = 0x3000d,
        
        /// <summary>
        /// Разрядность АЦП (или ЦАП)
        /// Тип данных: [out] ::RSH_U32
        /// </summary>
        [Mode(typeof(U32))]
        DEVICE_DATA_BITS = 0x3000e,
        
        /// <summary>
        /// Количество аналоговых каналов
        /// Тип данных: [out] ::RSH_U32
        /// </summary>
        [Mode(typeof(U32))]
        DEVICE_NUMBER_CHANNELS = 0x3000f,
        
        /// <summary>
        /// Количество каналов в базовом устройстве
        /// Тип данных: [out] ::RSH_U32
        /// Актуально для систем и составных устройств (например, многоканальные осциллографы).
        /// </summary>
        [Mode(typeof(U32))]
        DEVICE_NUMBER_CHANNELS_BASE = 0x30010,
        
        /// <summary>
        /// Список допустимых коэффициентов усиления для аналоговых каналов.
        /// Тип данных: [out] ::RSH_BUFFER_U32
        /// </summary>
        [Mode(typeof(BufferU32))]
        DEVICE_GAIN_LIST = 0x30011,
        
        /// <summary>
        /// Получение массива с коэффициентами усиления для входа 50Ом
        /// Тип данных: [out] ::RSH_BUFFER_U32
        /// </summary>
        [Mode(typeof(BufferU32))]
        DEVICE_GAIN_LIST_50_OHM = 0x30012,
        
        /// <summary>
        /// Получение массива с коэффициентами усиления для входа 1МОм
        /// Тип данных: [out] ::RSH_BUFFER_U32
        /// </summary>
        [Mode(typeof(BufferU32))]
        DEVICE_GAIN_LIST_1_MOHM = 0x30013,
        
        /// <summary>
        /// Размер памяти, установленной на плате (или доступной для сбора)
        /// Тип данных: [out] ::RSH_U32
        /// </summary>
        [Mode(typeof(U32))]
        DEVICE_MEMORY_SIZE = 0x30014,
        
        /// <summary>
        /// Список допустимых размеров блоков собираемых данных
        /// Тип данных: [out] ::RSH_BUFFER_U32
        /// </summary>
        [Mode(typeof(BufferU32))]
        DEVICE_SIZE_LIST = 0x30015,
        
        /// <summary>
        /// Список допустимых размеров буфера в простом режиме работы (без использования удвоения/учетверения частоты)
        /// Тип данных: [out] ::RSH_BUFFER_U32
        /// </summary>
        [Mode(typeof(BufferU32))]
        DEVICE_SIZE_LIST_SINGLE = 0x30016,
        
        /// <summary>
        /// Список допустимых размеров буфера в режиме удвоения
        /// Тип данных: [out] ::RSH_BUFFER_U32
        /// </summary>
        [Mode(typeof(BufferU32))]
        DEVICE_SIZE_LIST_DOUBLE = 0x30017,
        
        /// <summary>
        /// Список допустимых размеров буфера в режиме учетверения
        /// Тип данных: [out] ::RSH_BUFFER_U32
        /// </summary>
        [Mode(typeof(BufferU32))]
        DEVICE_SIZE_LIST_QUADRO = 0x30018,
        
        /// <summary>
        /// Список допустимых размеров пакетов
        /// Тип данных: [out] ::RSH_BUFFER_U32
        /// </summary>
        [Mode(typeof(BufferU32))]
        DEVICE_PACKET_LIST = 0x30019,
        
        /// <summary>
        /// Входной диапазон в вольтах при коэффициенте усиления 1.
        /// Тип данных: [out] ::RSH_DOUBLE
        /// </summary>
        [Mode(typeof(Double))]
        DEVICE_INPUT_RANGE_VOLTS = 0x3001a,
        
        /// <summary>
        /// Выходной диапазон в вольтах при коэффициенте усиления 1 (без использования аттенюатора)
        /// Тип данных: [out] ::RSH_DOUBLE
        /// </summary>
        [Mode(typeof(Double))]
        DEVICE_OUTPUT_RANGE_VOLTS = 0x3001b,
        
        /// <summary>
        /// Список допустимых коэффициентов усиления для входа внешней синхронизации
        /// Тип данных: [out] ::RSH_BUFFER_U32
        /// </summary>
        [Mode(typeof(BufferU32))]
        DEVICE_EXT_SYNC_GAINLIST = 0x3001c,
        
        /// <summary>
        /// олучение массива с коэффициентами усиления внешней синхронизации для входа 50Ом
        /// Тип данных: [out] ::RSH_BUFFER_U32
        /// </summary>
        [Mode(typeof(BufferU32))]
        DEVICE_EXT_SYNC_GAIN_LIST_50_OHM = 0x3001d,
        
        /// <summary>
        /// Получение массива с коэффициентами усиления внешней синхронизации для входа 1МОм
        /// Тип данных: [out] ::RSH_BUFFER_U32       
        /// </summary>
        [Mode(typeof(BufferU32))]
        DEVICE_EXT_SYNC_GAIN_LIST_1_MOHM = 0x3001e,
        
        /// <summary>
        /// Диапазон входа внешней синхронизации в вольтах при коэффициенте усиления 1.
        /// Тип данных: [out] ::RSH_DOUBLE
        /// </summary>
        [Mode(typeof(Double))]
        DEVICE_EXT_SYNC_INPUT_RANGE_VOLTS = 0x3001f,
        
        /// <summary>
        /// Получeние структуры из со служебной информацией о портах
        /// Тип данных: [out] RshBoardPortInfo       
        /// </summary>
        [Mode(typeof(BoardPortInfo))]
        DEVICE_PORT_INFO = 0x30020,
        
        /// <summary>
        /// Получение заводского номера устройства
        /// Тип данных: [out] ::RSH_U32
        /// </summary>
        [Mode(typeof(U32))]
        DEVICE_SERIAL_NUMBER = 0x30021,
        
        /// <summary>
        /// Размер предыстории в отсчетах
        /// Тип данных: [out] ::RSH_U32        
        /// </summary>
        [Mode(typeof(U32))]
        DEVICE_PREHISTORY_SIZE = 0x30022,
        
        /// <summary>
        /// Количество каналов, выбраных для работы
        /// Тип данных: [out] ::RSH_U32
        /// Количество каналов, выбраных для работы (доступно после вызова метода IRshDevice::Init() )
        /// </summary>
        [Mode(typeof(U32))]
        DEVICE_ACTIVE_CHANNELS_NUMBER = 0x30023,
        
        /// <summary>
        /// Проверка статуса подключения для USB устройств
        /// Тип данных: [in] NULL
        /// Проверка статуса подключения для USB устройств. Второй параметр игнорируется.
        /// </summary>
        DEVICE_PLUG_STATUS = 0x30024,
        
        /// <summary>
        /// Получение списка активных устройств
        /// Тип данных: [out] ::RSH_BUFFER_DEVICE_FULL_INFO
        /// Получение списка устройств ЗАО "Руднев-Шиляев", подключенных (установленных) в данный момент.
        /// Список заполняется на основании данных, получаемых от операционной системы.
        /// </summary>
        DEVICE_ACTIVE_LIST = 0x30025,
        
        /// <summary>
        /// Запуск процесса автоматической калибровки
        /// Тип данных: [in] NULL
        /// Производит автоматическую калибровку для тех устройств, которые поддерживают данную возможность
        /// </summary>
        DEVICE_AUTO_CALIBRATION_SET = 0x30026,
        
        /// <summary>
        /// Управление ICP-питанием аналоговых каналов
        /// Тип данных: [in] ::RSH_U32
        /// Управление ICP-питанием. Соответствующий каналу бит = 0 - нет питания, = 1 - есть питание
        /// Необходимо сделать:
        /// Возможно, требуется доработка (данная опция только у Леонардо 2)
        /// </summary>
        [Mode(typeof(U32), Input = true)]
        DEVICE_ICP_POWER_SET = 0x30027,
        
        /// <summary>
        /// RSH_GET_DEVICE_AVR_MODE_SET.
        /// НЕ РЕАЛИЗОВАНО в текущей версии
        /// Необходимо сделать:
        /// RSH_GET_DEVICE_AVR_MODE_SET
        /// </summary>
        DEVICE_AVR_MODE_SET = 0x30028,
        
        /// <summary>
        /// Чтение из регистра устройства
        /// Тип данных: [out] RshRegister
        /// </summary>
        DEVICE_REGISTER_BOARD = 0x30029,
        
        /// <summary>
        /// Запись в регистр устройства
        /// Тип данных: [in] RshRegister
        /// Запись в регистр устройства
        /// </summary>
        DEVICE_REGISTER_BOARD_SET = 0x3002a,
        
        /// <summary>
        /// Чтение из регистра устройства plx9050 (диапазон памяти 1)
        /// Тип данных: [out] RshRegister
        /// Чтение из регистра устройства plx9050 (диапазон памяти 1)
        /// </summary>
        DEVICE_REGISTER_BOARD_SPACE1 = 0x3002b,
        
        /// <summary>
        /// Запись в регистр устройства plx9050 (диапазон памяти 1)
        /// Тип данных: [in] RshRegister
        /// </summary>
        DEVICE_REGISTER_BOARD_SPACE1_SET = 0x3002c,
        
        /// <summary>
        /// Чтение из регистра устройства plx9050 (диапазон памяти 2)
        /// Тип данных: [out] RshRegister
        /// </summary>
        DEVICE_REGISTER_BOARD_SPACE2 = 0x3002d,
        
        /// <summary>
        /// Запись в регистр устройства plx9050 (диапазон памяти 2)
        /// Тип данных: [in] RshRegister
        /// </summary>
        DEVICE_REGISTER_BOARD_SPACE2_SET = 0x3002e,
        
        /// <summary>
        /// Минимальное количество отсчетов (размер буфера) на канал
        /// Тип данных: [out] ::RSH_U32
        /// </summary>
        [Mode(typeof(U32))]
        DEVICE_MIN_SAMPLES_PER_CHANNEL = 0x3002f,
                
        /// <summary>
        /// Максимальное количество отсчетов (размер буфера) на канал
        /// Тип данных: [out] ::RSH_U32
        /// </summary>
        [Mode(typeof(U32))]
        DEVICE_MAX_SAMPLES_PER_CHANNEL = 0x30030,
        
        /// <summary>
        /// Сброс устройства, освобождение захваченных устройством ресурсов
        /// Тип данных: [in] NULL
        /// </summary>
        DEVICE_RESET = 0x30031,
        
        /// <summary>
        /// Состояние питания устройства
        /// Тип данных: [in] NULL
        /// Проверка статуса питания (для устройств с внешним питанием). Второй параметр игнорируется.
        /// </summary>
        DEVICE_POWER_STATUS = 0x30032,
        
        /// <summary>
        /// Получение списка активных устройств (расширенная информация)
        /// Предупреждения
        /// В текущей версии не реализовано!
        /// Необходимо сделать:
        /// Возможно, следует удалить данный код
        /// </summary>
        DEVICE_ACTIVE_LIST_EXT = 0x30033,
                
        /// <summary>
        /// Получение данных GPS.
        /// Тип данных: [out] ::RSH_S8P
        /// Формат строки зависит от устройства (чипа GPS). Как правило, данные представляют собой строку вида:
        /// GGA,123519,4807.038,N,01131.324,E,1,08,0.9,545.4,M,46.9,M, , *42< >
        /// (пример для NMEA-0183). Подробное описание формата можно найти в руководстве пользователя для устройства.
        /// </summary>
        [Mode(typeof(S8P))]
        DEVICE_GPS_DATA = 0x30034,
        
        /// <summary>
        /// Получение данных GPS (Unicode)
        /// Тип данных: [out] ::RSH_U16P
        /// Аналог RSH_GET_DEVICE_GPS_DATA но в формате UTF-16.
        /// </summary>
        [Mode(typeof(U16P))]
        DEVICE_GPS_DATA_UTF16 = 0x30035,
        
        /// <summary>
        /// Установка интервала автозапуска
        /// Тип данных: [out] ::RSH_U32
        /// Используется для задания интервала автоматического запуска сбора данных, для тех устройств, которые поддерживают данную возможность.
        /// </summary>
        [Mode(typeof(U32))]
        DEVICE_AUTO_START_INTERVAL_SET = 0x30036,
        
        /// <summary>
        /// Получение текущего значения напряжения питания
        /// Тип данных: [out] ::RSH_DOUBLE
        /// Получение текущего значения напряжения питания в вольтах.
        /// Как правило, применияется для устройств с автономным питанием.
        /// </summary>
        [Mode(typeof(Double))]
        DEVICE_POWER_SOURCE_VOLTAGE = 0x30037,
        
        /// <summary>
        /// Версия SDK major.
        /// Тип данных: [out] ::RSH_U32
        /// </summary>
        [Mode(typeof(U32))]
        SDK_VERSION_MAJOR = 0x40001,
        
        /// <summary>
        /// Версия SDK minor.
        /// Тип данных: [out] ::RSH_U32
        /// </summary>
        [Mode(typeof(U32))]
        SDK_VERSION_MINOR = 0x40002,
        
        /// <summary>
        /// Строковая константа с версией SDK.
        /// Тип данных: [out] ::RSH_S8P
        /// </summary>
        [Mode(typeof(S8P))]
        SDK_VERSION_STRING = 0x40003,
        
        /// <summary>
        /// Строковая константа - название организации
        /// Тип данных: [out] ::RSH_S8P
        /// </summary>
        [Mode(typeof(S8P))]
        SDK_COPYRIGHT_STRING = 0x40004,
        
        /// <summary>
        /// Строковая константа с версией SDK (Unicode)
        /// Тип данных: [out] ::RSH_U16P
        /// </summary>
        [Mode(typeof(U16P))]
        SDK_COPYRIGHT_STRING_UTF16 = 0x40005,
        
        /// <summary>
        /// Строковая константа - название организации (Unicode)
        /// Тип данных: [out] ::RSH_U16P
        /// </summary>
        [Mode(typeof(U16P))]
        SDK_VERSION_STRING_UTF16 = 0x40006,
        
        /// <summary>
        /// Получение версии библиотеки - major.
        /// Тип данных: [out] ::RSH_U32
        /// </summary>
        [Mode(typeof(U32))]
        LIBRARY_VERSION_MAJOR = 0x50001,
        
        /// <summary>
        /// Получение версии библиотеки - minor.
        /// Тип данных: [out] ::RSH_U32
        /// </summary>
        [Mode(typeof(U32))]
        LIBRARY_VERSION_MINOR = 0x50002,
        
        /// <summary>
        /// Получение версии библиотеки - build.
        /// Тип данных: [out] ::RSH_U32
        /// </summary>
        [Mode(typeof(U32))]
        LIBRARY_VERSION_BUILD = 0x50003,
        
        /// <summary>
        /// Получение версии библиотеки - date.
        /// Тип данных: [out] ::RSH_U32
        /// </summary>
        [Mode(typeof(U32))]
        LIBRARY_VERSION_DATE = 0x50004,
        
        /// <summary>
        /// Строковая константа - имя интерфейса
        /// Тип данных: [out] ::RSH_S8P
        /// 
        /// </summary>        
        [Mode(typeof(S8P))]
        LIBRARY_INTERFACE_NAME = 0x50005,
        
        /// <summary>
        /// Строковая константа - имя интерфейса (Unicode)
        /// Тип данных: [out] ::RSH_U16P
        /// </summary>
        [Mode(typeof(U16P))]
        LIBRARY_INTERFACE_NAME_UTF16 = 0x50006,
        
        /// <summary>
        /// Строковая константа - имя модуля
        /// Тип данных: [out] ::RSH_S8P
        /// </summary>
        [Mode(typeof(S8P))]
        LIBRARY_MODULE_NAME = 0x50007,
        
        /// <summary>
        /// Строковая константа - имя модуля (Unicode)
        /// Тип данных: [out] ::RSH_U16P
        /// </summary>
        [Mode(typeof(U16P))]
        LIBRARY_MODULE_NAME_UTF16 = 0x50008,
        
        /// <summary>
        /// Строковая константа - путь размещения файла библиотеки
        /// Тип данных: [out] ::RSH_S8P
        /// </summary>
        [Mode(typeof(S8P))]
        LIBRARY_PATH = 0x50009,
        
        /// <summary>
        /// Строковая константа - путь размещения файла библиотеки (Unicode)
        /// Тип данных: [out] ::RSH_U16P
        /// </summary>
        [Mode(typeof(U16P))]
        LIBRARY_PATH_UTF16 = 0x5000a,
        
        /// <summary>
        /// Строковая константа - имя файла библиотеки абстракции
        /// Тип данных: [out] ::RSH_S8P
        /// </summary>
        [Mode(typeof(S8P))]
        LIBRARY_FILENAME = 0x5000b,
        
        /// <summary>
        /// Строковая константа - имя файла библиотеки абстракции (Unicode)
        /// Тип данных: [out] ::RSH_U16P
        /// </summary>
        [Mode(typeof(U16P))]
        LIBRARY_FILENAME_UTF16 = 0x5000c,
        
        /// <summary>
        /// Строковая константа - версия библиотеки абстракции
        /// Тип данных: [out] ::RSH_S8P
        /// </summary>
        [Mode(typeof(S8P))]
        LIBRARY_VERSION_STR = 0x5000d,
        
        /// <summary>
        /// Строковая константа - версия библиотеки абстракции (Unicode)
        /// Тип данных: [out] ::RSH_U16P
        /// </summary>
        [Mode(typeof(U16P))]
        LIBRARY_VERSION_STR_UTF16 = 0x5000e,
        
        /// <summary>
        /// Строковая константа - описание библиотеки (как в свойствах файла)
        /// Тип данных: [out] ::RSH_S8P
        /// </summary>
        [Mode(typeof(S8P))]
        LIBRARY_DESCRIPTION = 0x5000f,
        
        /// <summary>
        /// Строковая константа - описание библиотеки (Unicode)
        /// Тип данных: [out] ::RSH_U16P
        /// </summary>
        [Mode(typeof(U16P))]
        LIBRARY_DESCRIPTION_UTF16 = 0x50010,
        
        /// <summary>
        /// Строковая константа - внутреннее имя библиотеки (как в свойствах файла)
        /// Тип данных: [out] ::RSH_S8P
        /// </summary>
        [Mode(typeof(S8P))]
        LIBRARY_PRODUCT_NAME = 0x50011,
        
        /// <summary>
        /// Строковая константа - внутреннее имя библиотеки (Unicode)
        /// Тип данных: [out] ::RSH_U16P
        /// </summary>
        [Mode(typeof(U16P))]
        LIBRARY_PRODUCT_NAME_UTF16 = 0x50012,
        
        /// <summary>
        /// Получение версии базовой библиотеки - major.
        /// Тип данных: [out] ::RSH_U32
        /// </summary>
        [Mode(typeof(U32))]
        CORELIB_VERSION_MAJOR = 0x60001,
        
        /// <summary>
        /// Получение версии базововй библиотеки - minor.
        /// Тип данных: [out] ::RSH_U32
        /// </summary>
        [Mode(typeof(U32))]
        CORELIB_VERSION_MINOR = 0x60002,
        
        /// <summary>
        /// Получение версии базововй библиотеки - build.
        /// Тип данных: [out] ::RSH_U32
        /// </summary>
        [Mode(typeof(U32))]
        CORELIB_VERSION_BUILD = 0x60003,
        
        /// <summary>
        /// Получение версии базововй библиотеки - date.
        /// Тип данных: [out] ::RSH_U32
        /// </summary>
        [Mode(typeof(U32))]
        CORELIB_VERSION_DATE = 0x60004,
        
        /// <summary>
        /// Строковая константа - имя интерфейса базовой библиотеки
        /// Тип данных: [out] ::RSH_S8P
        /// </summary>
        [Mode(typeof(S8P))]
        CORELIB_INTERFACE_NAME = 0x60005,
        
        /// <summary>
        /// Строковая константа - имя интерфейса базовой библиотеки (Unicode)
        /// Тип данных: [out] ::RSH_U16P
        /// </summary>
        [Mode(typeof(U16P))]
        CORELIB_INTERFACE_NAME_UTF16 = 0x60006,
        
        /// <summary>
        /// Строковая константа - имя модуля базовой библиотеки
        /// Тип данных: [out] ::RSH_S8P
        /// </summary>
        [Mode(typeof(S8P))]
        CORELIB_MODULE_NAME = 0x60007,
        
        /// <summary>
        /// Строковая константа - имя модуля базовой библиотеки (Unicode)
        /// Тип данных: [out] ::RSH_U16P
        /// </summary>
        [Mode(typeof(U16P))]
        CORELIB_MODULE_NAME_UTF16 = 0x60008,
        
        /// <summary>
        /// Строковая константа - путь размещения файла базовой библиотеки
        /// Тип данных: [out] ::RSH_S8P
        /// </summary>
        [Mode(typeof(S8P))]
        CORELIB_PATH = 0x60009,
        
        /// <summary>
        /// Строковая константа - путь размещения файла базовой библиотеки (Unicode)
        /// Тип данных: [out] ::RSH_U16P
        /// </summary>
        [Mode(typeof(U16P))]
        CORELIB_PATH_UTF16 = 0x6000a,
        
        /// <summary>
        /// Строковая константа - имя файла базовой библиотеки
        /// Тип данных: [out] ::RSH_S8P
        /// </summary>
        [Mode(typeof(S8P))]
        CORELIB_FILENAME = 0x6000b,
        
        /// <summary>
        /// Строковая константа - имя файла базовой библиотеки (Unicode)
        /// Тип данных: [out] ::RSH_U16P
        /// </summary>
        [Mode(typeof(U16P))]
        CORELIB_FILENAME_UTF16 = 0x6000c,
        
        /// <summary>
        /// Строковая константа - версия базовой библиотеки
        /// Тип данных: [out] ::RSH_S8P
        /// </summary>
        [Mode(typeof(S8P))]
        CORELIB_VERSION_STR = 0x6000d,
        
        /// <summary>
        /// Строковая константа - версия базовой библиотеки Unicode)
        /// Тип данных: [out] ::RSH_U16P
        /// </summary>
        [Mode(typeof(U16P))]
        CORELIB_VERSION_STR_UTF16 = 0x6000e,
        
        /// <summary>
        /// Строковая константа - описание базовой библиотеки (как в свойствах файла)
        /// Тип данных: [out] ::RSH_S8P
        /// </summary>
        [Mode(typeof(S8P))]
        CORELIB_DESCRIPTION = 0x6000f,
        
        /// <summary>
        /// Строковая константа - описание базовой библиотеки (Unicode)
        /// Тип данных: [out] ::RSH_U16P
        /// </summary>
        [Mode(typeof(U16P))]
        CORELIB_DESCRIPTION_UTF16 = 0x60010,
        
        /// <summary>
        /// Строковая константа - внутреннее имя базовой библиотеки (как в свойствах файла)
        /// Тип данных: [out] ::RSH_S8P
        /// </summary>
        [Mode(typeof(S8P))]
        CORELIB_PRODUCT_NAME = 0x60011,
        
        /// <summary>
        /// Строковая константа - внутреннее имя базовой библиотеки (Unicode)
        /// Тип данных: [out] ::RSH_U16P
        /// </summary>
        [Mode(typeof(U16P))]
        CORELIB_PRODUCT_NAME_UTF16 = 0x60012,
        
        /// <summary>
        /// Версия API драйвера (актуально для PLX устройств)
        /// Тип данных: [out] ::RSH_U32
        /// </summary>
        [Mode(typeof(U32))]
        CORELIB_VERSION_INTERNAL_API = 0x60013,
        
        /// <summary>
        /// Версия API драйвера в виде строки
        /// Тип данных: [out] ::RSH_S8P
        /// </summary>
        [Mode(typeof(S8P))]
        CORELIB_VERSION_INTERNAL_API_STR = 0x60014,
        
        /// <summary>
        /// Версия API драйвера в виде строки (Unicode)
        /// Тип данных: [out] ::RSH_U16P
        /// </summary>
        [Mode(typeof(U16P))]
        CORELIB_VERSION_INTERNAL_API_STR_UTF16 = 0x60015,

        RESET_WAIT_INTERRUPT0 = 0x70001,
        RESET_WAIT_INTERRUPT1 = 0x70002,

        /// <summary>
        /// Установка плана БПФ ESTIMATE_FORWARD.
        /// Тип данных: [in] ::RSH_U32
        /// Модуль DPA_FFT, установка плана БПФ ESTIMATE_FORWARD. В качестве данных - желаемый размер буфера.
        /// </summary>
        [Mode(typeof(U32), Input = true)]
        DPA_FFT_NEW_FFT_PLAN_ESTIMATE_FORWARD_SET = 0xb0001,
        
        /// <summary>
        /// Установка плана БПФ ESTIMATE_BACKWARD.
        /// Тип данных: [in] ::RSH_U32
        /// Модуль DPA_FFT, установка плана БПФ ESTIMATE_BACKWARD. В качестве данных - желаемый размер буфера.
        /// </summary>
        [Mode(typeof(U32), Input = true)]
        DPA_FFT_NEW_FFT_PLAN_ESTIMATE_BACKWARD_SET = 0xb0002,
        
        /// <summary>
        /// Установка плана БПФ MEASURE_FORWARD.
        /// Тип данных: [in] ::RSH_U32
        /// Модуль DPA_FFT, установка плана БПФ MEASURE_FORWARD. В качестве данных - желаемый размер буфера.
        /// </summary>
        [Mode(typeof(U32), Input = true)]
        DPA_FFT_NEW_FFT_PLAN_MEASURE_FORWARD_SET = 0xb0003,
        
        /// <summary>
        /// Установка плана БПФ MEASURE_BACKWARD.
        /// Тип данных: [in] ::RSH_U32
        /// Модуль DPA_FFT, установка плана БПФ MEASURE_BACKWARD. В качестве данных - желаемый размер буфера.
        /// </summary>
        [Mode(typeof(U32), Input = true)]
        DPA_FFT_NEW_FFT_PLAN_MEASURE_BACKWARD_SET = 0xb0004,
        
        /// <summary>
        /// Установка плана БПФ PATIENT_FORWARD.
        /// Тип данных: [in] ::RSH_U32
        /// Модуль DPA_FFT, установка плана БПФ PATIENT_FORWARD. В качестве данных - желаемый размер буфера.
        /// </summary>
        [Mode(typeof(U32), Input = true)]
        DPA_FFT_NEW_FFT_PLAN_PATIENT_FORWARD_SET = 0xb0005,
        
        /// <summary>
        /// Установка плана БПФ PATIENT_BACKWARD.
        /// Тип данных: [in] ::RSH_U32
        /// Модуль DPA_FFT, установка плана БПФ PATIENT_BACKWARD. В качестве данных - желаемый размер буфера.
        /// </summary>
        [Mode(typeof(U32), Input = true)]
        DPA_FFT_NEW_FFT_PLAN_PATIENT_BACKWARD_SET = 0xb0006,
        
        LIBRARY_FREE_RESOURCES = 0x10050001,
        
        DEVICE_STATE = 0x10030009
    }
           
    [AttributeUsage(AttributeTargets.All)]
    public class ModeAttribute : Attribute
    {        
        public Type Type;
        public bool Input = false;
        public ModeAttribute(Type type)
        {
            Type = type;
        }
    }
    public static class GETHelper
    {
        /// <summary>
        /// Возвращает режимы для Device.Get отвечающие условию Selector
        /// </summary>
        /// <param name="Selector">Описание интересующих параметров режима</param>
        /// <returns>Список подходящих режимов</returns>
        public static IEnumerable<GET> GetModes(Func<ModeAttribute,bool> Selector)
        {
            foreach (var mode in Enum.GetValues(typeof(GET)))
            {
                var fi = typeof(GET).GetField( mode.ToString() );
                var attr = (ModeAttribute)Attribute.GetCustomAttribute(fi, typeof(ModeAttribute));
                if (attr != null && Selector(attr))
                    yield return (GET)mode;
            }
        }
    }    
}
