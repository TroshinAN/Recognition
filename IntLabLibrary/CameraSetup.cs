using System;
using Newtonsoft.Json;

namespace IntLabLibrary
{
    /// <summary>
    /// Внутренние (собственные) и внешние параметры камеры и ее объектива. Определяются с помощью процедуры калибровки.
    /// </summary>
    public class CameraSetup
    {
        /// <summary>
        /// Размеры кадра изображения (разрешение) используемые при калибровке.
        /// </summary>
        [JsonProperty(PropertyName = "frame_size")]
        public FrameSize FrameSize { get; set; }

        /// <summary>
        /// Свойства камеры.
        /// </summary>
        [JsonProperty(PropertyName = "intrinsic")]
        public CameraIntrinsicSetup Intrinsic { get; set; }

        /// <summary>
        /// Углы Эйлера в порядке использования: Z-> Y-> X.
        /// </summary>
        [JsonProperty(PropertyName = "camera_angles_zyx")]
        public EulerAngles CameraAnglesZyx { get; set; }

        /// <summary>
        /// поддерживаемые значения:
        ///"roi_rect_rescaled_size_px" - произвести растягивание целого кадра или зоны tImageSourceDescriptor::roi_rect, 
        /// если она установлена до размера ref_scale_size_x пикселей ширины и ref_scale_size_y пикселей высоты
        /// </summary>
        [JsonProperty(PropertyName = "ref_scale_type")]
        public string RefScaleType { get; set; }

        /// <summary>
        /// Размер масштабного шаблона по оси Х.
        /// </summary>
        [JsonProperty(PropertyName = "ref_scale_size_x")]
        public int RefScaleSizeX { get; set; }

        /// <summary>
        /// Размер масштабного шаблона по оси У.
        /// </summary>
        [JsonProperty(PropertyName = "ref_scale_size_y")]
        public int RefScaleSizeY { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса.
        /// </summary>
        public CameraSetup()
        {
            this.FrameSize = new FrameSize();
            this.Intrinsic = new CameraIntrinsicSetup();
            this.CameraAnglesZyx = new EulerAngles();
            this.RefScaleType = "chessboard_9_6";
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
