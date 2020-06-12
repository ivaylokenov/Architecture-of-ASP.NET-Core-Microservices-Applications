namespace CarRentalSystem.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Models.Dealers;
    using Services;
    using Services.Dealers;
    using Services.Identity;

    public class DealersController : ApiController
    {
        private readonly IDealerService dealers;
        private readonly ICurrentUserService currentUser;

        public DealersController(
            IDealerService dealers, 
            ICurrentUserService currentUser)
        {
            this.dealers = dealers;
            this.currentUser = currentUser;
        }

        [HttpGet]
        [Route(Id)]
        public async Task<ActionResult<DealerDetailsOutputModel>> Details(int id)
            => await this.dealers.GetDetails(id);

        [HttpPut]
        [Route(Id)]
        public async Task<ActionResult> Edit(int id, EditDealerInputModel input)
        {
            var dealer = await this.dealers.FindByUser(this.currentUser.UserId);

            if (id != dealer.Id)
            {
                return BadRequest(Result.Failure("You cannot edit this dealer."));
            }

            dealer.Name = input.Name;
            dealer.PhoneNumber = input.PhoneNumber;

            await this.dealers.Save(dealer);

            return Ok();
        }
    }
}
