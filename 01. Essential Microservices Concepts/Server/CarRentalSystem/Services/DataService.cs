namespace CarRentalSystem.Services
{
    using System.Linq;
    using System.Threading.Tasks;
    using Data;

    public abstract class DataService<TEntity> : IDataService<TEntity>
        where TEntity : class
    {
        protected DataService(CarRentalDbContext db) => this.Data = db;

        protected CarRentalDbContext Data { get; }

        protected IQueryable<TEntity> All() => this.Data.Set<TEntity>();

        public async Task Save(
            TEntity entity)
        {
            this.Data.Update(entity);

            await this.Data.SaveChangesAsync();
        }
    }
}
