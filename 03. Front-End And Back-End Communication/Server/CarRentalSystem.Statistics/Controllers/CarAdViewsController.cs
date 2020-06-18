namespace CarRentalSystem.Statistics.Controllers
{
    using System.Threading.Tasks;
    using Dealers.Controllers;
    using Microsoft.AspNetCore.Mvc;
    using Services.CarAdViews;

    public class CarAdViewsController : ApiController
    {
        private readonly ICarAdViewService carAdViews;

        public CarAdViewsController(ICarAdViewService carAdViews) => this.carAdViews = carAdViews;

        [HttpGet]
        [Route(Id)]
        public async Task<ActionResult<int>> TotalViews(int id)
            => await this.carAdViews.GetTotalViews(id);
    }
}
