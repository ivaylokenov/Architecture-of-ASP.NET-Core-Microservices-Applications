namespace CarRentalSystem.Dealers.Data.Models
{
    public class CarAd
    {
        public int Id { get; set; }

        public string Model { get; set; }

        public string ImageUrl { get; set; }

        public decimal PricePerDay { get; set; }

        public Options Options { get; set; }

        public string Location { get; set; }

        public bool IsAvailable { get; set; }

        public int DealerId { get; set; }

        public Dealer Dealer { get; set; }

        public int ManufacturerId { get; set; }

        public Manufacturer Manufacturer { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
