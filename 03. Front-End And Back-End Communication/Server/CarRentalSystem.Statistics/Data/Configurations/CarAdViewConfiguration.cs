namespace CarRentalSystem.Statistics.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class CarAdViewConfiguration : IEntityTypeConfiguration<CarAdView>
    {
        public void Configure(EntityTypeBuilder<CarAdView> builder)
        {
            builder
                .HasKey(v => v.Id);

            builder
                .HasIndex(v => v.CarAdId);

            builder
                .Property(v => v.UserId)
                .IsRequired();
        }
    }
}
