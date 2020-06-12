namespace CarRentalSystem.Services.Dealers
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using AutoMapper;
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Models.Dealers;

    public class DealerService : DataService<Dealer>, IDealerService
    {
        private readonly IMapper mapper;

        public DealerService(CarRentalDbContext db, IMapper mapper)
            : base(db)
            => this.mapper = mapper;

        public async Task<bool> HasCarAd(int dealerId, int carAdId)
            => await this
                .All()
                .Where(d => d.Id == dealerId)
                .AnyAsync(d => d.CarAds
                    .Any(c => c.Id == carAdId));

        public async Task<DealerDetailsOutputModel> GetDetails(int id)
            => await this.mapper
                .ProjectTo<DealerDetailsOutputModel>(this
                    .All()
                    .Where(d => d.Id == id))
                .FirstOrDefaultAsync();

        public async Task<DealerOutputModel> GetDetailsByCarId(int carAdId)
            => await this.mapper
                .ProjectTo<DealerOutputModel>(this
                    .All()
                    .Where(d => d.CarAds.Any(c => c.Id == carAdId)))
                .SingleOrDefaultAsync();

        public Task<int> GetIdByUser(
            string userId)
            => this.FindByUser(userId, dealer => dealer.Id);

        public Task<Dealer> FindByUser(
            string userId)
            => this.FindByUser(userId, dealer => dealer);

        private async Task<T> FindByUser<T>(
            string userId,
            Expression<Func<Dealer, T>> selector)
        {
            var dealerData = await this
                .Data
                .Dealers
                .Where(u => u.UserId == userId)
                .Select(selector)
                .FirstOrDefaultAsync();

            if (dealerData == null)
            {
                throw new InvalidOperationException("This user is not a dealer.");
            }

            return dealerData;
        }
    }
}
