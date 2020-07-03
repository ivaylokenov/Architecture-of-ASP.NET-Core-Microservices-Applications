namespace CarRentalSystem.Dealers.Models.CarAds
{
    using System.Collections.Generic;

    public class MineCarAdsOutputModel : CarAdsOutputModel<MineCarAdOutputModel>
    {
        public MineCarAdsOutputModel(
            IEnumerable<MineCarAdOutputModel> carAds,
            int page,
            int totalPages)
            : base(carAds, page, totalPages)
        {
        }
    }
}
