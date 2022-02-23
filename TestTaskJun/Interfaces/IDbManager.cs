using TestTaskJun.Models.DB;
namespace TestTaskJun.Interfaces
{
    public interface IDbManager
    {
        /// <summary>
        /// Запись информационного лога о доставке сообщения в БД
        /// </summary>
        /// <param name="entity"></param>
        Task InsertMessageLog(MessageLogEntity entity);
        /// <summary>
        /// Запрос списка информационных логов из БД
        /// </summary>
        /// <returns>Все логи, имеющиеся в бд</returns>
        Task<List<MessageLogEntity>> GetMessageLogs();
    }
}
