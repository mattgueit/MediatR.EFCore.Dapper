using TrainTickets.Core.Domain.Tickets;
using TrainTickets.Infrastructure.Storage.Database.EntityFramework;
using MediatR;
using TrainTickets.Core.Domain;

namespace TrainTickets.Infrastructure.Domain.Tickets
{
    public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand, Ticket>
    {
        private readonly AppDbContext _appDbContext;

        public CreateTicketCommandHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Ticket> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
        {
            var ticket = request.MapToTicket();

            var result = await _appDbContext.Tickets.AddAsync(ticket, cancellationToken);

            await _appDbContext.SaveChangesAsync(cancellationToken);

            return result.Entity;
        }
    }
}
