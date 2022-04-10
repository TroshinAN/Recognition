using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IntLabLibrary
{
    /// <summary>
    /// База знаний для агрегатора.
    /// </summary>
    public class AggregatorSetup
    {
        /// <summary>
        /// Список известных номеров.
        /// </summary>
        [JsonProperty(PropertyName = "known_numbers")]
        public List<string> KnownNumbers { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса.
        /// </summary>
        public AggregatorSetup()
        {
            this.KnownNumbers = new List<string>();
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
