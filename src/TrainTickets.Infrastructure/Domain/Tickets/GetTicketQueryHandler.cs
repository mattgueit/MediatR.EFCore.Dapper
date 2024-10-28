using MediatR;
using TrainTickets.Core.Domain.Tickets;

namespace TrainTickets.Infrastructure.Domain.Tickets
{
    public class GetTicketQueryHandler : IRequestHandler<GetTicketQuery, Ticket?>
    {
        private ITicketsRepository _ticketRepository;

        public GetTicketQueryHandler(ITicketsRepository ticketsRepository)
        {
            _ticketRepository = ticketsRepository;
        }

        public async Task<Ticket?> Handle(GetTicketQuery request, CancellationToken cancellationToken)
        {
            return await _ticketRepository.GetByIdAsync(request.Id);
        }
    }
}