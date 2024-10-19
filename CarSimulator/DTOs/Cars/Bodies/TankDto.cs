
using CarSimulator.Models.Cars.Bodies;

namespace CarSimulator.DTOs.Cars.Bodies
{
    public class TankDto
    {
        public int Id { get; set; }
        public FuelType FuelType { get; set; }
        public int FuelAmount { get; set;}
    }
}
