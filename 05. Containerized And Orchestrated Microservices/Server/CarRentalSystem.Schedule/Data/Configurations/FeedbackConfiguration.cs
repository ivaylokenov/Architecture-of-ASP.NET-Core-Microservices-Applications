namespace CarRentalSystem.Schedule.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.Content)
                .IsRequired();

            builder
                .HasOne(f => f.Reservation)
                .WithOne()
                .HasForeignKey<Feedback>(f => f.ReservationId);
        }
    }
}
