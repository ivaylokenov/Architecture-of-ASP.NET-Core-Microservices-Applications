namespace CarRentalSystem.Controllers
{
    using System.Threading.Tasks;
    using Data.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models.Identity;
    using Services.Dealers;
    using Services.Identity;

    public class IdentityController : ApiController
    {
        private readonly IIdentityService identity;
        private readonly ICurrentUserService currentUser;
        private readonly IDealerService dealers;

        public IdentityController(
            IIdentityService identity,
            ICurrentUserService currentUser,
            IDealerService dealers)
        {
            this.identity = identity;
            this.currentUser = currentUser;
            this.dealers = dealers;
        }

        [HttpPost]
        [Route(nameof(Register))]
        public async Task<ActionResult> Register(
            CreateUserInputModel input)
        {
            var result = await this.identity.Register(input);

            if (!result.Succeeded)
            {
                return BadRequest(result);
            }

            var user = result.Data;

            var dealer = new Dealer
            {
                Name = input.Name,
                PhoneNumber = input.PhoneNumber,
                UserId = user.Id
            };

            await this.dealers.Save(dealer);

            return Ok();
        }

        [HttpPost]
        [Route(nameof(Login))]
        public async Task<ActionResult<LoginOutputModel>> Login(
            UserInputModel input)
        {
            var result = await this.identity.Login(input);

            if (!result.Succeeded)
            {
                return BadRequest(result);
            }

            var user = result.Data;

            var dealerId = await this.dealers.GetIdByUser(user.UserId);

            return new LoginOutputModel(user.Token, dealerId);
        }

        [HttpPut]
        [Authorize]
        [Route(nameof(ChangePassword))]
        public async Task<ActionResult> ChangePassword(
            ChangePasswordInputModel input)
            => await this.identity.ChangePassword(new ChangePasswordInputModel
            {
                UserId = this.currentUser.UserId,
                CurrentPassword = input.CurrentPassword,
                NewPassword = input.NewPassword
            });
    }
}