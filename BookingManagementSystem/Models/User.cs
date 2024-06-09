// Models/User.cs
namespace BookingManagementSystem.Models
{
    public class User
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } // In a real app, store hashed passwords
        public byte[] PasswordHash { get; internal set; }
        public byte[] PasswordSalt { get; internal set; }
    }
}
