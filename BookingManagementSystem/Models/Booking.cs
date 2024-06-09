// Models/Booking.cs
namespace BookingManagementSystem.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public DateTime BookingDate { get; set; }
        public string RoomNumber { get; set; }
    }
}
