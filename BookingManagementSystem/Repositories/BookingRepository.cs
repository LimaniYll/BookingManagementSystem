// Repositories/BookingRepository.cs
using BookingManagementSystem.Data;
using BookingManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingManagementSystem.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly BookingContext _context;

        public BookingRepository(BookingContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Booking>> GetAllAsync()
        {
            return await _context.Bookings.ToListAsync();
        }

        public async Task<Booking> GetByIdAsync(int id)
        {
            return await _context.Bookings.FindAsync(id);
        }

        public async Task<Booking> CreateAsync(Booking booking)
        {
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            return booking;
        }

        public async Task<Booking> UpdateAsync(Booking booking)
        {
            _context.Entry(booking).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return booking;
        }

        public async Task<Booking> DeleteAsync(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
            {
                return null;
            }

            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
            return booking;
        }

        public async Task<IEnumerable<Booking>> SearchAsync(string customerName, string roomNumber)
        {
            return await _context.Bookings
                .Where(b => (customerName == null || b.CustomerName.Contains(customerName)) &&
                            (roomNumber == null || b.RoomNumber.Contains(roomNumber)))
                .ToListAsync();
        }
    }
}

