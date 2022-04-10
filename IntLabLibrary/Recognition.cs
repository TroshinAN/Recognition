using System;
using System.Collections.Generic;
using System.Text;

namespace IntLabLibrary
{
    using DllReturnType = System.Int32;
    using DllHandleType = System.Int64;

    /// <summary>
    /// Базовый класс библиотеки.
    /// </summary>
    public abstract class Recognition
    {
        /// <summary>
        /// Метод передачи сообщения о критической ошибке.
        /// </summary>
        public Action<string, ErrorReportList> StopByError;

        private static readonly object lib_lock = new object();
        private static Recognition instance = null;
        internal delegate DllReturnType ReadFuncTemplate(DllHandleType obj, byte[] data_output, UInt32 data_size, out UInt32 data_written, byte[] options);

        /// <summary>
        /// Тип библиотеки.
        /// </summary>
        public LibraryType LibraryType { get; }

        /// <summary>
        /// Получает рабочий экземпляр библиотеки.
        /// </summary>
        /// <param name="engine">Тип получаемого экземпляра.</param>
        /// <returns>Рабочий экземпляр библиотеки.</returns>
        public static Recognition CreateInterface(LibraryType engine)
        {
            switch (engine)
            {
                case LibraryType.WAGON:
                    instance = instance ?? RecognitionWagon.GetInterface();
                    return instance;
                case LibraryType.UIC:
                    instance = instance ?? RecognitionUIC.GetInterface();
                    return instance;
                case LibraryType.COACH:
                    instance = instance ?? RecognitionCoach.GetInterface();
                    return instance;
                case LibraryType.CONTAINER:
                    instance = instance ?? RecognitionContainer.GetInterface();
                    return instance;
                case LibraryType.AUTO_LPR:
                    instance = instance ?? RecognitionAutoLPR.GetInterface();
                    return instance;
                case LibraryType.AUTO_MMR:
                    instance = instance ?? RecognitionAutoMMR.GetInterface();
                    return instance;


                default:
                    throw new ArgumentException("Отсутствует реализация библиотеки: " + engine.ToString());
            }
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса.
        /// </summary>
        protected Recognition(LibraryType libraryType)
        {
            LibraryType = libraryType;
        }

        /// <summary>
        /// Строковое представление типа библиотеки.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return LibraryType.ToString();
        }

        /// <summary>
        /// Инициализирует библиотеку.
        /// </summary>
        /// <param name="libraryConfig">Конфигурация библиотеки.</param>>
        /// <param name="options">Строка дополнительных параметров.</param>
        /// <returns>Указывает, удачно ли завершилась инициализация библиотеки.</returns>
        public bool LibraryInit(LibraryConfig libraryConfig, string options = null)
        {
            var cfg_str = DotStringAsCString(libraryConfig.ToJson());
            var cfgStringSize = CStrSize(cfg_str);
            var opt_str = DotStringAsCString(options);

            lock (lib_lock)
            {
                var resultCode = DLL_LibraryInit(cfg_str, cfgStringSize, opt_str);

                if (resultCode != 0)
                {
                    StopByError("Ошибка инициализации библиотеки распознавания.", ObjectToJson.ToObject<ErrorReportList>(GetLastError(null)));
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Освобождает ресурсы библиотеки и отключает защитный ключ.
        /// Должен вызываться только после закрытия всех ранее созданных объектов.
        /// </summary>
        /// <param name="useThrow">Вызывать ли исключение при неудачном освобождении ресурсов библиотеки. По умолчанию вызывать.</param>
        public void LibraryFree(bool useThrow = true)
        {
            lock (lib_lock)
            {
                var resultCode = DLL_LibraryFree();

                if (resultCode != 0 && useThrow)
                {
                    StopByError("Ошибка освобождения ресурсов библиотеки распознавания.", ObjectToJson.ToObject<ErrorReportList>(GetLastError(null)));
                }
            }
        }

        /// <summary>
        /// Создаёт экземпляр агрегатора.
        /// </summary>
        /// <param name="config">Параметра агрегатора.</param>
        /// <param name="option">Строка дополнительных параметров.</param>
        /// <returns>Возвращает экземпляр агрегатора.</returns>
        public DllHandle CreateAggregator(AggregatorConfig config, string option = null)
        {
            var handle = DllHandle.HandleZero;
            var configCString = DotStringAsCString(config.ToJson());
            var configSize = CStrSize(configCString);
            var optionCString = DotStringAsCString(option);

            lock (lib_lock)
            {
                handle = DLL_CreateAggregator(configCString, configSize, optionCString);
                if (handle == DllHandle.HandleZero)
                {
                    StopByError("Ошибка создания агрегатора.", ObjectToJson.ToObject<ErrorReportList>(GetLastError(null)));
                    return null;
                }
            }
            return new DllHandle(this.LibraryType, handle);
        }

        /// <summary>
        /// Создаёт экземпляр ресурса изображения для указанного агрегатора.
        /// </summary>
        /// <param name="aggregator">Экземпляр агрегатора.</param>
        /// <param name="config">Параметры ресурса изображения.</param>
        /// <param name="option">Строка дополнительных параметров.</param>
        /// <returns>Возвращает экземпляр ресурса изображения.</returns>
        public DllHandle AddImageSource(DllHandle aggregator, ImageSourceConfig config, string option = null)
        {
            if (aggregator.LibraryType != this.LibraryType)
            {
                throw new ArgumentException($"Тип экземпляра агрегатора {aggregator.LibraryType.ToString()} не совпадает с типом библиотеки {this.LibraryType.ToString()}.");
            }
            var handle = DllHandle.HandleZero;
            var configCString = DotStringAsCString(config.ToJson());
            var configSize = CStrSize(configCString);
            var optionCString = DotStringAsCString(option);

            lock (lib_lock)
            {
                handle = DLL_AddImageSource(aggregator.Handle, configCString, configSize, optionCString);
                if (handle == DllHandle.HandleZero)
                {
                    StopByError("Ошибка создания ресурса изображения.", ObjectToJson.ToObject<ErrorReportList>(GetLastError(aggregator)));
                    return null;
                }
            }
            return new DllHandle(this.LibraryType, handle, aggregator);
        }

        /// <summary>
        /// Освобождение ресурсов агрегатора
        /// </summary>
        /// <param name="aggregator">Экземпляр агрегатора.</param>
        public void ReleaseAggregator(DllHandle aggregator)
        {
            lock (lib_lock)
            {
                var resultCode = DLL_ReleaseAggregator(aggregator.Handle);
                if (resultCode != 0)
                {
                    StopByError("Ошибка освобождения ресурсов агрегатора.", ObjectToJson.ToObject<ErrorReportList>(GetLastError(aggregator)));
                }
            }
        }

        /// <summary>
        /// Установка алгоритмов распознавания.
        /// </summary>
        /// <param name="aggregator">Экземпляр агрегатора</param>
        /// <param name="aggregatorSetup">Настройки алгоритма распознавания.</param>
        /// <param name="option">Строка дополнительных параметров.</param>
        public void Setup(DllHandle aggregator, AggregatorSetup aggregatorSetup, string option = null)
        {
            if (aggregator.LibraryType != this.LibraryType)
            {
                throw new ArgumentException(String.Format("Тип экземпляра агрегатора {0} не совпадает с типом библиотеки {1}.", aggregator.LibraryType.ToString(), this.LibraryType.ToString()));
            }

            var setupCString = DotStringAsCString(aggregatorSetup.ToJson());
            var setupSize = CStrSize(setupCString);
            var optionCString = DotStringAsCString(option);

            var resultCode = DLL_Setup(aggregator.Handle, setupCString, setupSize, optionCString);

            if (resultCode != 0)
            {
                StopByError("Ошибка установки алгоритмов распознавания.", ObjectToJson.ToObject<ErrorReportList>(GetLastError(aggregator)));
                //throw CreateException(aggregator, resultCode, "Ошибка установки алгоритмов распознавания:");
            }
        }

        /// <summary>
        /// Сброс алгоритмов распознавания.
        /// </summary>
        /// <param name="aggregator">Экземпляр агрегатора</param>
        /// <param name="option">Строка дополнительных параметров.</param>
        public void Reset(DllHandle aggregator, string option = null)
        {
            if (aggregator.LibraryType != this.LibraryType)
            {
                throw new ArgumentException(String.Format("Тип экземпляра агрегатора {0} не совпадает с типом библиотеки {1}.", aggregator.LibraryType.ToString(), this.LibraryType.ToString()));
            }

            var optionCString = DotStringAsCString(option);
            var resultCode = DLL_Reset(aggregator.Handle, optionCString);

            if (resultCode != 0)
            {
                StopByError("Ошибка сброса алгоритмов распознавания.", ObjectToJson.ToObject<ErrorReportList>(GetLastError(aggregator)));
                //throw CreateException(aggregator, resultCode, "Ошибка сброса алгоритмов распознавания. Код ошибки:");
            }
        }

        /// <summary>
        /// Для агрегатора запускается процесс обработки событий агрегатора.
        /// Для ресурса изображения запускается обработка изображения.
        /// </summary>
        /// <param name="handle">Экземпляр объекта, для которого запускается процесс (агрегатор/ресурс изображения)</param>
        /// <param name="data">Json-строка с данными для обработки.</param>
        /// <param name="option">Строка дополнительных параметров.</param>
        /// <returns>Указывает, удачно ли завершилась обработка.</returns>
        public bool Process(DllHandle handle, string data, string option = null)
        {
            if (handle.LibraryType != this.LibraryType)
            {
                throw new ArgumentException(String.Format("Тип экземпляра {0} не совпадает с типом библиотеки {1}.", handle.LibraryType.ToString(), this.LibraryType.ToString()));
            }

            var dataCString = DotStringAsCString(data);
            var dataSize = CStrSize(dataCString);
            var optionCString = DotStringAsCString(option);

            var resultCode = DLL_Process(handle.Handle, dataCString, dataSize, optionCString);

            switch (resultCode)
            {
                case 0:
                    return true;
                case (DllReturnType)ReturnCode.FRAME_SKIPPED:
                    return false;
                default:
                    StopByError("Ошибка исполнения.", ObjectToJson.ToObject<ErrorReportList>(GetLastError(handle)));
                    //throw CreateException(handle, resultCode, "Ошибка исполнения. Код ошибки:");
                    return true;
            }
        }

        /// <summary>
        /// Получение результата распознавания.
        /// </summary>
        /// <param name="handle">Экземпляр агрегатора.</param>
        /// <param name="option">Строка дополнительных параметров.</param>
        /// <returns>Возвращает полученный результат в формате Json-строки.</returns>
        public string GetResult(DllHandle handle, string option = null)
        {
            if (handle.LibraryType != this.LibraryType)
            {
                throw new ArgumentException(String.Format("Тип экземпляра {0} не совпадает с типом библиотеки {1}.", handle.LibraryType.ToString(), this.LibraryType.ToString()));
            }

            string text;

            lock (lib_lock)
            {
                var resultCode = ReadFromInstance(4, out text, handle,
                (DllHandleType obj, byte[] dataOutput, UInt32 dataSize, out UInt32 dataWritten, byte[] options)
                    => DLL_GetResult(obj, dataOutput, dataSize, out dataWritten, options),
                option);
            }

            if (text == null)
            {
                StopByError("Ошибка получения результата.", ObjectToJson.ToObject<ErrorReportList>(GetLastError(handle)));
                //throw CreateException(handle, resultCode, "Ошибка получения результата. Код ошибки. Код ошибки:");
            }

            return text;
        }

        /// <summary>
        /// Получить Json-строки последней ошибки.
        /// </summary>
        /// <param name="handle">Дескриптор объекта, для получения последней ошибки. Если значение null - последняя ошибки библиотеки.</param>
        /// <param name="option">Строка дополнительных параметров.</param>
        /// <returns>Возвращает Json-строку последней ошибки объекта.</returns>
        public string GetLastError(DllHandle handle, string option = null)
        {
            handle = handle ?? new DllHandle(this.LibraryType);

            if (handle.LibraryType != this.LibraryType)
            {
                throw new ArgumentException(String.Format("Тип экземпляра {0} не совпадает с типом библиотеки {1}.", handle.LibraryType.ToString(), this.LibraryType.ToString()));
            }

            var resultCode = ReadFromInstance(2, out string text, handle,
                (DllHandleType obj, byte[] dataOutput, UInt32 dataSize, out UInt32 dataWritten, byte[] options)
                    => GetLastErrorLock(obj, dataOutput, dataSize, out dataWritten, options),
                option);

            if (text == null)
            {
                text = ObjectToJson.ToJson(new ErrorReportList
                {
                    Errors = new List<ErrorReport>
                    {
                        new ErrorReport{
                            ObjectName = this.LibraryType.ToString(),
                            Source = "GetLastError",
                            ErrorCode = resultCode.ToString(),
                            ObjectHandle = handle.Handle
                        }
                    }
                });
                //text = String.Format("Не удалось получить текст ошибки для объекта {0}. Код ошибки: {1};\n", handle, resultCode);
            }

            return text;
        }

        /// <summary>
        /// Чтение Json-строки из объекта.
        /// </summary>
        /// <param name="tryCount">Количество попыток чтения.</param>
        /// <param name="text">Json-строка, считанная из объекта.</param>
        /// <param name="handle">Экземпляр объекта.</param>
        /// <param name="func">Экземпляр функции чтения из библиотеки.</param>
        /// <param name="option">Строка дополнительных параметров.</param>
        /// <returns>Возвращает код возврата функции библиотеки.</returns>
        private DllReturnType ReadFromInstance(int tryCount, out string text, DllHandle handle, ReadFuncTemplate func, string option = null)
        {
            var optionCString = DotStringAsCString(option);
            var buf = new byte[2048];
            UInt32 written = 0;
            int progress = 0;
            DllReturnType returnCode = -1;
            bool done = false;
            text = null;

            while (!done && (progress < tryCount))
            {
                if (written > buf.Length)
                {
                    buf = new byte[written];
                }

                var dataSize = Convert.ToUInt32(buf.Length);
                written = 0;
                returnCode = func(handle.Handle, buf, dataSize, out written, optionCString);

                if ((returnCode == 0) || (returnCode == (DllReturnType)ReturnCode.FRAME_SKIPPED))
                {
                    done = true;
                }
                else if (returnCode == (DllReturnType)ReturnCode.INSUFFICIENT_MEMORY)
                {
                    progress++;
                }
            }
            if (done)
            {
                if (written > 0)
                {
                    var utf8 = new UTF8Encoding();
                    text = utf8.GetString(buf, 0, (int)written - 1);
                }
            }
            return returnCode;
        }

        private DllReturnType GetLastErrorLock(DllHandleType obj, byte[] data_output, UInt32 data_size, out UInt32 data_written, byte[] options)
        {
            if (obj == DllHandle.HandleZero)
            {
                lock (lib_lock)
                {
                    return DLL_GetLastError(obj, data_output, data_size, out data_written, options);
                }
            }
            else
            {
                return DLL_GetLastError(obj, data_output, data_size, out data_written, options);
            }
        }

        /// <summary>
        /// Преобразует строку в массив символов UTF-8 с завершающим нулём.
        /// </summary>
        /// <param name="str">Строка для преобразования.</param>
        /// <returns>Возвращает массив символов в кодировке UTF-8 c завершающим нулём.</returns>
        private byte[] DotStringAsCString(string str)
        {
            byte[] buf = null;
            if (!String.IsNullOrEmpty(str))
            {
                if (str[str.Length - 1] != '\0')
                {
                    str += '\0';
                }
                var utf8_enc = new System.Text.UTF8Encoding();
                buf = utf8_enc.GetBytes(str == null ? "\0" : str + "\0");
            }
            return buf;
        }

        /// <summary>
        /// Возвращает размер массива.
        /// </summary>
        /// <param name="b">Массив.</param>
        /// <returns>Размер массива.</returns>
        private UInt32 CStrSize(byte[] b)
        {
            return b != null ? Convert.ToUInt32(b.Length) : 0;
        }

        #region private abstract functions
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lib_config"></param>
        /// <param name="config_size"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        protected abstract DllReturnType DLL_LibraryInit(byte[] lib_config, UInt32 config_size, byte[] options);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected abstract DllReturnType DLL_LibraryFree();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inst_config"></param>
        /// <param name="config_size"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        protected abstract DllHandleType DLL_CreateAggregator(byte[] inst_config, UInt32 config_size, byte[] options);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aggregator_obj"></param>
        /// <returns></returns>
        protected abstract DllReturnType DLL_ReleaseAggregator(DllHandleType aggregator_obj);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aggregator_obj"></param>
        /// <param name="inst_config"></param>
        /// <param name="config_size"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        protected abstract DllHandleType DLL_AddImageSource(DllHandleType aggregator_obj, byte[] inst_config, UInt32 config_size, byte[] options);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aggregator_obj"></param>
        /// <param name="input_data"></param>
        /// <param name="data_size"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        protected abstract DllReturnType DLL_Setup(DllHandleType aggregator_obj, byte[] input_data, UInt32 data_size, byte[] options);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aggregator_obj"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        protected abstract DllReturnType DLL_Reset(DllHandleType aggregator_obj, byte[] options);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="input_data"></param>
        /// <param name="data_size"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        protected abstract DllReturnType DLL_Process(DllHandleType obj, byte[] input_data, UInt32 data_size, byte[] options);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="data_output"></param>
        /// <param name="data_size"></param>
        /// <param name="data_written"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        protected abstract DllReturnType DLL_GetResult(DllHandleType obj, byte[] data_output, UInt32 data_size, out UInt32 data_written, byte[] options);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="data_output"></param>
        /// <param name="data_size"></param>
        /// <param name="data_written"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        protected abstract DllReturnType DLL_GetLastError(DllHandleType obj, byte[] data_output, UInt32 data_size, out UInt32 data_written, byte[] options);
        #endregion
    }
}
