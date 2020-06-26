namespace CarRentalSystem.Messages.Dealers
{
    public class CarAdUpdatedMessage
    {
        public int CarAdId { get; set; }

        public string Manufacturer { get; set; }

        public string Model { get; set; }
    }
}
