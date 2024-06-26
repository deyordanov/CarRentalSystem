﻿namespace CarRentalSystem.Domain.Exceptions;

public static class DomainExceptionConstants
{
    public static class CarAdExceptionMessages
    {
        public const string CarShouldShouldHaveManufacturerAndCategoryAndOptions = "Manufacturer, category and options must have a valid value.";
    }
    
    public static class GuardExceptionMessages
    {
        public const string GuardAgainstEmptyStringExceptionMessage = "{0} cannot be null or empty.";
        public const string GuardForStringLengthExceptionMessage = "{0} must be between {1} and {2} symbols.";
        public const string GuardAgainstOutOfRangeExceptionMessage = "{0} must be between {1} and {2}.";
        public const string GuardForValidUrlExceptionMessage = "{0} must be a valid URL.";
        public const string GuardForRegularExpressionExceptionMessage = "{0} does not match the regular expression '{1}'.";
        public const string GuardAgainstExceptionMessage = "{0} must not be {1}.";
    }

    public static class EnumerationExceptionMessages
    {
        public const string InvalidEnumerationExceptionMessage = "'{0}' is not a valid {1} in {2}.";
    }

    public static class DealerExceptionMessages
    {
        public const string UserIsAlreadyADealer = "User '{0}' is already a dealer.";
    }
}