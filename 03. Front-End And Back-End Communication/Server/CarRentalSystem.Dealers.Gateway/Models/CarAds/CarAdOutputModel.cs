namespace CarRentalSystem.Dealers.Gateway.Models.CarAds
{
    public class CarAdOutputModel
    {
        public int Id { get; set; }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public string ImageUrl { get; set; }

        public string Category { get; set; }

        public decimal PricePerDay { get; set; }

        public bool IsAvailable { get; private set; }
    }
}
