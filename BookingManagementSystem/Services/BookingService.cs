// Services/BookingService.cs
using BookingManagementSystem.Models;
using BookingManagementSystem.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingManagementSystem.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public async Task<IEnumerable<Booking>> GetAllAsync()
        {
            return await _bookingRepository.GetAllAsync();
        }

        public async Task<Booking> GetByIdAsync(int id)
        {
            return await _bookingRepository.GetByIdAsync(id);
        }

        public async Task<Booking> CreateAsync(Booking booking)
        {
            return await _bookingRepository.CreateAsync(booking);
        }

        public async Task<Booking> UpdateAsync(Booking booking)
        {
            return await _bookingRepository.UpdateAsync(booking);
        }

        public async Task<Booking> DeleteAsync(int id)
        {
            return await _bookingRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Booking>> SearchAsync(string customerName, string roomNumber)
        {
            return await _bookingRepository.SearchAsync(customerName, roomNumber);
        }
    }
}
