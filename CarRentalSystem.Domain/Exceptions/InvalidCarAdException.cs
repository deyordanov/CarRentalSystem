namespace CarRentalSystem.Domain.Exceptions;

public class InvalidCarAdException : BaseDomainException
{
    private const string DefaultMessage = "Invalid car ad provided.";

    public InvalidCarAdException()
        => this.Message = DefaultMessage;

    public InvalidCarAdException(string message)
        => this.Message = message;
}