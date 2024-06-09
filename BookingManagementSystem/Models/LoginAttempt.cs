// Models/LoginAttempt.cs
namespace BookingManagementSystem.Models
{
    public class LoginAttempt
    {
        public string Username { get; set; }
        public int FailedAttempts { get; set; }
        public DateTime? LockoutEnd { get; set; }
    }
}
