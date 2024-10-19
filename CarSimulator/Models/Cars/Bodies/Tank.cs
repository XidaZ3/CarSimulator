using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarSimulator.Models.Cars.Bodies
{
    public enum FuelType
    {
        Octane95,
        Octane85
    }
    public class Tank
    {
        public int Id { get; set; }

        public FuelType FuelType { get; set; }

        public int FuelAmount { get; set; }

        public int BodyId { get; set; }

        [ForeignKey("BodyId")]
        public required Body Body { get; set; }

        public bool IsRunningOnPremiumFuel()
        {
            return FuelType == FuelType.Octane95;
        }

        public void RefillFuel(FuelType fuelType)
        {
            FuelType = fuelType;
            FuelAmount = GetMaximumFuelAmount();
        }

        public int GetMaximumFuelAmount()
        {
            return 100;
        }
    }
}
