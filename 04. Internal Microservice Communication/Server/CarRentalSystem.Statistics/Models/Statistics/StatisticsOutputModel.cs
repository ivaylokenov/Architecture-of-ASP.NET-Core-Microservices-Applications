namespace CarRentalSystem.Statistics.Models.Statistics
{
    using CarRentalSystem.Models;
    using Data.Models;

    public class StatisticsOutputModel : IMapFrom<Statistics>
    {
        public int TotalCarAds { get; set; }

        public int TotalRentedCars { get; set; }
    }
}
