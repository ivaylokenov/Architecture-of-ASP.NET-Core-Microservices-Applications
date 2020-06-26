namespace CarRentalSystem.Dealers.Gateway.Models.CarAds
{
    using CarRentalSystem.Models;

    public class MineCarAdOutputModel : CarAdOutputModel, IMapFrom<CarAdOutputModel>
    {
        public int TotalViews { get; set; }
    }
}
