namespace CarRentalSystem.Models.Identity
{
    using System.ComponentModel.DataAnnotations;

    public class ChangePasswordInputModel
    {
        public string UserId { get; set; }

        public string CurrentPassword { get; set; }

        public string NewPassword { get; set; }
    }
}
