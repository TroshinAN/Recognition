using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IntLabLibrary
{
    /// <summary>
    /// Событие, инициирующее выдачу результата распознавания.
    /// </summary>
    public class AggregatorEvent
    {
        /// <summary>
        /// Тип события синхронизации.
        /// </summary>
        [JsonProperty(PropertyName = "event_type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public AggregatorEventType EventType { get; set; }

        /// <summary>
        /// Временная метка.
        /// </summary>
        [JsonProperty(PropertyName = "ts")]
        public TimeSpec TimeSpec { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса.
        /// </summary>
        /// <param name="eventType">Тип события синхронизации.</param>
        /// <param name="timeSpec">Временная метка.</param>
        public AggregatorEvent(AggregatorEventType eventType, TimeSpec timeSpec)
        {
            this.EventType = eventType;
            this.TimeSpec = timeSpec;
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
