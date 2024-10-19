using System.ComponentModel.DataAnnotations.Schema;

namespace CarSimulator.Models.Cars
{

    public class Wheel
    {
        public int Id { get; set; }

        public int CarId { get; set; }

        [ForeignKey("CarId")]
        public required Car Car { get; set; }
    }
}
