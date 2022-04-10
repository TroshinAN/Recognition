using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace RecognitionWPF.Models
{
    /// <summary>
    /// Простейший класс для работы с XML документами (например ,в роли файла настроек).
    /// </summary>
    internal class SettingSerializer
    {
        /// <summary>
        /// Записать XML Документ.
        /// </summary>
        /// <typeparam name="T">Тип корневого класса XML документа.</typeparam>
        /// <param name="fileName">Имя файла.</param>
        /// <param name="volume">Экземпляр корневого класса для записи в XML файл.</param>
        public static void Serializer<T>(string fileName, T volume)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (TextWriter writer = new StreamWriter(fileName, false, Encoding.UTF8))
            {
                serializer.Serialize(writer, volume);
            }
        }
        /// <summary>
        /// Считать XML документ.
        /// </summary>
        /// <typeparam name="T">Тип корневого класса XML документа.</typeparam>
        /// <param name="fileName">Имя файла.</param>
        /// <returns>Возвращает экземпляр корневого класса.</returns>
        public static T Deserializer<T>(string fileName)
        {
            if (!File.Exists(fileName))
            {
                return default;
            }

            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (var writer = new StreamReader(fileName, Encoding.UTF8))
            {
                return (T)serializer.Deserialize(writer);
            }
        }
    }
}
