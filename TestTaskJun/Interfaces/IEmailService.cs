using TestTaskJun.Models;
namespace TestTaskJun.Interfaces
{
    public interface IEmailService
    {
        /// <summary>
        /// Метод отправки сообщения и записи результата в БД
        /// </summary>
        /// <param name="model"></param>
        Task SendEmailAsync(PostEmailRequest model);
    }
}
