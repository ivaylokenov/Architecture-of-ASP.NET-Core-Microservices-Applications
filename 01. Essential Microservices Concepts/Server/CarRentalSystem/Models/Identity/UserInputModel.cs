namespace CarRentalSystem.Models.Identity
{
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants.Common;

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
