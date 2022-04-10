using System;
using System.Diagnostics;
using Newtonsoft.Json;

namespace IntLabLibrary
{
    /// <summary>
    /// Описатель времени POSIX.
    /// </summary>
    public class TimeSpec
    {
        /// <summary>
        /// Число секунд, истекших от 00:00 1 января 1970 UTC до времени POSIX
        /// </summary>
        [JsonProperty(PropertyName = "tv_sec")]
        public long Seconds { get; set; }

        /// <summary>
        /// Количество наносекунд, округленное с учетом точности системных часов (1с= 1 000 000 000 нс).
        /// </summary>
        [JsonProperty(PropertyName = "tv_nsec")]
        public int NanSeconds { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса.
        /// </summary>
        public TimeSpec()
        {
            Seconds = DateTime.Now.Ticks / Stopwatch.Frequency;
            NanSeconds = 0;
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
