namespace CarRentalSystem.Dealers.Services.Categories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Data.Models;
    using Models.Categories;

    public interface ICategoryService
    {
        Task<Category> Find(int categoryId);

        Task<IEnumerable<CategoryOutputModel>> GetAll();
    }
}
