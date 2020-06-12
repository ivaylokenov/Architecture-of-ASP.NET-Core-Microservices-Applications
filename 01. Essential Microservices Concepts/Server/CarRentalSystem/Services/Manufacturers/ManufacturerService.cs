namespace CarRentalSystem.Services.Manufacturers
{
    using System.Threading.Tasks;
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class ManufacturerService : DataService<Manufacturer>, IManufacturerService
    {
        public ManufacturerService(CarRentalDbContext db) 
            : base(db)
        {
        }

        public async Task<Manufacturer> FindByName(string name)
            => await this
                .Data
                .Manufacturers
                .FirstOrDefaultAsync(m => m.Name == name);
    }
}
