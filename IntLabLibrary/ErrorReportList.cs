using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IntLabLibrary
{
    /// <summary>
    /// Список ошибок.
    /// </summary>
    public class ErrorReportList
    {
        /// <summary>
        /// Список ошибок.
        /// </summary>
        [JsonProperty(PropertyName = "errors")]
        public List<ErrorReport> Errors { get; set; }

        /// <summary>
        /// Информация о библиотеке (дата создания, версия и т.д.).
        /// </summary>
        [JsonProperty(PropertyName = "build_info")]
        public string BuildInfo { get; set; }

        /// <summary>
        /// Путь к бинарному образу загруженной библиотеки.
        /// </summary>
        [JsonProperty(PropertyName = "path_to_binary")]
        public string PathToBinary { get; set; }

        /// <summary>
        /// Путь к файлу хранилища.
        /// </summary>
        [JsonProperty(PropertyName = "path_to_storage")]
        public string PathToStorage { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса.
        /// </summary>
        public ErrorReportList()
        {
            this.Errors = new List<ErrorReport>();
            this.BuildInfo = String.Empty;
        }

        /// <summary>
        /// Получить Json строку элемента.
        /// </summary>
        /// <returns>Json строка</returns>
        public string ToJson()
        {
            return ObjectToJson.ToJson(this);
        }
    }
}
