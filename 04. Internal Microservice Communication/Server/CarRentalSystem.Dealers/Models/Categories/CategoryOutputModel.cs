namespace CarRentalSystem.Dealers.Models.Categories
{
    using System.Linq;
    using AutoMapper;
    using CarRentalSystem.Models;
    using Data.Models;

    public class CategoryOutputModel : IMapFrom<Category>
    {
        public int Id { get; private set; }

        public string Name { get; private set; } = default!;

        public string Description { get; private set; } = default!;

        public int TotalCarAds { get; set; }

        public void Mapping(Profile profile)
            => profile
                .CreateMap<Category, CategoryOutputModel>()
                .ForMember(c => c.TotalCarAds, cfg => cfg
                    .MapFrom(c => c.CarAds.Count()));
    }
}

