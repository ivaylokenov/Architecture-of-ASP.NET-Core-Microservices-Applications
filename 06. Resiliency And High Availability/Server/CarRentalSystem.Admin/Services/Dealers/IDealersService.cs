namespace CarRentalSystem.Admin.Services.Dealers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models.Dealers;
    using Refit;

    public interface IDealersService
    {
        [Get("/Dealers")]
        Task<IEnumerable<DealerDetailsOutputModel>> All();

        [Get("/Dealers/{id}")]
        Task<DealerDetailsOutputModel> Details(int id);

        [Put("/Dealers/{id}")]
        Task Edit(int id, DealerInputModel dealer);
    }
}
