namespace CarRentalSystem.Data.Models
{
    using System.Collections.Generic;

    public class Dealer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public ICollection<CarAd> CarAds { get; set; } = new List<CarAd>();
    }
}