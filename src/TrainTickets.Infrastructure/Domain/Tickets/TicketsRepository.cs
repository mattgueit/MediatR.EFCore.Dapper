using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainTickets.Core.Domain.Tickets;
using TrainTickets.Core.Storage.Database;

namespace TrainTickets.Infrastructure.Domain.Tickets
{
    public class TicketsRepository : ITicketsRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public TicketsRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<Ticket?> GetByIdAsync(int id)
        {
            using var dbConnection = await _connectionFactory.CreateConnectionAsync();

            var ticket = await dbConnection.QuerySingleOrDefaultAsync<Ticket>(
                """
                SELECT 
                    * 
                FROM "Tickets"
                WHERE "Id"=@id 
                LIMIT 1
                """, 
                new { Id = id }
            );

            return ticket;
        }
    }
}
