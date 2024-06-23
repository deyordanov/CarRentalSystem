namespace CarRentalSystem.Domain.Models;

public static class ModelConstants
{
    public static class Common
    {
        public const int MinimumNameLength = 2;
        public const int MaximumNameLength = 20;
        public const int MaximumUrlLength = 2048;
        public const int Zero = 0;
    }

    public class Category
    {
        public const int MinimumDescriptionLength = 20;
        public const int MaximumDescriptionLength = 1000;
    }

    public class Options
    {
        public const int MinimumNumberOfSeats = 2;
        public const int MaximumNumberOfSeats = 50;
    }

    public class PhoneNumber
    {
        public const int MinimumPhoneNumberLength = 5;
        public const int MaximumPhoneNumberLength = 23;
        public const string PhoneNumberFirstSymbol = "+";
    }

    public class CarAd
    {
        public const int MinimumModelLength = 2;
        public const int MaximumModelLength = 20;
    }
}