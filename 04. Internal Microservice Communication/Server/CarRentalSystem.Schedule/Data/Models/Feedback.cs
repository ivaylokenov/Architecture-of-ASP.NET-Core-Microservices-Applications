namespace CarRentalSystem.Schedule.Data.Models
{
    public class Feedback
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public int ReservationId { get; set; }

        public Reservation Reservation { get; set; }
    }
}
