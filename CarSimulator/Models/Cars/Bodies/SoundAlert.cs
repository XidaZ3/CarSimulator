namespace CarSimulator.Models.Cars.Bodies
{
    public enum SoundAlertType
    {
        Horn,
        Trumpet
    }

    public interface ISoundAlert
    {
        string Sound();
    }

    public class Horn : ISoundAlert
    {
        public string Sound()
        {
            return "Beep!";
        }
    }

    public class Trumpet : ISoundAlert
    {
        public string Sound()
        {
            return "Da-da-da-da-daah!";
        }
    }

    public class SoundAlertFactory
    {
        public static ISoundAlert GetSoundAlert(SoundAlertType alertType)
        {
            return alertType switch
            {
                SoundAlertType.Horn => new Horn(),
                SoundAlertType.Trumpet => new Trumpet(),
                _ => throw new ArgumentOutOfRangeException(nameof(alertType), alertType, null)
            };
        }
    }
}
