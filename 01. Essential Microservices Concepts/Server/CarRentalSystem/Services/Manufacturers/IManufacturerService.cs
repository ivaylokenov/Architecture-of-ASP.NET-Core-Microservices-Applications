namespace CarRentalSystem.Services.Manufacturers
{
    using System.Threading.Tasks;
    using Data.Models;

    public interface IManufacturerService
    {
        Task<Manufacturer> FindByName(string name);
    }
}
