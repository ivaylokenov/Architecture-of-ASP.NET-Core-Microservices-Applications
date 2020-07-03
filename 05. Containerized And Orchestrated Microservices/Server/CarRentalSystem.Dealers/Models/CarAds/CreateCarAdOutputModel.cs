namespace CarRentalSystem.Dealers.Models.CarAds
{
    public class CreateCarAdOutputModel
    {
        public CreateCarAdOutputModel(int carAdId)
            => this.CarAdId = carAdId;

        public int CarAdId { get; }
    }
}
