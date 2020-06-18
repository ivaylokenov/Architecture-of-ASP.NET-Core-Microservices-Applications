namespace CarRentalSystem.Statistics.Services.CarAdViews
{
    using System.Threading.Tasks;

    public interface ICarAdViewService
    {
        Task<int> GetTotalViews(int carAdId);
    }
}
