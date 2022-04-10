using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IntLabLibrary
{
    /// <summary>
    /// Описатель источника изображений для распознавания.
    /// </summary>
    public class ImageSourceDescriptor
    {
        /// <summary>
        /// Ожидаемый формат кадра.
        /// </summary>
        [JsonProperty(PropertyName = "frame_format")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ImageFormat FrameFormat { get; set; }

        /// <summary>
        /// Размер кадра ширина+высота в пикселях.
        /// </summary>
        [JsonProperty(PropertyName = "frame_size")]
        public FrameSize FrameSize { get; set; }

        /// <summary>
        /// Координаты угла (х,у) и размер (w,h) области внимания в пикселях .
        /// </summary>
        [JsonProperty(PropertyName = "roi_rect")]
        public FrameRectangle RoiRect { get; set; }

        /// <summary>
        /// Свойства камеры.
        /// </summary>
        [JsonProperty(PropertyName = "camera_setup")]
        public CameraSetup CameraSetup { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса.
        /// </summary>
        public ImageSourceDescriptor()
        {
            this.FrameFormat = ImageFormat.UNKNOW;
            this.FrameSize = new FrameSize();
            this.RoiRect = new FrameRectangle();
            this.CameraSetup = new CameraSetup();
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
