namespace CarRentalSystem.Statistics.Services.Statistics
{
    using System.Threading.Tasks;
    using Models.Statistics;

    public interface IStatisticsService
    {
        Task<StatisticsOutputModel> Full();

        Task AddCarAd();
    }
}
