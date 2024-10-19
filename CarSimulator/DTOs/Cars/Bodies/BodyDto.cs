
using CarSimulator.Models.Cars.Bodies;

namespace CarSimulator.DTOs.Cars.Bodies
{
    public class BodyDto
    {
        public int Id { get; set; }
        public SoundAlertType SelectedAlertType { get; set; }

        public required TankDto Tank { get; set; }
    }
}
