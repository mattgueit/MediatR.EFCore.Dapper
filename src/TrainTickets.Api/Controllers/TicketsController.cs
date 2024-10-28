using MediatR;
using Microsoft.AspNetCore.Mvc;
using TrainTickets.Core.Domain.Tickets;

namespace TrainTickets.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<TicketsController> _logger;

        public TicketsController(
            IMediator mediator,
            ILogger<TicketsController> logger
        )
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("{ticketId}")]
        public async Task<Ticket> Get([FromRoute] int ticketId)
        {
            var query = new GetTicketQuery(ticketId);

            return await _mediator.Send(query) ?? throw new Exception($"No such ticket with Id: {ticketId}");
        }

        [HttpPost]
        public async Task<Ticket> Create([FromBody] CreateTicketCommand request)
        {
            var result = await _mediator.Send(request) ?? throw new Exception("Failed to create ticket.");

            return result;
        }
    }
}
