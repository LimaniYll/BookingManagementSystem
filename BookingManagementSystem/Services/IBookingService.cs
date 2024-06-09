// Services/IBookingService.cs
using BookingManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingManagementSystem.Services
{
    public interface IBookingService
    {
        Task<IEnumerable<Booking>> GetAllAsync();
        Task<Booking> GetByIdAsync(int id);
        Task<Booking> CreateAsync(Booking booking);
        Task<Booking> UpdateAsync(Booking booking);
        Task<Booking> DeleteAsync(int id);
        Task<IEnumerable<Booking>> SearchAsync(string customerName, string roomNumber);
    }
}
