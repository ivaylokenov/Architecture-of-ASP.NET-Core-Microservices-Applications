namespace CarRentalSystem.Messages.Dealers
{
    public class CarAdCreatedMessage
    {
        public int CarAdId { get; set; }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public decimal PricePerDay { get; set; }
    }
}
