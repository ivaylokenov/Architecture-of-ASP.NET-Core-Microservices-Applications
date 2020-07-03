namespace CarRentalSystem.Dealers.Models.Dealers
{
    using System.Linq;
    using AutoMapper;
    using Data.Models;

    public class DealerDetailsOutputModel : DealerOutputModel
    {
        public int TotalCarAds { get; private set; }

        public void Mapping(Profile mapper)
            => mapper
                .CreateMap<Dealer, DealerDetailsOutputModel>()
                .IncludeBase<Dealer, DealerOutputModel>()
                .ForMember(d => d.TotalCarAds, cfg => cfg
                    .MapFrom(d => d.CarAds.Count()));
    }
}
