using System.ComponentModel.DataAnnotations;

namespace TrainTickets.Core.Domain.Journeys
{
    public class Journey
    {
        [Key]
        public int Id { get; set; }
        public int TrainId { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureTime { get; set; }
    }
}
