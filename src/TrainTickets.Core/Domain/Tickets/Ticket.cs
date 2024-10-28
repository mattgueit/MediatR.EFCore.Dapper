using System.ComponentModel.DataAnnotations;

namespace TrainTickets.Core.Domain.Tickets
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        public int PassengerId { get; set; }
        public int JourneyId { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
