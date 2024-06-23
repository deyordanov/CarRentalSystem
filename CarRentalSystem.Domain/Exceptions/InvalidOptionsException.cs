namespace CarRentalSystem.Domain.Exceptions;

public class InvalidOptionsException : BaseDomainException
{
    private const string DefaultMessage = "Ivalid options provided.";

    public InvalidOptionsException()
        => this.Message = DefaultMessage;
    
    public InvalidOptionsException(string message)
        => this.Message = message;
}