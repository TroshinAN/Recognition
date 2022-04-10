using System;
using Newtonsoft.Json;

namespace IntLabLibrary
{
    /// <summary>
    /// Описатель внутренних (собственных) параметров камеры и ее объектива.
    /// </summary>
    public class IntrinsicCameraMatrix
    {
        /// <summary>
        /// Безразмерное фокусное расстояние камеры в пикселях по оси Х: focal_length[mm] * pixel_density [pixels/mm]
        /// </summary>
        [JsonProperty(PropertyName = "fx")]
        public double Fx { get; set; }

        /// <summary>
        /// Безразмерное фокусное расстояние камеры в пикселях по оси У: focal_length[mm] * pixel_density [pixels/mm]
        /// </summary>
        [JsonProperty(PropertyName = "fy")]
        public double Fy { get; set; }

        /// <summary>
        /// Расположение оптического центра в пикселях по оси Х. Обычно близко или равно (frame_size.w / 2; frame_size.h / 2)
        /// </summary>
        [JsonProperty(PropertyName = "cx")]
        public double Cx { get; set; }

        /// <summary>
        /// Расположение оптического центра в пикселях по оси У. Обычно близко или равно (frame_size.w / 2; frame_size.h / 2)
        /// </summary>
        [JsonProperty(PropertyName = "cy")]
        public double Cy { get; set; }

        /// <summary>
        /// Модель камеры: true - сверхширокоугольная (fish-eye), false - не сверхширокоугольная
        /// </summary>
        [JsonProperty(PropertyName = "fisheye")]
        public bool Fisheye { get; set; }

        /// <summary>
        /// Коэффициент масштабирования поля зрения (0, 1,0]. Если ноль (по умолчанию), то будет игнорироваться. Позволяет производить эффект "zoom out".
        /// Может использоваться когда при коррекции оптических искажений происходит обрезка зон краев изображения.
        /// При значении fov_alpha = 0.0 присутствуют только пиксели прямоугольника скорректированного изображения (идет обрезка зон "подушки" относительно прямоугольника).
        /// При значении fov_alpha = 1.0 все пиксели исходного изображения после коррекции искажений объектива будут сохранены.
        /// </summary>
        [JsonProperty(PropertyName = "fov_alpha")]
        public double FovAlpha { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса.
        /// </summary>
        public IntrinsicCameraMatrix()
        {
            Fisheye = false;
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
