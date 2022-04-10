using System;
using Newtonsoft.Json;

namespace IntLabLibrary
{
    /// <summary>
    /// Параметры распознавателя.
    /// </summary>
    public class RecognitionSetup
    {
        private const double minTypicalCharAr = 0.5;
        private const double maxTypicalCharAr = 1.5;
        private const double minTypicalCharHeightSize = 20;


        private double typicalCharAr;
        /// <summary>
        /// Наиболее встречающееся усредненное соотношение ширина / высота для символов номера (исключая 1, I, J),
        /// AR = W / H.
        /// </summary>
        [JsonProperty(PropertyName = "typical_char_ar")]
        public double TypicalCharAr
        {
            get { return typicalCharAr; }
            set
            {
                if (value < minTypicalCharAr || value > maxTypicalCharAr)
                {
                    throw new ArgumentException(String.Format("Значение среднего соотношения ширины-высоты вне допустимых пределов от {0} до {1}", minTypicalCharAr, maxTypicalCharAr));
                }
                typicalCharAr = value;
            }
        }

        private double typicalCharHeightSize;
        /// <summary>
        /// Наиболее встречающаяся усредненная высота символов в пикселях в масштабе исходного кадра.
        /// </summary>
        [JsonProperty(PropertyName = "typical_char_height_size")]
        public double TypicalCharHeightSize
        {
            get { return typicalCharHeightSize; }
            set
            {
                if (value < minTypicalCharHeightSize)
                {
                    throw new ArgumentException(String.Format("Средний размер символов номера должен быть не менее {0}", minTypicalCharHeightSize));
                }
                typicalCharHeightSize = value;

                var typicalCharWidthSize = typicalCharHeightSize * typicalCharAr;
                MinCharWidth = (typicalCharWidthSize * 0.5);
                MaxCharWidth = (typicalCharWidthSize * 1.5);
                MinCharHeight = (typicalCharHeightSize * 0.5);
                MaxCharHeight = (typicalCharHeightSize * 1.5);
            }
        }

        /// <summary>
        /// Минимальная ширина символов в пикселях в масштабе исходного кадра.
        /// </summary>
        [JsonProperty(PropertyName = "min_char_width")]
        public double MinCharWidth { get; set; }

        /// <summary>
        /// Максимальная ширина символов в пикселях в масштабе исходного кадра.
        /// </summary>
        [JsonProperty(PropertyName = "max_char_width")]
        public double MaxCharWidth { get; set; }

        /// <summary>
        /// Минимальная высота символов в пикселях в масштабе исходного кадра.
        /// </summary>
        [JsonProperty(PropertyName = "min_char_height")]
        public double MinCharHeight { get; set; }

        /// <summary>
        /// Максимальная высота символов в пикселях в масштабе исходного кадра.
        /// </summary>
        [JsonProperty(PropertyName = "max_char_height")]
        public double MaxCharHeight { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса.
        /// </summary>
        public RecognitionSetup()
        {
            this.TypicalCharAr = 1;
            this.TypicalCharHeightSize = minTypicalCharHeightSize;
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
