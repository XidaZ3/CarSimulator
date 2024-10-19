namespace CarSimulator.Exceptions.Cars.Bodies.Engines
{
    public class BurnEmptyTankException : UnprocessableEntityException
    {
        public BurnEmptyTankException(string message) : base(message) { }
}
}
