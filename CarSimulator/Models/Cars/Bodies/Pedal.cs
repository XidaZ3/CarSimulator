using System.ComponentModel.DataAnnotations.Schema;

namespace CarSimulator.Models.Cars.Bodies
{
    public abstract class Pedal
    {
        public int Id { get; set; }

        public int BodyId { get; set; }

        [ForeignKey("BodyId")]
        public required Body Body { get; set; }

        abstract public void Push();
    }

    public class Accelerator : Pedal
    {
        // TODO: if the interaction is more complex should consider to abstract Car and from its implementation (Truck, Sport, etc...)

        public override void Push()
        {
            int acceleration = 0;

            Dictionary<CarType, int> accelerationMap = new Dictionary<CarType, int>
            {
                { CarType.Truck, 4 },
                { CarType.Sport, 7 }
            };

            acceleration = accelerationMap.TryGetValue(Body.Car.Type, out int mappedAcceleration) ? mappedAcceleration : 5;

            if (Body.Tank.IsRunningOnPremiumFuel())
            {
                acceleration += 1;
            }

            Body.Engine.BurnFuel();
            Body.Car.Speed = (Body.Car.Speed + acceleration > Body.Engine.MaxSpeedSupported()) ? Body.Engine.MaxSpeedSupported() : Body.Car.Speed + acceleration;
        }
    }

    public class Brake : Pedal
    {
        public override void Push()
        {
            int deceleration = 0;

            deceleration = (Body.Car.Type == CarType.Truck) ? 6 : 10;
            Body.Car.Speed = (Body.Car.Speed - deceleration < 0) ? 0 : Body.Car.Speed - deceleration;
        }
    }
}
