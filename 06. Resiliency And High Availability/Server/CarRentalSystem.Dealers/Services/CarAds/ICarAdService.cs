namespace CarRentalSystem.Dealers.Services.CarAds
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CarRentalSystem.Services;
    using Data.Models;
    using Models.CarAds;

    public interface ICarAdService : IDataService<CarAd>
    {
        Task<CarAd> Find(int id);

        Task<bool> Delete(int id);

        Task<IEnumerable<CarAdOutputModel>> GetListings(CarAdsQuery query);

        Task<IEnumerable<MineCarAdOutputModel>> Mine(int dealerId, CarAdsQuery query);

        Task<CarAdDetailsOutputModel> GetDetails(int id);

        Task<int> Total(CarAdsQuery query);
    }
}
