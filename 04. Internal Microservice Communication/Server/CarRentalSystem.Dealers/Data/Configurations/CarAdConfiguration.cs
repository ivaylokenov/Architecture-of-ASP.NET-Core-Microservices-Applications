namespace CarRentalSystem.Dealers.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    using static DataConstants.CarAds;
    using static CarRentalSystem.Data.DataConstants.Common;

    internal class CarAdConfiguration : IEntityTypeConfiguration<CarAd>
    {
        public void Configure(EntityTypeBuilder<CarAd> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.Model)
                .IsRequired()
                .HasMaxLength(MaxModelLength);

            builder
                .Property(c => c.ImageUrl)
                .IsRequired()
                .HasMaxLength(MaxUrlLength);

            builder
                .Property(c => c.PricePerDay)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder
                .Property(c => c.IsAvailable)
                .IsRequired();

            builder
                .HasOne(c => c.Manufacturer)
                .WithMany(m => m.CarAds)
                .HasForeignKey(c => c.ManufacturerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(c => c.Category)
                .WithMany(c => c.CarAds)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .OwnsOne(c => c.Options, options =>
                {
                    options.WithOwner();

                    options
                        .Property(op => op.NumberOfSeats)
                        .IsRequired();

                    options
                        .Property(op => op.HasClimateControl)
                        .IsRequired();

                    options
                        .Property(op => op.TransmissionType)
                        .IsRequired();
                });
        }
    }
}
