// UserService.cs

using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookingManagementSystem.Models;
using BookingManagementSystem.Data;

namespace BookingManagementSystem.Services
{
    public class UserService : IUserService
    {
        private readonly BookingContext _context;

        public UserService(BookingContext context)
        {
            _context = context;
        }

        public async Task<User> AuthenticateAsync(string username, string password)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Username == username);

            // Return null if user not found
            if (user == null)
                return null;

            // Check if password is correct
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            // Authentication successful
            return user;
        }

        public async Task<ServiceResult> RegisterAsync(UserRegisterModel model)
        {
            // Check if username is already taken
            if (await _context.Users.AnyAsync(x => x.Username == model.Username))
            {
                return new ServiceResult(false, "Username already exists");
            }

            // Create new user
            var user = new User
            {
                Username = model.Username,
                PasswordHash = CreatePasswordHash(model.Password),
                PasswordSalt = CreatePasswordSalt()
            };

            // Add user to database
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new ServiceResult(true, "User registered successfully");
        }

        // Helper methods for password hashing and verification
        private byte[] CreatePasswordHash(string password)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                return hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i])
                        return false;
                }
            }
            return true;
        }

        private byte[] CreatePasswordSalt()
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                return hmac.Key;
            }
        }
    }
}
