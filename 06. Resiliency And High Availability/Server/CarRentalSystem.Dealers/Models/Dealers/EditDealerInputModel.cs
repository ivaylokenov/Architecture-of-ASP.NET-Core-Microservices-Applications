namespace CarRentalSystem.Dealers.Models.Dealers
{
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants.Dealers;
    using static CarRentalSystem.Data.DataConstants.Common;

    public class EditDealerInputModel
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
