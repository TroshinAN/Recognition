using System;
using System.Runtime.Serialization;

namespace IntLabLibrary
{

    #region LibraryType
    /// <summary>
    /// Тип библиотеки.
    /// </summary>
    public enum LibraryType
    {
        /// <summary>
        /// Не определён.
        /// </summary>
        INVALID = 0,
        /// <summary>
        /// Пассажирский вагон.
        /// </summary>
        COACH,
        /// <summary>
        /// Грузовой контейнер.
        /// </summary>
        CONTAINER,
        /// <summary>
        /// Многострочный номер вагона.
        /// </summary>
        UIC,
        /// <summary>
        /// Однострочный номер вагона.
        /// </summary>
        WAGON,
        /// <summary>
        /// Номерной знак автотранспорта.
        /// </summary>
        AUTO_LPR,
        /// <summary>
        /// Категория, марка , модель автотранспорта.
        /// </summary>
        AUTO_MMR
    };
    #endregion

    #region LicenseType
    /// <summary>
    /// Тип лицензии обработки входного потока изображений.
    /// </summary>
    public enum LicenseType : int
    {
        /// <summary>
        /// Не определено.
        /// </summary>
        [EnumMember(Value = "UNKNOW")]
        UNKNOW = 0,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "ireIMAGE")]
        IMAGE = 1,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "ireVIDEO")]
        VIDEO = 2,
    }
    #endregion

    #region ImageFormat
    /// <summary>
    /// Формат изображения.
    /// </summary>
    public enum ImageFormat : int
    {
        /// <summary>
        /// Не определено.
        /// </summary>
        [EnumMember(Value = "Unknown")]
        UNKNOW = 0,
        /// <summary>
        /// JPG изображение.
        /// </summary>
        [EnumMember(Value = "JPG")]        
        JPG = 1,
        /// <summary>
        /// Растровое изображение.
        /// </summary>
        [EnumMember(Value = "RAW_GRAY")]
        RAW_GRAY = 100
    }
    #endregion

    #region AggregatorEventType
    /// <summary>
    /// Тип события синхронизации.
    /// </summary>
    public enum AggregatorEventType
    {
        /// <summary>
        /// Не определено.
        /// </summary>
        [EnumMember(Value = "Unknown")]
        UNKNOWN = 0,
        /// <summary>
        /// Начальная точка отсчета по целевому объекту распознавания, может быть перезаписана.
        /// </summary>
        [EnumMember(Value = "ObjectStartingPoint")]
        OBJECT_STARTING_POINT = 1,
        /// <summary>
        /// Конечная точка отсчета по целевому объекту распознавания, по мере готовности выдается консолидированный результат в GetResult с eResultReason::ObjectEndingPoint
        /// </summary>
        [EnumMember(Value = "ObjectEndingPoint")]
        OBJECT_ENDING_POINT = 2,
        /// <summary>
        /// Начальная точка отсчета для формирования консолидированного результата распознавания по отрезку времени, может быть перезаписана.
        /// </summary>
        [EnumMember(Value = "SegmentStartingPoint")]
        SEGMENT_STARTING_POINT = 3,
        /// <summary>
        /// Конечная точка отсчета для формирования консолидированного результата распознавания по отрезку времени, по факту готовности выдается консолидированный результат в GetResult с eResultReason::SegmentEndingPoint
        /// </summary>
        [EnumMember(Value = "SegmentEndingPoint")]
        SEGMENT_ENDING_POINT = 4,
        /// <summary>
        /// Запрос на получение в GetResult промежуточного консолидированного результата (тяжелая операция, не рекомендуется вызывать часто, для оптимального использования рекомендуется использовать
        /// IntermediateConfidentResultRequest). Ответ на запрос возвращается в GetResult по факту его готовности с соответствующим значением eResultReason::IntermediateResultRequest.
        /// </summary>
        [EnumMember(Value = "IntermediateResultRequest")]
        INTERMEDIATE_RESULT_REQUEST = 5,
        /// <summary>
        /// Запрос на получение в GetResult первого надежного промежуточного результата. Ответ на запрос возвращается в GetResult по факту его готовности с соответствующим значением 
        /// eResultReason::IntermediateConfidentResultRequest.
        /// </summary>
        [EnumMember(Value = "IntermediateConfidentResultRequest")]
        INTERMEDIATE_CONFIDENT_RESULT_REQUEST = 6
    }
    #endregion

    #region ColorPolarity
    /// <summary>
    /// Черно-белый цвет для символов.
    /// </summary>
    public enum ColorPolarity : int
    {
        /// <summary>
        /// Не определено.
        /// </summary>
        [EnumMember(Value = "Unknown")]
        UNKNOWN = 0,
        /// <summary>
        /// Темные символы на светлом фоне.
        /// </summary>
        [EnumMember(Value = "BlackOnWhite")]
        BLACK_ON_WHITE = 1,
        /// <summary>
        /// Светлые символы на темном фоне.
        /// </summary>
        [EnumMember(Value = "WhiteOnBlack")]
        WHITE_ON_BLACK = 2,
        /// <summary>
        /// Комбинация вышеперечисленных вариантов.
        /// </summary>
        [EnumMember(Value = "Combined")]
        COMBINED = 3
    }
    #endregion

    #region RecognizedType
    /// <summary>
    /// Тип распознанного номера.
    /// </summary>
    public enum RecognizedType : int
    {
        /// <summary>
        /// Не определено.
        /// </summary>
        [EnumMember(Value = "Unknown")]
        UNKNOWN = 0,
        /// <summary>
        /// Номер обнаружен и полностью распознан, распознанный номер удовлетворяет контрольному алгоритму
        /// </summary>
        [EnumMember(Value = "FullRecognized")]
        FULL_RECOGNIZED = 1,
        /// <summary>
        /// Номер найден и полностью распознан, но результат распознавания не удовлетворяет контрольному алгоритму.
        /// </summary>
        [EnumMember(Value = "FullRecognizedCheckSumFailed")]
        FULL_RECOGNISED_CHECK_SUM_FAILED = 2,
        /// <summary>
        /// Номер распознан не полностью, но при этом найдено или эвристически вычислено положение всех символов (например, 5xx98301,5*x98301).
        /// </summary>
        [EnumMember(Value = "PartialRecognizedEstimated")]
        PARTIAL_RECOGNIZED_ESTIMATED = 3,
        /// <summary>
        /// Распознано, найдено и эвристически вычислено только часть номера (например, 5019x).
        /// </summary>
        [EnumMember(Value = "PartialRecognized")]
        PARTIAL_RECOGNIZED = 4,
        /// <summary>
        /// Номер не обнаружен.
        /// </summary>
        [EnumMember(Value = "FullUnrecognized")]
        FULL_UNRECOGNIZED = 5
    }
    #endregion

    #region VelocityUnit
    /// <summary>
    /// Размерность для скорости объекта.
    /// </summary>
    public enum VelocityUnit : int
    {
        /// <summary>
        /// Направление движения не определено.
        /// </summary>
        [EnumMember(Value = "Unknown")]
        UNKNOWN = 0,
        /// <summary>
        /// Скорость имеет размерность [метры за секунду].
        /// </summary>
        [EnumMember(Value = "MetersPerSecond")]
        METERS_PER_SECOND = 1,
        /// <summary>
        /// Скорость имеет размерность [пиксели за секунду].
        /// </summary>
        [EnumMember(Value = "PixelsPerSecond")]
        PIXELS_PER_SECOND = 2
    }
    #endregion

    #region MoveDirection
    /// <summary>
    /// Направление движения объекта.
    /// </summary>
    public enum MoveDirection : int
    {
        /// <summary>
        /// Направление движения не определено.
        /// </summary>
        [EnumMember(Value = "Unknown")]
        UNKNOWN = 0,
        /// <summary>
        /// Движение вверх.
        /// </summary>
        [EnumMember(Value = "Up")]
        UP = 1,
        /// <summary>
        /// Движение вниз.
        /// </summary>
        [EnumMember(Value = "Down")]
        DOWN = 2,
        /// <summary>
        /// Движение влево.
        /// </summary>
        [EnumMember(Value = "Left")]
        LEFT = 3,
        /// <summary>
        /// Движение вправо.
        /// </summary>
        [EnumMember(Value = "Right")]
        RIGHT = 4,
        /// <summary>
        /// Движение на камеру.
        /// </summary>
        [EnumMember(Value = "Towards")]
        TOWARDS = 5,
        /// <summary>
        /// Движение от камеры.
        /// </summary>
        [EnumMember(Value = "Backward")]
        BACKWARD = 6
    }
    #endregion

    #region ResultReason
    /// <summary>
    /// Основание выдачи результата распознавания.
    /// </summary>
    public enum ResultReason : int
    {
        /// <summary>
        /// Не определено.
        /// </summary>
        [EnumMember(Value = "Unknown")]
        UNKNOWN = 0,
        /// <summary>
        /// Объект остановился в поле зрения камеры.
        /// </summary>
        [EnumMember(Value = "ObjectStopped")]
        OBJECT_STOPPED = 1,
        /// <summary>
        /// Объект покинул поле зрения камеры.
        /// </summary>
        [EnumMember(Value = "ObjectRunOutOfFrame")]
        OBJECT_RUN_OUT_OF_FRAME = 2,
        /// <summary>
        /// Объект не был обнаружен в течении установленного тайм-аута.
        /// </summary>
        [EnumMember(Value = "ObjectTimeOut")]
        OBJECT_TIME_OUT = 3,
        /// <summary>
        /// Real-time результат распознавания по кадру без глубокой аналитики.
        /// </summary>
        [EnumMember(Value = "FrameRoughRec")]
        FRAME_ROUGH_REC = 4,
        /// <summary>
        /// Максимально качественный, но более медленный в получении результат распознавания по кадру.
        /// </summary>
        [EnumMember(Value = "FrameFineRec")]
        FRAME_FINE_REC = 5,
        /// <summary>
        /// Консолидированный результат распознавания по объекту по факту выхода объекта из зоны контроля.
        /// </summary>
        [EnumMember(Value = "ObjectEndingPoint")]
        OBJECT_ENDING_POINT = 6,
        /// <summary>
        /// Запрос из вызывающего кода на выдачу промежуточного результата по факту окончания интервала распознавания
        /// </summary>
        [EnumMember(Value = "SegmentEndingPoint")]
        SEGMENT_ENDING_POINT = 7,
        /// <summary>
        /// Консолидированный результат распознавания по объекту сформированный ASAP по запросу из вызывающего кода.
        /// </summary>
        [EnumMember(Value = "IntermediateResultRequest")]
        INTERMEDIATE_RESULT_REQUEST = 8,
        /// <summary>
        /// Консолидированный результат распознавания по объекту сформированный по факту получения надежного результата распознавания по объекту.
        /// </summary>
        [EnumMember(Value = "IntermediateConfidentResultRequest")]
        INTERMEDIATE_CONFIDENT_RESULT_REQUEST = 9
    }
    #endregion

    #region SimilarityType
    /// <summary>
    /// Тип совпадения распознанного номера списку номеров из базы знаний агрегатора.
    /// </summary>
    public enum SimilarityType : int
    {
        /// <summary>
        /// Не определено.
        /// </summary>
        [EnumMember(Value = "Unknown")]
        UNKNOWN = 0,
        /// <summary>
        /// Ни один похожий номер в списке не найден.
        /// </summary>
        [EnumMember(Value = "NumberNotFound")]
        NUMBER_NOT_FOUND = 1,
        /// <summary>
        /// В списке найден номер полностью совпадающий с распознанным.
        /// </summary>
        [EnumMember(Value = "NumberFoundEqual")]
        NUMBER_FOUND_EQUAL = 2,
        /// <summary>
        /// В списке найден один наиболее похожий номер, остальные номера отличаются больше.
        /// </summary>
        [EnumMember(Value = "NumberFoundSimilar")]
        NUMBER_FOUND_SIMILAR = 4,
        /// <summary>
        /// В списке найдено несколько номеров, равноудалённых от распознанного,
        /// возвращается в комбинации с флагом NumberNotFound, результат при этом не формируется.
        /// </summary>
        [EnumMember(Value = "NumberFoundAmbiguous")]
        NUMBER_FOUND_AMBIGUOUS = 8
    }
    #endregion

    #region ReturnCode
    /// <summary>
    /// Код ошибки.
    /// </summary>
    internal enum ReturnCode : int
    {
        /// <summary>
        /// Функция выполнена успешно.
        /// </summary>
        DONE = 0,

        /// <summary>
        /// Недостаточно памяти для сохранения результата чтения данных из библиотеки IRE_XYZ.
        /// </summary>
        INSUFFICIENT_MEMORY = 2,
        /// <summary>
        /// Кадр был пропущен без обработки.
        /// </summary>
        FRAME_SKIPPED = 3,

        /// <summary>
        /// Недопустимый вызов объекта. Возможно нарушена последовательность вызовов, или объект не инициализирован должным образом.
        /// </summary>
        INVALID_STATE = -1,
        /// <summary>
        /// Попытка доступа к несуществующему объекту. Ошибка подобного рода может привести к тяжелым последствиям.
        /// </summary>
        INVALID_HANDLE = -2,
        /// <summary>
        /// Входные данные заданны с ошибкой, например: отсутствуют обязательные поля структур или таблиц, тип полей несовместимы, вместо ожидаемого числа введена строка или же входные данные выходят за границы ожидаемых диапазонов.
        /// </summary>
        INVALID_INPUT_ARGUMENT = -3,
        /// <summary>
        /// Входные данные имеют несовместимый тип и процедура разбора входных данных завершилась с ошибкой.
        /// </summary>
        INCOMPATIBLE_DATA_TYPE = -4,
        /// <summary>
        /// Входные данные имеют нарушения на бинарном уровне или несовместимы с алгоритмом обработки, например нарушена контрольная суммы или ошибка в заголовке графического файла.
        /// </summary>
        CORRUPTED_DATA = -5,

        /// <summary>
        /// Проблемы с подключением к USB ключу.
        /// </summary>
        DONGLE_NOT_FOUND = -100,

        /// <summary>
        /// Обнаружено логически противоречивое внутренне состояния внутри библиотеки IRE_XYZ.
        /// </summary>
        FATAL = -1000,
        /// <summary>
        /// Критические ошибки, причина которых не может быть ясно установлена. Возникает при обнаружении утечки исключений за границы исполняемого кода, 
        /// а так же при ошибках на границе внешнего интерфейса IRE_XYZ, где система перехвата ошибок не действует.
        /// </summary>
        PANIC = -1001,
        /// <summary>
        /// Обнаружено нарушение условий многопоточного исполнения со стороны пользователя. Библиотеки IRE_XYZ не поддерживают многопоточное обращения к методам экземпляра с одним и тем же идентификатором handle. 
        /// </summary>
        THEAD_VIOLATION = -1002,
        /// <summary>
        /// То же, что ire_rc_thread_violation, но проблема много-поточного исполнения обнаружена после фактического нарушения.
        /// </summary>
        FATAL_DEFERRED = -1003,
        /// <summary>
        /// Нарушены условия лицензионного соглашения для лицензий данного типа.
        /// </summary>
        LICENSE_VIOLATION = -2000
    };
    #endregion
}
