namespace CarRentalSystem.Identity.Services.Identity
{
    using Data.Models;

    public interface ITokenGeneratorService
    {
        string GenerateToken(User user);
    }
}
