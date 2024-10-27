using System.ComponentModel.DataAnnotations;

namespace TrainTickets.Core.Trains
{
    public class Train
    {
        [Key]
        public int Id { get; set; }
        public string Model { get; set; }
        public DateTime Built { get; set; }
    }
}
