using System;
using Newtonsoft.Json;

namespace IntLabLibrary
{
    /// <summary>
    /// Вербальный отчет о проблемах распознавания и возможных способах их устранения.
    /// </summary>
    public class EngineFeedback
    {
        /// <summary>
        /// Отчет о проблемах распознавания и возможных способах их устранения.
        /// </summary>
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса.
        /// </summary>
        public EngineFeedback()
        {
            this.Message = String.Empty;
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
