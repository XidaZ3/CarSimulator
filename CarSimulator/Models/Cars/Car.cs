namespace CarSimulator.Models.Cars
{
    public enum CarType
    {
        Compact,
        Sport,
        SUV,
        Truck,
    }

    public class Car
    {
        public Car()
        {
            Random random = new Random();

            CarType[] carTypes = (CarType[])Enum.GetValues(typeof(CarType));

            Type = carTypes[random.Next(carTypes.Length)];

            Wheels = new List<Wheel>
            {
                new Wheel { Car = this},
                new Wheel { Car = this},
                new Wheel { Car = this},
                new Wheel { Car = this}
            };

            Body = new Body(this) { Car  = this};
            Direction = 0;
            Speed = 0;
        }
        public int Id { get; set; }
        public int Direction { get; set; }
        public int Speed { get; set; }
        public Body Body { get; set; }
        public CarType Type { get; set; }
        public ICollection<Wheel> Wheels { get; set; } = [];


        public bool IsNumberOfWheelsValid()
        {
            return Wheels != null && Wheels.Count == ValidNumberOfWheelsNeeded();
        }

        public static int ValidNumberOfWheelsNeeded()
        {
            return 4;
        }
    }
}
