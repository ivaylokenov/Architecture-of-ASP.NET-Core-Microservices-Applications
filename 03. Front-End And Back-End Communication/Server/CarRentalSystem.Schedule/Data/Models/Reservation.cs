namespace CarRentalSystem.Schedule.Data.Models
{
    using System;

    public class Reservation
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int DriverId { get; set; }

        public Driver Driver { get; set; }

        public int RentedCarId { get; set; }

        public RentedCar RentedCar { get; set; }
    }
}
