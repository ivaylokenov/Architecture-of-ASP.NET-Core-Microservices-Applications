namespace CarRentalSystem.Admin.Models.Dealers
{
    using CarRentalSystem.Models;

    public class DealerInputModel : IMapFrom<DealerFormModel>
    {
        public string Name { get; set; }

        public string PhoneNumber { get; set; }
    }
}
