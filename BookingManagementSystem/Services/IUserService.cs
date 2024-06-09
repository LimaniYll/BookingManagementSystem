// IUserService.cs

using System.Threading.Tasks;
using BookingManagementSystem.Models;

namespace BookingManagementSystem.Services
{
    public interface IUserService
    {
        Task<User> AuthenticateAsync(string username, string password);
        Task<ServiceResult> RegisterAsync(UserRegisterModel model);
    }
}
