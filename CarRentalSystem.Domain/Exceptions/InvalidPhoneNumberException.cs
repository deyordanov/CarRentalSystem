namespace CarRentalSystem.Domain.Exceptions;

public class InvalidPhoneNumberException : BaseDomainException
{
    private const string DefaultMessage = "Invalid phone number provided";

    public InvalidPhoneNumberException()
        => this.Message = DefaultMessage;

    public InvalidPhoneNumberException(string message)
        => this.Message = message;
}