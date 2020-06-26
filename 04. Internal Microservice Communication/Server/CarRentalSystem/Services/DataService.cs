namespace CarRentalSystem.Services
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    public abstract class DataService<TEntity> : IDataService<TEntity>
        where TEntity : class
    {
        protected DataService(DbContext db) => this.Data = db;

        protected DbContext Data { get; }

        protected IQueryable<TEntity> All() => this.Data.Set<TEntity>();

        public async Task Save(
            TEntity entity)
        {
            this.Data.Update(entity);

            await this.Data.SaveChangesAsync();
        }
    }
}
