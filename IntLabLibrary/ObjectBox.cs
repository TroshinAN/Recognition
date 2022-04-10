using System;
using Newtonsoft.Json;

namespace IntLabLibrary
{
    /// <summary>
    /// Область локализации объекта (bounding box).
    /// </summary>
    public class ObjectBox
    {
        /// <summary>
        /// Х-координата левого верхнего угла области.
        /// </summary>
        [JsonProperty(PropertyName = "left_x")]
        public int LeftX { get; set; }

        /// <summary>
        /// Y-координата левого верхнего угла области.
        /// </summary>
        [JsonProperty(PropertyName = "top_y")]
        public int TopY { get; set; }

        /// <summary>
        /// Х-координата правого нижнего угла области.
        /// </summary>
        [JsonProperty(PropertyName = "right_x")]
        public int RightX { get; set; }

        /// <summary>
        /// Y-координата правого нижнего угла области.
        /// </summary>
        [JsonProperty(PropertyName = "bottom_y")]
        public int BottomY { get; set; }

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
