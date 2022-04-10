using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IntLabLibrary
{
    /// <summary>
    /// Результат распознавания по источнику изображения.
    /// </summary>
    public class ImageSourceResult
    {
        /// <summary>
        /// Идентификатор отслеживаемого объекта (-1 объект без сопровождения).
        /// </summary>
        [JsonProperty(PropertyName = "object_uid")]
        public Int64 ObjectUid { get; set; }

        /// <summary>
        /// Имя источника изображений.
        /// </summary>
        [JsonProperty(PropertyName = "image_source_name")]
        public string ImageSourceName { get; set; }

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
        /// Достоверность распознавания символов номера.
        /// </summary>
        [JsonProperty(PropertyName = "char_confidence")]
        public double CharConfidence { get; set; }

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
        /// Отметка времени кадра, на котором наиболее хорошо виден номерной знак.
        /// </summary>
        [JsonProperty(PropertyName = "best_view_time")]
        public TimeSpec BestViewTime { get; set; }

        /// <summary>
        /// Область внутри кадра в момент времени BestViewTime.
        /// </summary>
        [JsonProperty(PropertyName = "best_view_box")]
        public ObjectBox BestViewBox { get; set; }

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
        /// Количество кадров в которых был распознан номер.
        /// </summary>
        [JsonProperty(PropertyName = "recognized_number_count")]
        public int RecognizedNumberCount { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса.
        /// </summary>
        public ImageSourceResult()
        {
            this.ImageSourceName = String.Empty;
            this.Number = String.Empty;
            this.ColorPolarity = ColorPolarity.UNKNOWN;
            this.TypeOfNumber = RecognizedType.UNKNOWN;
            this.Direction = new ObjectMovement();
            this.TimeIn = new TimeSpec();
            this.TimeOut = new TimeSpec();
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
