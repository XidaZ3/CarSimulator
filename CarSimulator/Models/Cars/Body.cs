using CarSimulator.Models.Cars.Bodies;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarSimulator.Models.Cars
{
    public class Body
    {

        public int Id { get; set; }

        public int CarId { get; set; }

        [ForeignKey("CarId")]
        public required Car Car { get; set; }

        public SoundAlertType SelectedAlertType { get; set; }

        public Accelerator Accelerator { get; set; }

        public Brake Brake { get; set; }

        public Tank Tank { get; set; }

        public Engine Engine { get; set; }

        public SteeringWheel SteeringWheel { get; set; }

        public Body() {
            SteeringWheel = new SteeringWheel { Body = this };
            Accelerator = new Accelerator { Body = this };
            Brake = new Brake { Body = this };
            Tank = new Tank { Body = this };
            Engine = new Engine { Body = this };
        }

        public Body(Car car)
        {
            Car = car;

            if (Car.Type == CarType.Truck)
            {
                SelectedAlertType = SoundAlertType.Trumpet;
            }
            else
            {
                Random random = new Random();
                double hornProbability = random.NextDouble();

                if (hornProbability <= 0.9)
                {
                    SelectedAlertType = SoundAlertType.Horn;
                }
                else
                {
                    SelectedAlertType = SoundAlertType.Trumpet;
                }
            }

            SteeringWheel = new SteeringWheel { Body = this };
            Accelerator = new Accelerator { Body = this };
            Brake = new Brake { Body = this };
            Tank = new Tank { Body = this };
            Engine = new Engine { Body = this };
        }

        public string Honk()
        {
            ISoundAlert soundAlert = SoundAlertFactory.GetSoundAlert(SelectedAlertType);
            return soundAlert.Sound();
        }
    }
}
