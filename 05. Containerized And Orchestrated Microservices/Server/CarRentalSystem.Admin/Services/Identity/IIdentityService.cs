namespace CarRentalSystem.Admin.Services.Identity
{
    using System.Threading.Tasks;
    using Models.Identity;
    using Refit;

    public interface IIdentityService
    {
        [Post("/Identity/Login")]
        Task<UserOutputModel> Login([Body] UserInputModel loginInput);
    }
}
