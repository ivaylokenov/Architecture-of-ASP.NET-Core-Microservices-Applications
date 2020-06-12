namespace CarRentalSystem.Dealers.Models.CarAds
{
    using System.ComponentModel.DataAnnotations;
    using Data.Models;

    using static Data.DataConstants.CarAds;
    using static Data.DataConstants.Options;
    using static CarRentalSystem.Data.DataConstants.Common;

    public class CarAdInputModel
    {
        [Required]
        [MinLength(MinNameLength)]
        [MaxLength(MaxNameLength)]
        public string Manufacturer { get; set; }

        [Required]
        [MinLength(MinModelLength)]
        [MaxLength(MaxModelLength)]
        public string Model { get; set; }

        public int Category { get; set; }

        [Required]
        [Url]
        public string ImageUrl { get; set; }

        [Range(0, int.MaxValue)]
        public decimal PricePerDay { get; set; }

        public bool HasClimateControl { get; set; }

        [Range(MinNumberOfSeats, MaxNumberOfSeats)]
        public int NumberOfSeats { get; set; }

        [EnumDataType(typeof(TransmissionType))]
        public TransmissionType TransmissionType { get; set; }
    }
}
