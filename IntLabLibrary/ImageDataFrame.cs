using System;
using Newtonsoft.Json;

namespace IntLabLibrary
{
    /// <summary>
    /// Кадр изображения со временной меткой
    /// </summary>
    public class ImageDataFrame
    {
        ///// <summary>
        ///// Формат данных в изображении.
        ///// </summary>
        //[JsonProperty(PropertyName = "frame_format")]
        //[JsonConverter(typeof(StringEnumConverter))]
        //public ImageFormat FrameFormat { get; set; }

        ///// <summary>
        ///// Размер изображения (если raw-изображение).
        ///// </summary>
        //[JsonProperty(PropertyName = "frame_size")]
        //public FrameSize FrameSize { get; set; }

        /// <summary>
        /// Временная метка кадра.
        /// </summary>
        [JsonProperty(PropertyName = "ts")]
        public TimeSpec TimeSpec { get; set; }

        /// <summary>
        /// Изображение в виде последовательности байт в кодировке base64.
        /// </summary>
        [JsonProperty(PropertyName = "image")]
        public byte[] Image { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса.
        /// </summary>
        private ImageDataFrame()
        {
            //this.FrameFormat = ImageFormat.UNKNOW;
            //this.FrameSize = new FrameSize();
            this.TimeSpec = new TimeSpec();
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса.
        /// </summary>
        /// <param name="image">Массив байт изображения.</param>
        public ImageDataFrame(byte[] image) : this()
        {
            this.Image = image;
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
