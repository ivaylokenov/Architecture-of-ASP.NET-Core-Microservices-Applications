namespace CarRentalSystem.Dealers.Data
{
    public class DataConstants
    {
        public class Categories
        {
            public const int MinDescriptionLength = 20;
            public const int MaxDescriptionLength = 1000;
        }

        public class Options
        {
            public const int MinNumberOfSeats = 2;
            public const int MaxNumberOfSeats = 50;
        }

        public class Dealers
        {
            public const int MinPhoneNumberLength = 5;
            public const int MaxPhoneNumberLength = 20;
            public const string PhoneNumberRegularExpression = @"\+[0-9]*";
        }

        public class CarAds
        {
            public const int MinModelLength = 2;
            public const int MaxModelLength = 20;
        }
    }
}
