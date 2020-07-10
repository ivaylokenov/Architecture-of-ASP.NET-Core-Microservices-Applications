namespace CarRentalSystem.Statistics.Services.Statistics
{
    using System.Threading.Tasks;
    using AutoMapper;
    using CarRentalSystem.Services;
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Models.Statistics;

    public class StatisticsService : DataService<Statistics>, IStatisticsService
    {
        private readonly IMapper mapper;

        public StatisticsService(StatisticsDbContext db, IMapper mapper) 
            : base(db)
        {
            this.mapper = mapper;
        }

        public async Task<StatisticsOutputModel> Full()
            => await this.mapper
                .ProjectTo<StatisticsOutputModel>(this.All())
                .SingleOrDefaultAsync();

        public async Task AddCarAd()
        {
            var statistics = await this.All().SingleOrDefaultAsync();

            statistics.TotalCarAds++;

            await this.Data.SaveChangesAsync();
        }
    }
}
