namespace CarRentalSystem.Data
{
    public class DataConstants
    {
        public class Common
        {
            public const int MinNameLength = 2;
            public const int MaxNameLength = 20;
            public const int MinEmailLength = 3;
            public const int MaxEmailLength = 50;
            public const int MaxUrlLength = 2048;
            public const int Zero = 0;
        }

        public class Category
        {
            public const int MinDescriptionLength = 20;
            public const int MaxDescriptionLength = 1000;
        }

        public class Options
        {
            public const int MinNumberOfSeats = 2;
            public const int MaxNumberOfSeats = 50;
        }

        public class Dealer
        {
            public const int MinPhoneNumberLength = 5;
            public const int MaxPhoneNumberLength = 20;
            public const string PhoneNumberRegularExpression = @"\+[0-9]*";
        }

        public class CarAd
        {
            public const int MinModelLength = 2;
            public const int MaxModelLength = 20;
        }
    }
}
