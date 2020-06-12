namespace CarRentalSystem.Dealers.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    using static DataConstants.Dealers;
    using static CarRentalSystem.Data.DataConstants.Common;

    internal class DealerConfiguration : IEntityTypeConfiguration<Dealer>
    {
        public void Configure(EntityTypeBuilder<Dealer> builder)
        {
            builder
                .HasKey(d => d.Id);

            builder
                .Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(MaxNameLength);

            builder
                .Property(d => d.PhoneNumber)
                .IsRequired()
                .HasMaxLength(MaxPhoneNumberLength);

            builder
                .Property(d => d.UserId)
                .IsRequired();

            builder
                .HasMany(d => d.CarAds)
                .WithOne(c => c.Dealer)
                .HasForeignKey(c => c.DealerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
