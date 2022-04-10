using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IntLabLibrary
{
    /// <summary>
    /// Консолидированный результат распознавания по всем источникам изображений.
    /// </summary>
    public class Result
    {
        /// <summary>
        /// Идентификатор отслеживаемого объекта (-1 объект без сопровождения).
        /// </summary>
        [JsonProperty(PropertyName = "object_uid")]
        public Int64 ObjectUid { get; set; }

        /// <summary>
        /// Основание по которому был создан консолидированный результат.
        /// </summary>
        [JsonProperty(PropertyName = "reason")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ResultReason Reason { get; set; }

        /// <summary>
        /// Достоверность результата распознавания номера (0.f - 1.f).
        /// </summary>
        [JsonProperty(PropertyName = "confidence")]
        public double Confidence { get; set; }

        /// <summary>
        /// Строка распознанного номера.
        /// </summary>
        [JsonProperty(PropertyName = "number")]
        public string Number { get; set; }

        /// <summary>
        /// Цвет номерной пластины и текста.
        /// </summary>
        [JsonProperty(PropertyName = "color_polarity")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ColorPolarity ColorPolarity { get; set; }

        /// <summary>
        /// Тип распознанного номера.
        /// </summary>
        [JsonProperty(PropertyName = "type_of_number")]
        [JsonConverter(typeof(StringEnumConverter))]
        public RecognizedType TypeOfNumber { get; set; }

        /// <summary>
        /// Направление и скорость движения объекта.
        /// </summary>
        [JsonProperty(PropertyName = "direction")]
        public ObjectMovement Direction { get; set; }

        /// <summary>
        /// Отметка времени входа объекта в зону контроля.
        /// </summary>
        [JsonProperty(PropertyName = "time_in")]
        public TimeSpec TimeIn { get; set; }

        /// <summary>
        /// Отметка времени выхода объекта в зону контроля.
        /// </summary>
        [JsonProperty(PropertyName = "time_out")]
        public TimeSpec TimeOut { get; set; }

        /// <summary>
        /// Достоверность распознавания символов номера.
        /// </summary>
        [JsonProperty(PropertyName = "char_confidence")]
        public List<double> CharConfidence { get; set; }

        /// <summary>
        /// Сходство с эталоном из списка.
        /// </summary>
        [JsonProperty(PropertyName = "similarity")]
        public Similarity Similarity { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса.
        /// </summary>
        public Result()
        {
            this.ColorPolarity = ColorPolarity.UNKNOWN;
            this.Direction = new ObjectMovement();
            this.Number = String.Empty;
            this.Reason = ResultReason.UNKNOWN;
            this.Similarity = new Similarity();
            this.TimeIn = new TimeSpec();
            this.TimeOut = new TimeSpec();
            this.TypeOfNumber = RecognizedType.UNKNOWN;
            this.CharConfidence = new List<double>();
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
