namespace CarRentalSystem.Domain.Common;

using System.Text.RegularExpressions;

using CarRentalSystem.Domain.Exceptions;
using CarRentalSystem.Domain.Models;

using static Exceptions.ExceptionConstants.Guard;

public static class Guard
{
    private const string Value = "Value";
    
    public static void AgainstEmptyString<TException>(string value, string name = Value)
        where TException : BaseDomainException, new()
    {
        if (!string.IsNullOrWhiteSpace(value))
        {
            return;
        }
        
        ThrowException<TException>(string.Format(GuardAgainstEmptyStringExceptionMessage, name));
    }

    public static void ForStringLength<TException>(string value, int minimumLength, int maximumLength, string name = Value)
        where TException : BaseDomainException, new()
    {
        var length = value.Length;

        if (length >= maximumLength && length <= maximumLength)
        {
            return;
        }
        
        ThrowException<TException>(string.Format(GuardForStringLengthExceptionMessage, name, minimumLength, maximumLength));
    }

    public static void AgainstOutOfRange<TException>(int number, int minimum, int maximum, string name = Value)
        where TException : BaseDomainException, new()
    {
        if (number >= minimum && number <= maximum)
        {
            return;
        }
        
        ThrowException<TException>(string.Format(GuardAgainstOutOfRangeExceptionMessage, name, minimum, maximum));
    }
    
    public static void AgainstOutOfRange<TException>(decimal number, decimal minimum, decimal maximum, string name = Value)
        where TException : BaseDomainException, new()
    {
        if (number >= minimum && number <= maximum)
        {
            return;
        }
        
        ThrowException<TException>(string.Format(GuardAgainstOutOfRangeExceptionMessage, name, minimum, maximum));
    }

    public static void ForValidUrl<TException>(string url, string name = Value)
        where TException : BaseDomainException, new()
    {
        if (url.Length <= ModelConstants.Common.MaximumUrlLength &&
            Uri.IsWellFormedUriString(url, UriKind.Absolute))
        {
            return;
        }
        
        ThrowException<TException>(string.Format(GuardForValidUrlExceptionMessage, name));
    }

    public static void ForRegularExpression<TException>(string value, string regularExpression, string name = Value)
        where TException : BaseDomainException, new()
    {
        if (Regex.IsMatch(value, regularExpression))
        {
            return;
        }
        
        ThrowException<TException>(string.Format(GuardForRegularExpressionExceptionMessage, name, regularExpression));
    }

    public static void Against<TException>(object actualValue, object unexpectedValue, string name = Value)
        where TException : BaseDomainException, new()
    {
        if (!actualValue.Equals(unexpectedValue))
        {
            return;
        }
        
        ThrowException<TException>(string.Format(GuardAgainstExceptionMessage, name, unexpectedValue));
    }
    
    private static void ThrowException<TException>(string message)
        where TException : BaseDomainException, new()
    {
        var exception = new TException()
        {
            Message = message,
        };

        throw exception;
    }
}