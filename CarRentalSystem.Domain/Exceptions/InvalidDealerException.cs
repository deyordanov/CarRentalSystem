namespace CarRentalSystem.Domain.Exceptions;

public class InvalidDealerException : BaseDomainException
{
    private const string DefaultMessage = "Invalid dealer provided";

    public InvalidDealerException()
        => this.Message = DefaultMessage;

    public InvalidDealerException(string message)
        => this.Message = message;
}