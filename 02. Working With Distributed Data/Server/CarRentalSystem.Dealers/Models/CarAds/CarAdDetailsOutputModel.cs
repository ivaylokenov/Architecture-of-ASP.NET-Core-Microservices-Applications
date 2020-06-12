namespace CarRentalSystem.Dealers.Models.CarAds
{
    using AutoMapper;
    using Data.Models;
    using Dealers;

    public class CarAdDetailsOutputModel : CarAdOutputModel
    {
        public bool HasClimateControl { get; private set; }

        public int NumberOfSeats { get; private set; }

        public string TransmissionType { get; private set; }

        public DealerOutputModel Dealer { get; set; }

        public override void Mapping(Profile mapper)
            => mapper
                .CreateMap<CarAd, CarAdDetailsOutputModel>()
                .IncludeBase<CarAd, CarAdOutputModel>()
                .ForMember(c => c.HasClimateControl, cfg => cfg
                    .MapFrom(c => c.Options.HasClimateControl))
                .ForMember(c => c.NumberOfSeats, cfg => cfg
                    .MapFrom(c => c.Options.NumberOfSeats))
                .ForMember(c => c.TransmissionType, cfg => cfg
                    .MapFrom(c => c.Options.TransmissionType))
                .ForMember(c => c.Dealer, cfg => cfg
                    .MapFrom(c => c.Dealer));
    }
}
