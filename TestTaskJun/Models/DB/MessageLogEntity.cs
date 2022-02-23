using Dapper.Contrib.Extensions;
namespace TestTaskJun.Models.DB
{
    [Table("MessageLogs")]
    public class MessageLogEntity
    {
        /// <summary>
        /// Уникальный идентификатор сообщения
        /// </summary>
        [Key]
        public long Id { get; set; }
        /// <summary>
        /// Тема письма
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// Тело письма
        /// </summary>
        public string Body { get; set; }
        /// <summary>
        /// Список получателей
        /// </summary>
        public string Recipients { get; set; }
        /// <summary>
        /// Результат отправки сообщения OK/Failed
        /// </summary>
        public string Result { get; set; }
        /// <summary>
        /// Информация об ошибке или пустая строка при успешной отправке
        /// </summary>
        public string FailedMessage { get; set; }
        /// <summary>
        /// Дата создания лога
        /// </summary>
        public DateTime Created { get; set; }
    }
}
