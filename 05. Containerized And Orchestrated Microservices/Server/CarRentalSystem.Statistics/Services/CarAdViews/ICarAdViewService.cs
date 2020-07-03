namespace CarRentalSystem.Statistics.Services.CarAdViews
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models.CarAdViews;

    public interface ICarAdViewService
    {
        Task<int> GetTotalViews(int carAdId);

        Task<IEnumerable<CarAdViewOutputModel>> GetTotalViews(IEnumerable<int> ids);
    }
}
