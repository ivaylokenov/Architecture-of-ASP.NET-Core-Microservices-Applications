namespace CarRentalSystem.Dealers.Services.Dealers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CarRentalSystem.Services;
    using Data.Models;
    using Models.Dealers;

    public interface IDealerService : IDataService<Dealer>
    {
        Task<Dealer> FindByUser(string userId);

        Task<Dealer> FindById(int id);

        Task<int> GetIdByUser(string userId);

        Task<bool> HasCarAd(int dealerId, int carAdId);

        Task<bool> IsDealer(string userId);

        Task<IEnumerable<DealerDetailsOutputModel>> GetAll();

        Task<DealerDetailsOutputModel> GetDetails(int id);

        Task<DealerOutputModel> GetDetailsByCarId(int carAdId);
    }
}
