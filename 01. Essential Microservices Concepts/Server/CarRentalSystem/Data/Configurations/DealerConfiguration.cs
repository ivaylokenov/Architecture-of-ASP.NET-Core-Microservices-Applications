namespace CarRentalSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    using static DataConstants.Common;
    using static DataConstants.Dealer;

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
                .HasOne(d => d.User)
                .WithOne(u => u.Dealer)
                .HasForeignKey<Dealer>(u => u.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(d => d.CarAds)
                .WithOne(c => c.Dealer)
                .HasForeignKey(c => c.DealerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
