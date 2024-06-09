using BookingManagementSystem.Data;
using BookingManagementSystem.Models;
using BookingManagementSystem.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BookingManagementSystem.Tests.Repositories
{
    public class BookingRepositoryTests
    {
        private DbContextOptions<BookingContext> GetDbContextOptions()
        {
            return new DbContextOptionsBuilder<BookingContext>()
                .UseInMemoryDatabase(databaseName: "BookingTestDb")
                .Options;
        }

        [Fact]
        public async Task AddAsync_ShouldAddBooking()
        {
            var options = GetDbContextOptions();
            using var context = new BookingContext(options);
            var repository = new BookingRepository(context);
            var booking = new Booking { Id = 1, CustomerName = "John Doe", BookingDate = DateTime.UtcNow, RoomNumber = "101" };

            await repository.CreateAsync(booking);
            var bookings = await context.Bookings.ToListAsync();

            Assert.Single(bookings);
            Assert.Equal("John Doe", bookings.First().CustomerName);
        }

    }
}