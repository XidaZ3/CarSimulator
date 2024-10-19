using System.ComponentModel.DataAnnotations.Schema;

namespace CarSimulator.Models.Cars.Bodies
{
    public class SteeringWheel
    {
        public int Id { get; set; }

        public int BodyId { get; set; }

        [ForeignKey("BodyId")]
        public required Body Body { get; set; }

        public void Steer(int degrees)
        {
            Body.Car.Direction += degrees;

            if (Body.Car.Direction > 450)
            {
                Body.Car.Direction = 450;
            }
            else if (Body.Car.Direction < -450)
            {
                Body.Car.Direction = -450;
            }
        }
    }
}
