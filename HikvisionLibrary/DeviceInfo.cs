using System;
using System.Runtime.InteropServices;

namespace HikvisionLibrary
{
    /// <summary>
    /// Структура параметров устройства.
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct DeviceInfo
    {
        /// <summary>
        /// Серийный номер.
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = Constants.SERIALNO_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sSerialNumber;
        /// <summary>
        /// Количество тревожных входов.
        /// </summary>
        public byte byAlarmInPortNum;
        /// <summary>
        /// Количество тревожных выходов.
        /// </summary>
        public byte byAlarmOutPortNum;
        /// <summary>
        /// Количество жестких дисков.
        /// </summary>
        public byte byDiskNum;
        /// <summary>
        /// Тип устройства.
        /// </summary>
        public byte byDVRType;
        /// <summary>
        /// Количество аналоговых каналов.
        /// </summary>
        public byte byChanNum;
        /// <summary>
        /// Номер начального канала, начинается с 1.
        /// </summary>
        public byte byStartChan;
        /// <summary>
        /// Количество двусторонних аудиоканалов.
        /// </summary>
        public byte byAudioChanNum;
        /// <summary>
        /// Максимальное количество цифровых каналов.
        /// </summary>
        public byte byIPChanNum;
        /// <summary>
        /// Количество нулевых каналов.
        /// </summary>
        public byte byZeroChanNum;
        /// <summary>
        /// Тип протокола передачи основного потока: 0 - частный, 1 - RTSP, 2 - частный и RTSP.
        /// </summary>
        public byte byMainProto;
        /// <summary>
        /// Тип протокола передачи подпотока: 0 - частный, 1 - RTSP, 2 - частный и RTSP.
        /// </summary>
        public byte bySubProto;
        /// <summary>
        /// Поддерживаемые режимы:
        /// 0 - не поддерживает.
        /// 0x1: поддерживает ли он интеллектуальный поиск.
        /// 0x2: поддерживает ли он резервное копирование.
        /// 0x4: поддерживает ли он возможность получения параметров сжатия.
        /// 0x8: поддерживает ли он мульти-сетевую карту.
        /// 0x10: поддерживает ли он SADP.
        /// 0x20: поддерживает ли он карту RAID.
        /// 0x40: будь то IP SAN поиск контента.
        /// 0x80: поддерживает ли он RTP поверх RTSP.
        /// </summary>
        public byte bySupport;
        /// <summary>
        /// Расширенный набор возможностей:
        /// 0 - не поддерживает.
        /// 0x1, поддерживает ли он SNMP v30.
        /// 0x2, поддерживает ли он различать воспроизведение и загрузку.
        /// 0x4, поддерживает ли он приоритет постановки на охрану.
        /// 0x8, поддерживает ли он увеличение периода постановки на охрану.
        /// 0x10, поддерживает ли он несколько дисков (более 33).
        /// 0x20, поддерживает ли он протокол RTSP через HTTP.
        /// 0x40, поддерживает ли он задержку просмотра в реальном времени.
        /// 0x80, поддерживает ли он новый тип информации о тревогах для интеллектуальной камеры слежения, он также указывает, поддерживать ли конфигурацию NET_DVR_IPPARACFG_V40.
        /// </summary>
        public byte bySupport1;
        /// <summary>
        /// Расширенный набор возможностей (Это поле не поддерживается при входе по протоколу ISAPI):
        /// 0 - не поддерживает.
        /// 0x1, поддерживает ли декодер получение потока по URL.
        /// 0x2, поддерживает FTPV40. 
        /// 0x4, поддержка ANR.
        /// </summary>
        public byte bySupport2;
        /// <summary>
        /// Тип устройств.
        /// </summary>
        public ushort wDevType;
        /// <summary>
        /// Расширенный набор возможностей (Это поле не поддерживается при входе по протоколу ISAPI):
        /// 0 - не поддерживает.
        /// 0x1: поддерживает ли он многопоточность.
        /// 0x4: поддерживает ли он конфигурацию по группам, включая: параметры изображения каналов, вход тревоги, доступ к входу / выходу тревоги IP, 
        /// пользовательские параметры, состояние устройства, захват JPEG, синхронизация и захват по времени, управление группами HDD и т. д.
        /// 0x20: поддерживает ли он получение потока по DDNS.
        /// </summary>
        public byte bySupport3;
        /// <summary>
        /// Поддерживает ли многопотоковый режим:
        /// 0 - не поддерживается.
        /// 1 - поддерживает, бит 1 - поток 3, бит 2 - поток 4, бит 7 - основной поток, бит 8 - подпоток.
        /// </summary>
        public byte byMultiStreamProto;
        /// <summary>
        /// Начальный номер цифрового канала, 0 недействителен.
        /// </summary>
        public byte byStartDChan;
        /// <summary>
        /// Запустить цифровой двусторонний аудиоканал №, 0-недействительный.
        /// </summary>
        public byte byStartDTalkChan;
        /// <summary>
        /// Количество цифровых каналов, старшие биты действительны.
        /// </summary>
        public byte byHighDChanNum;
        /// <summary>
        /// Поддерживаемые режимы:
        /// 0 - не поддерживает.
        /// 0x1: поддерживает ли он все типы потоков, RTSP, частный протокол.
        /// 0x10: поддерживает ли он монтирование сетевого жесткого диска по имени домена.
        /// </summary>
        public byte bySupport4;
        /// <summary>
        /// 
        /// </summary>
        public byte byLanguageType;
        /// <summary>
        /// Количество каналов ввода звука.
        /// </summary>
        public byte byVoiceInChanNum;
        /// <summary>
        /// Начать ввод аудиоканала №, 0-недействительный.
        /// </summary>
        public byte byStartVoiceInChanNo;
        /// <summary>
        /// 
        /// </summary>
        public byte bySupport5;
        /// <summary>
        /// 
        /// </summary>
        public byte bySupport6;
        /// <summary>
        /// Количество зеркальных каналов.
        /// </summary>
        public byte byMirrorChanNum;
        /// <summary>
        /// Начать зеркальный канал №
        /// </summary>
        public ushort wStartMirrorChanNo;
        /// <summary>
        /// 
        /// </summary>
        public byte bySupport7;
        /// <summary>
        /// Зарезервировано, установлено в 0.
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 9, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
    }
}
