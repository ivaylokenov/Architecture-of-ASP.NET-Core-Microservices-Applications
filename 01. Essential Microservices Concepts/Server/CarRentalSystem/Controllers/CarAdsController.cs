namespace CarRentalSystem.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Data.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models.CarAds;
    using Models.Categories;
    using Services;
    using Services.CarAds;
    using Services.Categories;
    using Services.Dealers;
    using Services.Identity;
    using Services.Manufacturers;

    public class CarAdsController : ApiController
    {
        private readonly ICarAdService carAds;
        private readonly IDealerService dealers;
        private readonly ICategoryService categories;
        private readonly IManufacturerService manufacturers;
        private readonly ICurrentUserService currentUser;

        public CarAdsController(
            ICarAdService carAds, 
            IDealerService dealers,
            ICategoryService categories,
            IManufacturerService manufacturers,
            ICurrentUserService currentUser)
        {
            this.carAds = carAds;
            this.dealers = dealers;
            this.categories = categories;
            this.manufacturers = manufacturers;
            this.currentUser = currentUser;
        }

        [HttpGet]
        public async Task<ActionResult<SearchCarAdsOutputModel>> Search(
            [FromQuery] CarAdsQuery query)
        {
            var carAdListings = await this.carAds.GetListings(query);

            var totalPages = await this.carAds.Total(query);

            return new SearchCarAdsOutputModel(carAdListings, query.Page, totalPages);
        }

        [HttpGet]
        [Route(Id)]
        public async Task<ActionResult<CarAdDetailsOutputModel>> Details(int id)
            => await this.carAds.GetDetails(id);

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<CreateCarAdOutputModel>> Create(CarAdInputModel input)
        {
            var dealer = await this.dealers.FindByUser(this.currentUser.UserId);

            var category = await this.categories.Find(input.Category);

            if (category == null)
            {
                return BadRequest(Result.Failure("Category does not exist."));
            }

            var manufacturer = await this.manufacturers.FindByName(input.Manufacturer);

            manufacturer ??= new Manufacturer
            {
                Name = input.Manufacturer
            };

            var carAd = new CarAd
            {
                Dealer = dealer,
                Manufacturer = manufacturer,
                Model = input.Model,
                Category = category,
                ImageUrl = input.ImageUrl,
                PricePerDay = input.PricePerDay,
                Options = new Options
                {
                    HasClimateControl = input.HasClimateControl,
                    NumberOfSeats = input.NumberOfSeats,
                    TransmissionType = input.TransmissionType
                }
            };

            await this.carAds.Save(carAd);

            return new CreateCarAdOutputModel(carAd.Id);
        }

        [HttpPut]
        [Authorize]
        [Route(Id)]
        public async Task<ActionResult> Edit(int id, CarAdInputModel input)
        {
            var dealerId = await this.dealers.GetIdByUser(this.currentUser.UserId);

            var dealerHasCar = await this.dealers.HasCarAd(dealerId, id);

            if (!dealerHasCar)
            {
                return BadRequest(Result.Failure("You cannot edit this car ad."));
            }

            var category = await this.categories.Find(input.Category);

            var manufacturer = await this.manufacturers.FindByName(input.Manufacturer);

            manufacturer ??= new Manufacturer
            {
                Name = input.Manufacturer
            };

            var carAd = await this.carAds.Find(id);

            carAd.Manufacturer = manufacturer;
            carAd.Model = input.Model;
            carAd.Category = category;
            carAd.ImageUrl = input.ImageUrl;
            carAd.PricePerDay = input.PricePerDay;
            carAd.Options = new Options
            {
                HasClimateControl = input.HasClimateControl,
                NumberOfSeats = input.NumberOfSeats,
                TransmissionType = input.TransmissionType
            };

            await this.carAds.Save(carAd);

            return Result.Success;
        }

        [HttpDelete]
        [Authorize]
        [Route(Id)]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var dealerId = await this.dealers.GetIdByUser(this.currentUser.UserId);

            var dealerHasCar = await this.dealers.HasCarAd(dealerId, id);

            if (!dealerHasCar)
            {
                return BadRequest(Result.Failure("You cannot edit this car ad."));
            }

            return await this.carAds.Delete(id);
        }

        [HttpGet]
        [Authorize]
        [Route(nameof(Mine))]
        public async Task<ActionResult<MineCarAdsOutputModel>> Mine(
            [FromQuery] CarAdsQuery query)
        {
            var dealerId = await this.dealers.GetIdByUser(this.currentUser.UserId);

            var carAdListings = await this.carAds.Mine(dealerId, query);

            var totalPages = await this.carAds.Total(query);

            return new MineCarAdsOutputModel(carAdListings, query.Page, totalPages);
        }

        [HttpGet]
        [Route(nameof(Categories))]
        public async Task<IEnumerable<CategoryOutputModel>> Categories()
            => await this.categories.GetAll();

        [HttpPut]
        [Authorize]
        [Route(Id + PathSeparator + nameof(ChangeAvailability))]
        public async Task<ActionResult> ChangeAvailability(int id)
        {
            var dealerId = await this.dealers.GetIdByUser(this.currentUser.UserId);

            var dealerHasCar = await this.dealers.HasCarAd(dealerId, id);

            if (!dealerHasCar)
            {
                return BadRequest(Result.Failure("You cannot edit this car ad."));
            }

            var carAd = await this.carAds.Find(id);

            carAd.IsAvailable = !carAd.IsAvailable;

            await this.carAds.Save(carAd);

            return Result.Success;
        }
    }
}
