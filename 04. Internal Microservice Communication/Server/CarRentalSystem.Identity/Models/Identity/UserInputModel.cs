namespace CarRentalSystem.Identity.Models.Identity
{
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants.Identity;

    public class UserInputModel
    {
        [EmailAddress]
        [Required]
        [MinLength(MinEmailLength)]
        [MaxLength(MaxEmailLength)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
