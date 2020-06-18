namespace CarRentalSystem.Statistics.Services.CarAdViews
{
    using System.Threading.Tasks;
    using CarRentalSystem.Services;
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class CarAdViewService : DataService<CarAdView>, ICarAdViewService
    {
        public CarAdViewService(StatisticsDbContext db)
            : base(db)
        {
        }

        public async Task<int> GetTotalViews(int carAdId)
            => await this
                .All()
                .CountAsync(v => v.CarAdId == carAdId);
    }
}
