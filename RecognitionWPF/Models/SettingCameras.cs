using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace RecognitionWPF.Models
{
    [XmlRoot(ElementName = "SettingCameras")]
    public class SettingCameras
    {
        /// <summary>
        /// Имя файла настроек.
        /// </summary>
        [XmlIgnore]
        public static readonly string FileName = "SettingCamera.xml";

        /// <summary>
        /// Единый порт для всех камер.
        /// </summary>
        [XmlElement(ElementName = "isUseMainPort")]
        public CheckMainParameter IsUseMainPort { get; set; } = new CheckMainParameter();

        /// <summary>
        /// Единый логин для всех камер.
        /// </summary>
        [XmlElement(ElementName = "isUseMainLogin")]
        public CheckMainParameter IsUseMainLogin { get; set; } = new CheckMainParameter();

        /// <summary>
        /// Единый пароль для всех камер.
        /// </summary>
        [XmlElement(ElementName = "isUseMainPassword")]
        public CheckMainParameter IsUseMainPassword { get; set; } = new CheckMainParameter();

        /// <summary>
        /// Единое количество кадров для распознавания.
        /// </summary>
        [XmlElement(ElementName = "isUseMainCameraFrameCount")]
        public CheckMainParameter IsUseMainCameraFrameCount { get; set; } = new CheckMainParameter();

        /// <summary>
        /// Единый временной интервал между получением кадров для распознавания.
        /// </summary>
        [XmlElement(ElementName = "isUseMainTimeBetweenFrame")]
        public CheckMainParameter IsUseMainTimeBetweenFrame { get; set; } = new CheckMainParameter();

        /// <summary>
        /// Единая высота символа в процентном соотношении от высоты кадра.
        /// </summary>
        [XmlElement(ElementName = "isUseMainHeigthWordPercent")]
        public CheckMainParameter IsUseMainHeigthWordPercent { get; set; } = new CheckMainParameter();

        /// <summary>
        /// Камеры.
        /// </summary>
        [XmlElement(ElementName = "Cameras")]
        public List<ConnetionsCamera> Cameras { get; set; } = new List<ConnetionsCamera>();

        public static SettingCameras DefaultValues()
        {
            return new SettingCameras
            {
                Cameras = new List<ConnetionsCamera> {
                        new ConnetionsCamera(){ ID = 1, Name="Камера 1" },
                        new ConnetionsCamera(){ ID = 2, Name="Камера 2" },
                        new ConnetionsCamera(){ ID = 3, Name="Камера 3" },
                        new ConnetionsCamera(){ ID = 4, Name="Камера 4" }
                    }
            };
        }
    }

    public class CheckMainParameter
    {
        /// <summary>
        /// Указывает использовать ли единый параметр.
        /// </summary>
        [XmlAttribute(AttributeName = "isChecked")]
        public bool IsChecked { get; set; }

        /// <summary>
        /// Значение единого параметра.
        /// </summary>
        [XmlElement(ElementName = "Value")]
        public string Value { get; set; } = String.Empty;
    }

    public class ConnetionsCamera
    {
        /// <summary>
        /// Внутренний идентификатор камеры.
        /// </summary>
        [XmlAttribute(AttributeName = "ID")]
        public int ID { get; set; }

        /// <summary>
        /// Указывает, используется ли камера.
        /// </summary>
        [XmlAttribute(AttributeName = "IsUsed")]
        public bool IsUsed { get; set; }

        /// <summary>
        /// Имя камеры.
        /// </summary>
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; } = String.Empty;

        /// <summary>
        /// Адрес подключения к камере.
        /// </summary>
        [XmlElement(ElementName = "Address")]
        public string Address { get; set; } = String.Empty;

        /// <summary>
        /// Порт подключения к камере.
        /// </summary>
        [XmlElement(ElementName = "Port")]
        public string Port { get; set; } = String.Empty;

        /// <summary>
        /// Логин подключения к камере.
        /// </summary>
        [XmlElement(ElementName = "Login")]
        public string Login { get; set; } = String.Empty;

        /// <summary>
        /// Пароль подключения к камере.
        /// </summary>
        [XmlElement(ElementName = "Password")]
        public string Password { get; set; } = String.Empty;

        /// <summary>
        /// Настройки работы с кадром камеры.
        /// </summary>
        [XmlElement(ElementName = "Frame")]
        public Frame Frame { get; set; } = new Frame();
    }

    public class Frame
    {
        /// <summary>
        /// Количество кадров для распознавания.
        /// </summary>
        [XmlElement(ElementName = "Count")]
        public int Count { get; set; } = 1;

        /// <summary>
        /// Временный интервал между получением кадров (мс).
        /// </summary>
        [XmlElement(ElementName = "TimeBetweenFrame")]
        public int TimeBetweenFrame { get; set; } = 100;

        /// <summary>
        /// Высота символа в процентном соотношении от высоты кадра.
        /// </summary>
        [XmlElement(ElementName = "HeigthWordPercent")]
        public int HeigthWordPercent { get; set; } = 15;
    }
}
