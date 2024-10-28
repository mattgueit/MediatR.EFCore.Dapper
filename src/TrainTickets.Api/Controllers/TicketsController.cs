using Microsoft.AspNetCore.Mvc;
using TrainTickets.Core.Domain.Tickets;
using TrainTickets.Infrastructure.Storage.Database.EntityFramework;

namespace TrainTickets.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketsRepository _ticketsRepository;
        private readonly AppDbContext _appDbContext;
        private readonly ILogger<TicketsController> _logger;

        public TicketsController(
            ITicketsRepository ticketsRepository,
            AppDbContext appDbContext,
            ILogger<TicketsController> logger
        )
        {
            _ticketsRepository = ticketsRepository;
            _appDbContext = appDbContext;
            _logger = logger;
        }

        [HttpGet("{ticketId}", Name = "GetTicket")]
        public async Task<Ticket> Get([FromRoute] int ticketId)
        {
            return await this._ticketsRepository.GetByIdAsync(ticketId) ?? throw new Exception($"No such ticket with Id {ticketId}.");
        }

        [HttpPost(Name = "CreateTicket")]
        public void Create([FromBody] Ticket ticket)
        {
            _appDbContext.Tickets.Add(ticket);

            _appDbContext.SaveChanges();
        }
    }
}
