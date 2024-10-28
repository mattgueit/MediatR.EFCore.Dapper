using MediatR;

namespace TrainTickets.Core.Domain.Tickets
{
    public record CreateTicketCommand(int PassengerId, int JourneyId, DateTime ExpiryDate) : IRequest<Ticket>;
}
