namespace CarRentalSystem.Dealers.Services.Dealers
{
    using System.Threading.Tasks;
    using Data.Models;
    using Models.Dealers;

    public interface IDealerService : IDataService<Dealer>
    {
        Task<Dealer> FindByUser(string userId);

        Task<int> GetIdByUser(string userId);

        Task<bool> HasCarAd(int dealerId, int carAdId);

        Task<bool> IsDealer(string userId);

        Task<DealerDetailsOutputModel> GetDetails(int id);

        Task<DealerOutputModel> GetDetailsByCarId(int carAdId);
    }
}
