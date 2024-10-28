using MediatR;

namespace TrainTickets.Core.Domain.Tickets
{
    public record GetTicketQuery(int Id) : IRequest<Ticket?>;
}
