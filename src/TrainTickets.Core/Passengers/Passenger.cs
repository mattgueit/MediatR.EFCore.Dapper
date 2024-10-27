
using System.ComponentModel.DataAnnotations;

namespace TrainTickets.Core.Passengers
{
    public class Passenger
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
