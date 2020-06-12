namespace CarRentalSystem.Models.CarAds
{
    using System.ComponentModel.DataAnnotations;
    using Data.Models;

    using static Data.DataConstants.Common;
    using static Data.DataConstants.CarAd;
    using static Data.DataConstants.Options;

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
