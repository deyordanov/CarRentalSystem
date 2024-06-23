namespace CarRentalSystem.Domain.Common;

public static class Constants
{
    public static class RegularExpressions
    {
        public const string PhoneNumberRegularExpression 
            = @"^\+?\d{1,4}[-.\s]?\(?\d{1,3}\)?[-.\s]?\d{1,4}[-.\s]?\d{1,4}[-.\s]?\d{1,9}$";
    }
}