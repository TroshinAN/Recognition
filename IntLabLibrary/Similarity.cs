using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IntLabLibrary
{
    /// <summary>
    /// Описатель сходства распознанного номера с номером из базы знаний агрегатора.
    /// </summary>
    public class Similarity
    {
        /// <summary>
        /// Строка номера из списка, наиболее похожего на распознанный номер.
        /// </summary>
        [JsonProperty(PropertyName = "number_str")]
        public string Number { get; set; }

        /// <summary>
        /// Количество отличающихся символов.
        /// </summary>
        [JsonProperty(PropertyName = "char_distance")]
        public int CharDistance { get; set; }

        /// <summary>
        /// Levenstein расстояние от распознанного номера до номера из списка номеров из базы знаний агрегатора.
        /// </summary>
        [JsonProperty(PropertyName = "lev_distance")]
        public int LevensteinDistance { get; set; }

        /// <summary>
        /// Тип совпадения.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public SimilarityType Type { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса.
        /// </summary>
        public Similarity()
        {
            this.Number = String.Empty;
            this.Type = SimilarityType.UNKNOWN;
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
