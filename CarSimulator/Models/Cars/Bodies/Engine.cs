using CarSimulator.Exceptions.Cars.Bodies.Engines;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarSimulator.Models.Cars.Bodies
{

    public class Engine
    {
        public int Id { get; set; }

        public int BodyId { get; set; }

        [ForeignKey("BodyId")]
        public required Body Body { get; set; }

        public void BurnFuel()
        {
            if (Body.Tank.FuelAmount > 0)
            {
                Body.Tank.FuelAmount -= StandardFuelBurnt();
                if(Body.Tank.FuelAmount < 0)
                {
                    Body.Tank.FuelAmount = 0;
                }
                
            } else
            {
                throw new BurnEmptyTankException("Tank is empty, cannot burn fuel");
            }
        }

        public int MaxSpeedSupported()
        {
            return 200;
        }

        public int StandardFuelBurnt()
        {
            return 5;
        }
    }
}
