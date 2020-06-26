namespace CarRentalSystem.Schedule.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class RentedCarConfiguration : IEntityTypeConfiguration<RentedCar>
    {
        public void Configure(EntityTypeBuilder<RentedCar> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.Information)
                .IsRequired();
        }
    }
}
