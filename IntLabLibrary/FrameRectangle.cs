using System;
using Newtonsoft.Json;

namespace IntLabLibrary
{
    /// <summary>
    /// Прямоугольник задающий размер кадра или области в пикселях в виде координат левого верхнего угла и размера по ширине и высоте.
    /// </summary>
    public class FrameRectangle
    {
        /// <summary>
        /// Х-координата левого верхнего угла области.
        /// </summary>
        [JsonProperty(PropertyName = "x")]
        public int X { get; set; }

        /// <summary>
        /// Y-координата левого верхнего угла области.
        /// </summary>
        [JsonProperty(PropertyName = "y")]
        public int Y { get; set; }

        /// <summary>
        /// Ширина области.
        /// </summary>
        [JsonProperty(PropertyName = "w")]
        public int Width { get; set; }

        /// <summary>
        /// Высота области.
        /// </summary>
        [JsonProperty(PropertyName = "h")]
        public int Height { get; set; }

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
