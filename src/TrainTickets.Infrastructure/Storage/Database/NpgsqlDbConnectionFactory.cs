using Npgsql;
using System.Data;
using TrainTickets.Core.Storage.Database;

namespace TrainTickets.Infrastructure.Storage.Database
{
    public class NpgsqlDbConnectionFactory : IDbConnectionFactory
    {
        private string _connectionString;

        public NpgsqlDbConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IDbConnection> CreateConnectionAsync(CancellationToken token = default)
        {
            var connection = new NpgsqlConnection(_connectionString);
            await connection.OpenAsync();
            return connection;
        }
    }
}
