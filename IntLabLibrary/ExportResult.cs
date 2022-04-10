using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IntLabLibrary
{
    /// <summary>
    /// Таблица экспорта результатов.
    /// </summary>
    public class ExportResult
    {
        /// <summary>
        /// Финальный консолидированный на базе всех источников изображений.
        /// </summary>
        [JsonProperty(PropertyName = "result")]
        public List<Result> Results { get; set; }

        /// <summary>
        /// Результаты индивидуально по источникам изображений.
        /// </summary>
        [JsonProperty(PropertyName = "image_source")]
        public List<ImageSourceResult> ImageSources { get; set; }

        /// <summary>
        /// Обратная связь от библиотеки распознавания.
        /// </summary>
        [JsonProperty(PropertyName = "feedback")]
        public List<EngineFeedback> Feedbacks { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса.
        /// </summary>
        public ExportResult()
        {
            Results = new List<Result>();
            ImageSources = new List<ImageSourceResult>();
            Feedbacks = new List<EngineFeedback>();
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
