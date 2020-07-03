namespace CarRentalSystem.Dealers.Services.Manufacturers
{
    using System.Threading.Tasks;
    using CarRentalSystem.Services;
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class ManufacturerService : DataService<Manufacturer>, IManufacturerService
    {
        public ManufacturerService(DealersDbContext db) 
            : base(db)
        {
        }

        public async Task<Manufacturer> FindByName(string name)
            => await this
                .All()
                .FirstOrDefaultAsync(m => m.Name == name);
    }
}
