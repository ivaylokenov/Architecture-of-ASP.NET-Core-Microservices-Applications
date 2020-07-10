namespace CarRentalSystem.Dealers.Gateway.Services.CarAdViews
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models.CarAdViews;
    using Refit;

    public interface ICarAdViewService
    {
        [Get("/CarAdViews")]
        Task<IEnumerable<CarAdViewOutputModel>> TotalViews(
            [Query(CollectionFormat.Multi)] IEnumerable<int> ids);
    }
}
