namespace CarRentalSystem.Dealers.Gateway.Services.CarAds
{
    using System.Threading.Tasks;
    using Models.CarAds;
    using Refit;

    public interface ICarAdService
    {
        [Get("/CarAds/Mine")]
        Task<MineCarAdsOutputModel> Mine();
    }
}
