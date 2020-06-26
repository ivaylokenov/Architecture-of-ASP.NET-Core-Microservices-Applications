namespace CarRentalSystem.Infrastructure
{
    using Microsoft.AspNetCore.Authorization;
    using static Constants;

    public class AuthorizeAdministratorAttribute : AuthorizeAttribute
    {
        public AuthorizeAdministratorAttribute() => this.Roles = AdministratorRoleName;
    }
}
