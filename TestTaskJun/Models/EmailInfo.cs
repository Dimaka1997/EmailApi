using TestTaskJun.Models.DB;
namespace TestTaskJun.Models
{
    public class EmailInfo
    {
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

        public EmailInfo (MessageLogEntity entity)
        {
            Subject = entity.Subject;
            Body = entity.Body;
            Recipients = entity.Recipients;
            Result = entity.Result;
            FailedMessage = entity.FailedMessage;
            Created = entity.Created;
        }
    }
}
