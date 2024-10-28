using System.Data;

namespace TrainTickets.Core.Storage.Database
{
    public interface IDbConnectionFactory
    {
        Task<IDbConnection> CreateConnectionAsync(CancellationToken token = default);
    }
}
