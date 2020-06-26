namespace CarRentalSystem.Dealers.Services.CarAds
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using CarRentalSystem.Services;
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Models.CarAds;

    public class CarAdService : DataService<CarAd>, ICarAdService
    {
        private const int CarAdsPerPage = 10;

        private readonly IMapper mapper;

        public CarAdService(DealersDbContext db, IMapper mapper)
            : base(db)
            => this.mapper = mapper;

        public async Task<CarAd> Find(int id)
            => await this
                .All()
                .Include(c => c.Manufacturer)
                .FirstOrDefaultAsync(c => c.Id == id);

        public async Task<bool> Delete(int id)
        {
            var carAd = await this.Data.FindAsync<CarAd>(id);

            if (carAd == null)
            {
                return false;
            }

            this.Data.Remove(carAd);

            await this.Data.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<CarAdOutputModel>> GetListings(CarAdsQuery query)
            => (await this.mapper
                .ProjectTo<CarAdOutputModel>(this
                    .GetCarAdsQuery(query))
                .ToListAsync())
                .Skip((query.Page - 1) * CarAdsPerPage)
                .Take(CarAdsPerPage); // SQL Server is old and forces me to execute paging on the client.

        public async Task<IEnumerable<MineCarAdOutputModel>> Mine(int dealerId, CarAdsQuery query)
            => (await this.mapper
                .ProjectTo<MineCarAdOutputModel>(this
                    .GetCarAdsQuery(query, dealerId))
                .ToListAsync())
                .Skip((query.Page - 1) * CarAdsPerPage)
                .Take(CarAdsPerPage); // SQL Server is old and forces me to execute paging on the client.

        public async Task<CarAdDetailsOutputModel> GetDetails(int id)
            => await this.mapper
                .ProjectTo<CarAdDetailsOutputModel>(this
                    .AllAvailable()
                    .Where(c => c.Id == id))
                .FirstOrDefaultAsync();

        public async Task<int> Total(CarAdsQuery query)
            => await this
                .GetCarAdsQuery(query)
                .CountAsync();

        private IQueryable<CarAd> AllAvailable()
            => this
                .All()
                .Where(car => car.IsAvailable);

        private IQueryable<CarAd> GetCarAdsQuery(
            CarAdsQuery query, int? dealerId = null)
        {
            var dataQuery = this.All();

            if (dealerId.HasValue)
            {
                dataQuery = dataQuery.Where(c => c.DealerId == dealerId);
            }

            if (query.Category.HasValue)
            {
                dataQuery = dataQuery.Where(c => c.CategoryId == query.Category);
            }

            if (!string.IsNullOrWhiteSpace(query.Manufacturer))
            {
                dataQuery = dataQuery.Where(c => c
                    .Manufacturer.Name.ToLower().Contains(query.Manufacturer.ToLower()));
            }

            return dataQuery;
        }
    }
}
