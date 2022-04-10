using System;
using Newtonsoft.Json;

namespace IntLabLibrary
{
    /// <summary>
    /// Настройки источника данных.
    /// </summary>
    public class ImageSourceConfig
    {
        /// <summary>
        /// Имя источника изображений, обязательный параметр (может быть равен "")
        /// </summary>
        [JsonProperty(PropertyName = "image_source_uid")]
        public string ImageSourceUid { get; set; }

        /// <summary>
        /// Формат входных данных, параметры предварительной обработки изображения.
        /// </summary>
        [JsonProperty(PropertyName = "image_source_setup")]
        public ImageSourceDescriptor ImageSourceSetup { get; set; }

        /// <summary>
        /// Параметры распознавателя.
        /// </summary>
        [JsonProperty(PropertyName = "recognition_setup")]
        public RecognitionSetup RecognitionSetup { get; set; }

        ///// <summary>
        ///// Набор лицензий распознавателя.
        ///// </summary>
        //[JsonProperty(PropertyName = "wgn_lic")]
        ////[JsonConverter(typeof(StringEnumConverter))]
        ////public License License { get; set; }
        //public int License { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса.
        /// </summary>
        public ImageSourceConfig()
        {
            this.ImageSourceUid = String.Empty;
            this.ImageSourceSetup = new ImageSourceDescriptor();
            this.RecognitionSetup = new RecognitionSetup();
            //this.License = 0;
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
