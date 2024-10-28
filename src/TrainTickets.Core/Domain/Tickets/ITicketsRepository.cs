using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainTickets.Core.Domain.Tickets
{
    public interface ITicketsRepository
    {
        Task<Ticket?> GetByIdAsync(int id);
    }
}
