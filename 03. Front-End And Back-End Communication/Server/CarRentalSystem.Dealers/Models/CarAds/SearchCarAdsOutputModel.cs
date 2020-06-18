namespace CarRentalSystem.Dealers.Models.CarAds
{
    using System.Collections.Generic;

    public class SearchCarAdsOutputModel : CarAdsOutputModel<CarAdOutputModel>
    {
        public SearchCarAdsOutputModel(
            IEnumerable<CarAdOutputModel> carAds,
            int page,
            int totalPages)
            : base(carAds, page, totalPages)
        {
        }
    }
}
