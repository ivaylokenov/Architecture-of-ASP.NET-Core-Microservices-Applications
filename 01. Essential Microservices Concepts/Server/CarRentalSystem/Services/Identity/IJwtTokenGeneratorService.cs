namespace CarRentalSystem.Services.Identity
{
    using Data.Models;

    public interface IJwtTokenGeneratorService
    {
        string GenerateToken(User user);
    }
}
