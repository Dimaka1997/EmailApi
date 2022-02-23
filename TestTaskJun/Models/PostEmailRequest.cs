namespace TestTaskJun.Models
{
    public class PostEmailRequest
    {
        /// <summary>
        /// Тема письма
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// Текст письма
        /// </summary>
        public string Body { get; set; }
        /// <summary>
        /// Получатели
        /// </summary>
        public List<string> Recipients { get; set; }
    }
}
