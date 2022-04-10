using System;
using Newtonsoft.Json;

namespace IntLabLibrary
{
    /// <summary>
    /// Ширина и высота кадра в пикселях.
    /// </summary>
    public class FrameSize
    {
        /// <summary>
        /// Максимально допустимый размер в пикселях.
        /// </summary>
        public const int MaxPixcel = 2097152;
        private const int maxWidth = 3840;
        private const int maxHeight = 2160;
        private int width = 0;
        private int height = 0;

        /// <summary>
        /// Ширина кадра в пикселях.
        /// </summary>
        [JsonProperty(PropertyName = "w")]
        public int Width
        {
            get
            {
                return width;
            }
            set
            {
                //if (value % 16 > 0)
                //{
                //    throw new ArgumentException("Рекомендуемая ширина кадра должна быть кратна 16.");
                //}
                if (value > maxWidth)
                {
                    throw new ArgumentException("Ширина кадра не должна превышать " + maxWidth.ToString());
                }
                if ((value * height) > MaxPixcel)
                {
                    //throw new ArgumentException("Превышен допустимый размер изображения");
                }
                width = value;
            }
        }
        /// <summary>
        /// Высота кадра в пикселях.
        /// </summary>
        [JsonProperty(PropertyName = "h")]
        public int Height
        {
            get
            {
                return height;
            }
            set
            {
                //if (value % 16 > 0)
                //{
                //    throw new ArgumentException("Рекомендуемая высота кадра должна быть кратна 16.");
                //}
                if (value > maxHeight)
                {
                    throw new ArgumentException("Высота кадра не должна превышать " + maxHeight.ToString());
                }
                if ((value * width) > MaxPixcel)
                {
                    //throw new ArgumentException("Превышен допустимый размер изображения");
                }
                height = value;
            }
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
