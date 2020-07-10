namespace CarRentalSystem.Schedule.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .HasOne(r => r.Driver)
                .WithMany(d => d.Reservations)
                .HasForeignKey(r => r.DriverId);

            builder
                .HasOne(r => r.RentedCar)
                .WithMany(rc => rc.Reservations)
                .HasForeignKey(r => r.RentedCarId);
        }
    }
}
