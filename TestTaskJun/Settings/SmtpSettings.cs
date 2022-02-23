namespace TestTaskJun.Settings
{
    public class SmtpSettings
    {
        /// <summary>
        /// Адрес SMTP сервера
        /// </summary>
        public string Host { get; set; }
        /// <summary>
        /// Порт SMTP для отправки сообщений
        /// </summary>
        public int Port { get; set; }
        /// <summary>
        /// Индикатор необходимости использования SSL
        /// </summary>
        public bool EnableSsl { get; set; }
        /// <summary>
        /// Имя пользователя при необходимости авторизации на сервере
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Почтовый адрес отправителя
        /// </summary>
        public string SourceEmail { get; set; }
        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }

    }
}
