// Controllers/AuthController.cs
using BookingManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookingManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private static List<User> users = new List<User>();
        private static List<LoginAttempt> loginAttempts = new List<LoginAttempt>();

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("register")]
        public IActionResult Register(User user)
        {
            user.UserId = users.Count + 1;
            users.Add(user);
            return Ok();
        }

        [HttpPost("login")]
        public IActionResult Login(User user)
        {
            var attempt = loginAttempts.FirstOrDefault(a => a.Username == user.Username);
            if (attempt != null && attempt.LockoutEnd > DateTime.UtcNow)
            {
                return BadRequest("Account is locked. Try again later.");
            }

            var authenticatedUser = users.FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);
            if (authenticatedUser == null)
            {
                if (attempt == null)
                {
                    attempt = new LoginAttempt { Username = user.Username, FailedAttempts = 0, LockoutEnd = null };
                    loginAttempts.Add(attempt);
                }

                attempt.FailedAttempts++;

                if (attempt.FailedAttempts >= 5)
                {
                    attempt.LockoutEnd = DateTime.UtcNow.AddMinutes(15);
                    return BadRequest("Account is locked. Try again later.");
                }

                return Unauthorized();
            }

            attempt.FailedAttempts = 0;
            attempt.LockoutEnd = null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, user.Username) }),
                Expires = DateTime.UtcNow.AddHours(1), // Token expiry set to 1 hour
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new
            {
                Token = tokenString,
                UserId = authenticatedUser.UserId,
                Username = authenticatedUser.Username,
                Email = authenticatedUser.Email
            });
        }
    }
}