namespace CarRentalSystem.Services.Identity
{
    using System.Threading.Tasks;
    using Data.Models;
    using Models.Identity;

    public interface IIdentityService
    {
        Task<Result<User>> Register(UserInputModel userInput);

        Task<Result<LoginSuccessModel>> Login(UserInputModel userInput);

        Task<Result> ChangePassword(ChangePasswordInputModel changePasswordInput);
    }
}
