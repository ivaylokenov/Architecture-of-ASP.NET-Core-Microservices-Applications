namespace CarRentalSystem.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser
    {
        public Dealer Dealer { get; set; }
    }
}
