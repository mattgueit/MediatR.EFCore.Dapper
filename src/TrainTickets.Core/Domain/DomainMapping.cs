using TrainTickets.Core.Domain.Tickets;

namespace TrainTickets.Core.Domain
{
    public static class DomainMapping
    {
        public static Ticket MapToTicket(this CreateTicketCommand command)
        {
            return new Ticket
            {
                JourneyId = command.JourneyId,
                PassengerId = command.PassengerId,
                ExpiryDate = command.ExpiryDate
            };
        }
    }
}
