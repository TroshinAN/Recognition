using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IntLabLibrary
{
    /// <summary>
    /// Запись о перемещении объекта.
    /// </summary>
    public class ObjectMovement
    {
        /// <summary>
        /// Размерность значения скорости.
        /// </summary>
        [JsonProperty(PropertyName = "velocity_unit")]
        [JsonConverter(typeof(StringEnumConverter))]
        public VelocityUnit VelocityUnit { get; set; }

        /// <summary>
        /// Скорость.
        /// </summary>
        [JsonProperty(PropertyName = "velocity")]
        public double Velocity { get; set; }

        /// <summary>
        /// Направление относительно наблюдателя.
        /// </summary>
        [JsonProperty(PropertyName = "direction")]
        [JsonConverter(typeof(StringEnumConverter))]
        public MoveDirection Direction { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса.
        /// </summary>
        public ObjectMovement()
        {
            this.VelocityUnit = VelocityUnit.UNKNOWN;
            this.Direction = MoveDirection.UNKNOWN;
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
