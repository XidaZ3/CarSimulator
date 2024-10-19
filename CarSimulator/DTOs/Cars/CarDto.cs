
using CarSimulator.DTOs.Cars.Bodies;
using CarSimulator.Models.Cars;

namespace CarSimulator.DTOs
{
    public class CarDto
    {
        public int Id { get; set; }
        public CarType Type { get; set; }

        public required BodyDto Body { get; set; }
    }
}
