namespace CarRentalSystem.Domain.Models.Dealers;

using CarRentalSystem.Domain.Common;
using CarRentalSystem.Domain.Exceptions;

using static CarRentalSystem.Domain.Common.Constants.RegularExpressions;
using static ModelConstants.PhoneNumber;

public class PhoneNumber : ValueObject
{
    internal PhoneNumber(
        string number)
    {
        this.Validate(number);
        
        this.Number = number;
    }

    public string Number { get; }

    public static implicit operator string(PhoneNumber number)
        => number.Number;

    public static implicit operator PhoneNumber(string number)
        => new PhoneNumber(number);

    private void Validate(string number)
    {
        Guard.ForStringLength<InvalidPhoneNumberException>(
            number,
            MinimumPhoneNumberLength,
            MinimumPhoneNumberLength,
            nameof(PhoneNumber)
            );
        
        Guard.ForRegularExpression<InvalidPhoneNumberException>(
            number,
            PhoneNumberRegularExpression,
            nameof(ModelConstants.PhoneNumber));
    }
}