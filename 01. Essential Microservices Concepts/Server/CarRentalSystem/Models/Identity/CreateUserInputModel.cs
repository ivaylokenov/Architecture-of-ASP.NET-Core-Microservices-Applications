namespace CarRentalSystem.Models.Identity
{
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants.Common;
    using static Data.DataConstants.Dealer;

    public class CreateUserInputModel : UserInputModel
    {
        [Required]
        [MinLength(MinNameLength)]
        [MaxLength(MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [MinLength(MinPhoneNumberLength)]
        [MaxLength(MaxPhoneNumberLength)]
        [RegularExpression(PhoneNumberRegularExpression)]
        public string PhoneNumber { get; set; }
    }
}
