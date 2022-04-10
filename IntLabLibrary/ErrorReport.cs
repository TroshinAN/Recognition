using System;
using Newtonsoft.Json;

namespace IntLabLibrary
{
    /// <summary>
    /// Подробный отчет о последней ошибке.
    /// </summary>
    public class ErrorReport
    {
        /// <summary>
        /// Пользовательское имя объекта.
        /// </summary>
        [JsonProperty(PropertyName = "object_name")]
        public string ObjectName { get; set; }

        /// <summary>
        /// Последняя вызванная функция.
        /// </summary>
        [JsonProperty(PropertyName = "source")]
        public string Source { get; set; }

        /// <summary>
        /// Причина ошибки в виде значения кода ошибки .
        /// </summary>
        [JsonProperty(PropertyName = "err_reason")]
        public string ErrorReason { get; set; }

        /// <summary>
        /// Дополнительное объяснение.
        /// </summary>
        [JsonProperty(PropertyName = "err_message")]
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Код ошибки.
        /// </summary>
        [JsonProperty(PropertyName = "err_code")]
        public string ErrorCode { get; set; }

        /// <summary>
        /// Категория ошибки (IRE, система, общая).
        /// </summary>
        [JsonProperty(PropertyName = "err_category")]
        public string ErrorCategory { get; set; }

        /// <summary>
        /// Категория ошибки (IRE, система, общая).
        /// </summary>
        [JsonProperty(PropertyName = "err_utc_time")]
        public DateTime ErrorUtcTime { get; set; }

        /// <summary>
        /// Дескриптор объекта.
        /// </summary>
        [JsonProperty(PropertyName = "obj_handle")]
        public Int64 ObjectHandle { get; set; }

        /// <summary>
        /// Положение источника ошибки по результатам отладки.
        /// </summary>
        [JsonProperty(PropertyName = "err_location")]
        public string ErrorLocation { get; set; }

        /// <summary>
        /// Внутренне состояние объекта.
        /// </summary>
        [JsonProperty(PropertyName = "obj_state")]
        public string ObjectState { get; set; }

        /// <summary>
        /// Является ли интерфейс по отношению к объекту потокобезопасным.
        /// </summary>
        [JsonProperty(PropertyName = "obj_threadsafe")]
        public bool ObjectThreadSafe { get; set; }

        /// <summary>
        /// Внутренний численный идентификатор.
        /// </summary>
        [JsonProperty(PropertyName = "obj_number_id")]
        public Int64 ObjectNumberId { get; set; }

        /// <summary>
        /// Счетчик общего числа вызовов.
        /// </summary>
        [JsonProperty(PropertyName = "total_call_counter")]
        public Int64 TotalCallCounter { get; set; }

        /// <summary>
        /// Счетчик ошибок многопоточности, обнаруженных IRE.
        /// </summary>
        [JsonProperty(PropertyName = "obj_threading_failures")]
        public Int64 ObjectThreadingFailures { get; set; }

        /// <summary>
        /// Счетчик внутренних критических отказов, обнаруженных IRE.
        /// </summary>
        [JsonProperty(PropertyName = "obj_internal_failures")]
        public Int64 ObjectInternalFailures { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса.
        /// </summary>
        public ErrorReport()
        {
            this.ErrorCategory = String.Empty;
            this.ErrorCode = String.Empty;
            this.ErrorLocation = String.Empty;
            this.ErrorMessage = String.Empty;
            this.ErrorReason = String.Empty;
            this.ErrorUtcTime = new DateTime();
            this.ObjectName = String.Empty;
            this.ObjectState = String.Empty;
            this.Source = String.Empty;
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
