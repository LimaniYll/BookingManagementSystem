// Controllers/BookingControllerTests.cs
using BookingManagementSystem.Controllers;
using BookingManagementSystem.Models;
using BookingManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

public class BookingControllerTests
{
    [Fact]
    public async Task GetAllBookings_ShouldReturnOkResult_WithListOfBookings()
    {
        var mockService = new Mock<IBookingService>();
        mockService.Setup(service => service.GetAllAsync()).ReturnsAsync(GetTestBookings());
        var controller = new BookingController(mockService.Object);

        var result = await controller.GetAllBookings();
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnValue = Assert.IsType<List<Booking>>(okResult.Value);
        Assert.Equal(2, returnValue.Count);
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
