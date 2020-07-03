namespace CarRentalSystem.Admin.Services.Statistics
{
    using System.Threading.Tasks;
    using Models.Statistics;
    using Refit;

    public interface IStatisticsService
    {
        [Get("/Statistics")]
        Task<StatisticsOutputModel> Full();
    }
}
