using System;
using Newtonsoft.Json;

namespace IntLabLibrary
{
    /// <summary>
    /// Настройки уровня библиотеки.
    /// </summary>
    public class LibraryConfig
    {
        /// <summary>
        /// Полный путь до файла хранилища.
        /// </summary>
        [JsonProperty(PropertyName = "path_to_storage")]
        public string Directory { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса.
        /// </summary>
        public LibraryConfig()
        {
            this.Directory = String.Empty;
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
