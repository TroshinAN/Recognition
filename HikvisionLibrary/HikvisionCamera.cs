using System;
using System.Diagnostics;

namespace HikvisionLibrary
{
    /// <summary>
    /// Класс для работы с видеокамерой Hikvision
    /// </summary>
    public class HikvisionCamera
    {
        /// <summary>
        /// Метод передачи сообщения пользователю.
        /// </summary>
        public Action<string> MessageForUser = delegate { };

        /// <summary>
        /// Делегат функции обратного вызова получения потока данных.
        /// </summary>
        /// <param name="realHandle">Дескриптор потока данных</param>
        /// <param name="dataType">Тип данных.</param>
        /// <param name="buffer">Буфер данных.</param>
        /// <param name="bufSize">Размер буфера данных.</param>
        /// <param name="userHandle">Дескриптор пользователя</param>
        public delegate void REALDATACALLBACK(int realHandle, uint dataType, IntPtr buffer, int bufSize, IntPtr userHandle);

        /// <summary>
        /// Инициализация библиотеки.
        /// </summary>
        /// <returns>Указывает. удачно ли произведена инициализация.</returns>
        public bool Initialisation()
        {
            var result = BaseDll.NET_DVR_Init();

            if (result)
            {
                MessageForUser("Библиотека видеопотока инициализирована.");
            }
            else
            {
                MessageForUser("Не удалось инициализировать Библиотеку видеопотока.");
            }

            return result;
        }

        /// <summary>
        /// Отключение от библиотеки.
        /// </summary>
        /// <returns>Указывает, удачно ли произведено отключение.</returns>
        public bool Cleanup()
        {
            var result = BaseDll.NET_DVR_Cleanup();

            if (result)
            {
                MessageForUser("Отключение от библиотеки видеопотока произведено.");
            }
            else
            {
                MessageForUser("Не удалось отключиться от библиотеки видеопотока.");
            }

            return result;
        }

        /// <summary>
        /// Вход пользователя для устройства.
        /// </summary>
        /// <param name="address">IP-адрес или статическое доменное имя устройства, количество символов должно быть не более 128.</param>
        /// <param name="portNumber">Порт №. устройства.</param>
        /// <param name="userName">Имя пользователя.</param>
        /// <param name="password">Пароль.</param>
        /// <param name="deviceInfo">Информация об устройстве.</param>
        /// <returns>Возвращает -1, если вход не удался, а другое значение - это значение возвращенного идентификатора пользователя. 
        /// Идентификатор пользователя является уникальным, и следующие операции должны осуществляться через этот идентификатор.</returns>
        public int Login(string address, Int32 portNumber, string userName, string password, ref DeviceInfo deviceInfo)
        {
            var result = BaseDll.NET_DVR_Login_V30(address, portNumber, userName, password, ref deviceInfo);

            if (result < 0)
            {
                MessageForUser($"Не удалось авторизоваться пользователю '{userName}'. Код ошибки {GetLastError()}");
            }

            return result;
        }

        /// <summary>
        /// Отключение пользователя от устройства.
        /// </summary>
        /// <param name="userID">Идентификатор пользователя.</param>
        /// <returns>Указывает, удачно ли произведено отключение пользователя.</returns>
        public bool Logout(int userID)
        {
            return BaseDll.NET_DVR_Logout(userID);
        }

        /// <summary>
        /// Начать просмотр в реальном времени. (используется для устройства, чтобы получить поток напрямую через URL ISAPI).
        /// </summary>
        /// <param name="userID">Уникальный идентификатор пользователя.</param>
        /// <param name="previewInfo">Параметры предварительного просмотра.</param>
        /// <param name="realDataCallBack">Функция обратного вызова потока данных</param>
        /// <param name="userHandle">Дескриптор пользователя.</param>
        /// <returns>Дескриптор устройства потокового просмотра.</returns>
        public int StartRealPlay(int userID, ref PreviewInfo previewInfo, REALDATACALLBACK realDataCallBack, IntPtr userHandle)
        {
            var result = BaseDll.NET_DVR_RealPlay_V40(userID, ref previewInfo, realDataCallBack, userHandle);

            if (result >= 0)
            {
                MessageForUser("Видеопоток в реальном времени запущен.");
            }
            else
            {
                MessageForUser($"Не удалось запустить видеопоток в реальном времени. Код ошибки {GetLastError()}");
            }

            return result;
        }

        /// <summary>
        /// Останавливает просмотр в реальном времени.
        /// </summary>
        /// <param name="realHandle">Дескриптор устройства потокового просмотра.</param>
        /// <returns></returns>
        public bool StopRealPlay(int realHandle)
        {
            var result = BaseDll.NET_DVR_StopRealPlay(realHandle);

            if (result)
            {
                MessageForUser("Видеопоток в реальном времени остановлен.");
            }
            else
            {
                MessageForUser($"Не удалось остановить видеопоток в реальном времени. Код ошибки {GetLastError()}");
            }

            return result;
        }

        /// <summary>
        /// Получает код последней ошибки.
        /// </summary>
        /// <returns>Код последней ошибки.</returns>
        public uint GetLastError()
        {
            return BaseDll.NET_DVR_GetLastError();
        }

        /// <summary>
        /// Сохранить изображение из потокового видео в формате BMP.
        /// </summary>
        /// <param name="realHandle">Дескриптор устройства потокового просмотра.</param>
        /// <param name="fileName">Путь и имя для сохранения файла.</param>
        /// <returns>Указывает, удалось ли сохранить изображение.</returns>
        public bool SaveBmpPicture(int realHandle, string fileName)
        {
            var result = BaseDll.NET_DVR_CapturePicture(realHandle, fileName);

            if (!result)
            {
                MessageForUser($"Не удалось сохранить изображение в формате BMP {fileName}. Код ошибки {GetLastError()}");
            }

            return result;
        }

        /// <summary>
        /// Сохранить изображение из потокового видео в формате JPEG.
        /// </summary>
        /// <param name="userID">Уникальный идентификатор пользователя.</param>
        /// <param name="channel">Номер канала.</param>
        /// <param name="jpegParameters">Структура информации об изображении в формате JPEG.</param>
        /// <param name="fileName">Путь и имя для сохранения файла.</param>
        /// <returns>Указывает, удалось ли сохранить изображение.</returns>
        public bool SaveJpegPicture(int userID, int channel, ref JpegParameters jpegParameters, string fileName)
        {
            var result = BaseDll.NET_DVR_CaptureJPEGPicture(userID, channel, ref jpegParameters, fileName);

            if (!result)
            {
                MessageForUser($"Не удалось сохранить изображение в формате JPEG {fileName}. Код ошибки {GetLastError()}");
            }

            return result;
        }

        /// <summary>
        /// Создание ключевого кадра в основном потоке.
        /// </summary>
        /// <param name="userID">Уникальный идентификатор пользователя.</param>
        /// <param name="channel">Номер канала.</param>
        /// <returns></returns>
        public bool MakeKeyFrame(int userID, int channel)
        {
            return BaseDll.NET_DVR_MakeKeyFrame(userID, channel);
        }

        /// <summary>
        /// Создание ключевого кадра в основном подпотоке.
        /// </summary>
        /// <param name="userID">Уникальный идентификатор пользователя.</param>
        /// <param name="channel">Номер канала.</param>
        /// <returns></returns>
        public bool MakeKeyFrameSub(int userID, int channel)
        {
            return BaseDll.NET_DVR_MakeKeyFrameSub(userID, channel);
        }

        /// <summary>
        /// Начинает запись видеопотока в указанный файл.
        /// </summary>
        /// <param name="realHandle">Дескриптор устройства потокового просмотра.</param>
        /// <param name="fileName">Путь и имя для сохранения файла.</param>
        /// <returns>Указывает, удалось ли начать запись видео.</returns>
        public bool StartSaveVideo(int realHandle, string fileName)
        {
            var result = BaseDll.NET_DVR_SaveRealData(realHandle, fileName);

            if (result)
            {
                MessageForUser($"Запущена запись видеопотока в файл {fileName}.");
            }
            else
            {
                MessageForUser($"Не удалось запустить запись видеопотока в файл {fileName}. Код ошибки {GetLastError()}");
            }

            return result;
        }

        /// <summary>
        /// Прекращает запись видеопотока.
        /// </summary>
        /// <param name="realHandle">Дескриптор устройства потокового просмотра.</param>
        /// <returns>Указывает, удалось ли закончиться запись видео.</returns>
        public bool StopSaveVideo(int realHandle)
        {
            var result = BaseDll.NET_DVR_StopSaveRealData(realHandle);

            if (result)
            {
                MessageForUser($"Запись видеопотока в файл успешно завершена.");
            }
            else
            {
                MessageForUser($"Не удалось остановить запись видеопотока в файл . Код ошибки {GetLastError()}");
            }

            return result;
        }
    }
}
