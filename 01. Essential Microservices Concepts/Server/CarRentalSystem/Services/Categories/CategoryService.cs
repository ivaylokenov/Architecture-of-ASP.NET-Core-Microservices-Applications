namespace CarRentalSystem.Services.Categories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Models.Categories;

    public class CategoryService : DataService<Category>, ICategoryService
    {
        private readonly IMapper mapper;

        public CategoryService(CarRentalDbContext db, IMapper mapper) 
            : base(db) 
            => this.mapper = mapper;

        public async Task<Category> Find(int categoryId)
            => await this.Data.Categories.FindAsync(categoryId);

        public async Task<IEnumerable<CategoryOutputModel>> GetAll()
            => await this.mapper
                .ProjectTo<CategoryOutputModel>(this
                    .Data.Categories)
                .ToListAsync();
    }
}
