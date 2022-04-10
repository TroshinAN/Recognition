using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace IntLabLibrary
{
    /// <summary>
    /// Внутренние свойства камеры и объектива и условия при которых они были получены. Значения определяются с помощью процедуры калибровки описанной по ссылке.
    /// </summary>
    public class CameraIntrinsicSetup
    {
        /// <summary>
        /// Размер рамки изображения (разрешение), используемый при калибровке.
        /// </summary>
        [JsonProperty(PropertyName = "frame_size")]
        public FrameSize FrameSize { get; set; }

        /// <summary>
        /// Внутренняя «матрица» камеры.
        /// </summary>
        [JsonProperty(PropertyName = "camera")]
        public IntrinsicCameraMatrix Camera { get; set; }

        /// <summary>
        /// Коэффициент радиальных искажений 1.
        /// </summary>
        [JsonProperty(PropertyName = "k1")]
        public double KoefRad1 { get; set; }

        /// <summary>
        /// Коэффициент радиальных искажений 2.
        /// </summary>
        [JsonProperty(PropertyName = "k2")]
        public double KoefRad2 { get; set; }

        /// <summary>
        /// Коэффициент радиальных искажений 3.
        /// </summary>
        [JsonProperty(PropertyName = "k3")]
        public double KoefRad3 { get; set; }

        /// <summary>
        /// Коэффициент радиальных искажений 4.
        /// </summary>
        [JsonProperty(PropertyName = "k4")]
        public double KoefRad4 { get; set; }

        /// <summary>
        /// Коэффициент радиальных искажений 5.
        /// </summary>
        [JsonProperty(PropertyName = "k5")]
        public double KoefRad5 { get; set; }

        /// <summary>
        /// Коэффициент радиальных искажений 6.
        /// </summary>
        [JsonProperty(PropertyName = "k6")]
        public double KoefRad6 { get; set; }

        /// <summary>
        /// Коэффициент тангенциальных искажений 1.
        /// </summary>
        [JsonProperty(PropertyName = "p1")]
        public double KoefTan1 { get; set; }

        /// <summary>
        /// Коэффициент тангенциальных искажений 2.
        /// </summary>
        [JsonProperty(PropertyName = "p2")]
        public double KoefTan2 { get; set; }

        /// <summary>
        /// Инициализирует новый экземплря класса.
        /// </summary>
        public CameraIntrinsicSetup()
        {
            this.FrameSize = new FrameSize();
            this.Camera = new IntrinsicCameraMatrix();
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
