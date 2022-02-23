using System.Data.SqlClient;
using Dapper;
using Dapper.Contrib.Extensions;
using TestTaskJun.Models.DB;
using TestTaskJun.Interfaces;
namespace TestTaskJun.Services
{
    public class DbManager : IDbManager
    {
        private readonly string _connectionString;
        private SqlConnection MssqlConn => !string.IsNullOrEmpty(_connectionString) ? new SqlConnection(_connectionString) : null;

        public DbManager (string connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task InsertMessageLog (MessageLogEntity entity)
        {
            using var conn = MssqlConn;
            await conn.InsertAsync(entity);
        }
        public async Task<List<MessageLogEntity>> GetMessageLogs()
        {
            using var conn = MssqlConn;
            var logs = await conn.GetAllAsync<MessageLogEntity>();
            return logs.ToList();
        }
    }
}
