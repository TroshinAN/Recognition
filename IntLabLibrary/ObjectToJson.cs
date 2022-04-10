using System;
using Newtonsoft.Json;

namespace IntLabLibrary
{
    /// <summary>
    /// Класс работы с Json строками.
    /// </summary>
    public static class ObjectToJson
    {
        /// <summary>
        /// Преобразование объекта в Json строку.
        /// </summary>
        /// <typeparam name="T">Тип объекта.</typeparam>
        /// <param name="object">Объект.</param>
        /// <returns>Json строка.</returns>
        public static string ToJson<T>(T @object)
        {
            JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Populate };
            return JsonConvert.SerializeObject(@object, Formatting.Indented, jsonSerializerSettings);
        }

        /// <summary>
        /// Преобразование Json строки в объект.
        /// </summary>
        /// <typeparam name="T">Тип объекта.</typeparam>
        /// <param name="value">Json строка.</param>
        /// <returns>Объект указанного типа.</returns>
        public static T ToObject<T>(string value)
        {
            JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Populate };
            return JsonConvert.DeserializeObject<T>(value, jsonSerializerSettings);
        }
    }
}
