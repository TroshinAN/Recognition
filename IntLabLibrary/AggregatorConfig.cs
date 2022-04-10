using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IntLabLibrary
{
    /// <summary>
    /// Настройки агрегатора.
    /// </summary>
    public class AggregatorConfig
    {
        /// <summary>
        /// Наименование агрегатора.
        /// </summary>
        [JsonProperty(PropertyName = "aggregator_uid")]
        public string Name { get; set; }

        /// <summary>
        /// Тип лицензии обработки входного потока изображений.
        /// </summary>
        [JsonProperty(PropertyName = "lic_type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public LicenseType LicenseType { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса.
        /// </summary>
        public AggregatorConfig()
        {
            this.Name = String.Empty;
            this.LicenseType = LicenseType.UNKNOW;
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
