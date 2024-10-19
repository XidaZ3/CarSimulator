namespace CarSimulator.Exceptions
{
    public interface ICustomException
    {
        string UserMessage { get; }
    }

    public class ValidationException : Exception, ICustomException
    {
        public string UserMessage => "Validation error occurred.";
        public ValidationException(string message) : base(message) { }
    }

    public class NotFoundException : Exception, ICustomException
    {
        public string UserMessage => "The requested resource was not found.";
        public NotFoundException(string message) : base(message) { }
    }

    public class UnprocessableEntityException : Exception, ICustomException
    {
        public string UserMessage => "Unprocessable entity.";
        public UnprocessableEntityException(string message) : base(message) { }
    }
}
