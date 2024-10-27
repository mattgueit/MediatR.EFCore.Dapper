using System.ComponentModel.DataAnnotations;

namespace TrainTickets.Core.Tickets
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        public int PassengerId { get; set; }
        public int JourneyId { get; set; }
    }
}
