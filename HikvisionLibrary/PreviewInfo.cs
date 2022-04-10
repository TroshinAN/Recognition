using System;
using System.Runtime.InteropServices;

namespace HikvisionLibrary
{
    /// <summary>
    /// Структура параметров предварительного просмотра.
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct PreviewInfo
    {
        /// <summary>
        /// Номер аналогового канала начинается с 1, начальный номер IP-канала.
        /// </summary>
        public Int32 lChannel;
        /// <summary>
        /// Тип потока: 0-основной поток, 1-дополнительный поток, 2-поток 3, 3-виртуальный поток и т. Д.
        /// </summary>
        public uint dwStreamType;
        /// <summary>
        /// Режим соединения: 0-TCP, 1-UDP, 2-многоадресная, 3-RTP, 4-RTP / RTSP, 5-RSTP / HTTP, 6-HRUDP.
        /// </summary>
        public uint dwLinkMode;
        /// <summary>
        /// Дескриптор воспроизведения, NULL - без декодирования и отображения.
        /// </summary>
        public IntPtr hPlayWnd;
        /// <summary>
        /// 0 - получение неблокирующего потока, 1 - получение блокирующего потока. если это блок, то в случае сбоя соединения в SDK будет возвращаться тайм-аут 5 с, 
        /// это не подходит для получения потока запроса.
        /// </summary>
        public bool bBlocked;
        /// <summary>
        /// 0 - отключить передачу видео, 1 - включить передачу видео. обратное отслеживание, когда ANR отключен - устройства отправляют данные автоматически после 
        /// восстановления сети между клиентом и устройствами (требуется поддержка устройств).
        /// </summary>
        public bool bPassbackRecord;
        /// <summary>
        /// Режим предварительного просмотра: 0 - обычный предварительный просмотр, 1 - предварительный просмотр с задержкой.
        /// </summary>
        public byte byPreviewMode;
        /// <summary>
        /// Идентификатор потока, комбинация буквы, числа и '_', включить параметр, когда lChannel = 0xffffffff.
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = Constants.STREAM_ID_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byStreamID;
        /// <summary>
        /// Протокол прикладного уровня: 0 - частный протокол, 1 - RTSP. Протокол, поддерживаемый основным потоком, получается от MainProto, SubProto из NET_DVR_DEVICEINFO_V30. 
        /// Параметр действителен, когда устройства поддерживают приватный и RTSP одновременно. По умолчанию приватный (RTSP необязательно)
        /// </summary>
        public byte byProtoType;
        /// <summary>
        /// Зарезервировано, пожалуйста, установите его на 0.
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        /// <summary>
        /// Тип кодирования видео: 0- Общие данные кодирования, 1- Исходные данные, сгенерированные термодетектором (зашифрованные данные о температуре, 
        /// вы можете получить фактическую температуру с помощью арифметики шифрования)
        /// </summary>
        public byte byVideoCodingType;
        /// <summary>
        /// Максимальное количество кадров в буфере SDK плеера, диапазон значений: 1, 6 (по умолчанию, режим самоадаптации), 15. Значение 1 при установке на 0.
        /// </summary>
        public uint dwDisplayBufNum;
        /// <summary>
        /// Зарезервировано.
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 216, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
   }
}
