namespace CarRentalSystem.Schedule.Data.Models
{
    using System.Collections.Generic;

    public class Driver
    {
        public int Id { get; set; }

        public string License { get; set; }

        public int YearsOfExperience { get; set; }

        public string UserId { get; set; }

        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
