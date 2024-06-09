// Services/BookingServiceTests.cs
using BookingManagementSystem.Models;
using BookingManagementSystem.Repositories;
using BookingManagementSystem.Services;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

public class BookingServiceTests
{
    [Fact]
    public async Task GetAllAsync_ShouldReturnAllBookings()
    {
        var mockRepository = new Mock<IBookingRepository>();
        mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(GetTestBookings());
        var service = new BookingService(mockRepository.Object);

        var result = await service.GetAllAsync();

        Assert.Equal(2, result.Count());
    }

    private List<Booking> GetTestBookings()
    {
        return new List<Booking>
        {
            new Booking { Id = 1, CustomerName = "John Doe", BookingDate = DateTime.UtcNow, RoomNumber = "101" },
            new Booking { Id = 2, CustomerName = "Jane Doe", BookingDate = DateTime.UtcNow, RoomNumber = "102" }
        };
    }
}
