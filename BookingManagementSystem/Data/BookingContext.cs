using Microsoft.EntityFrameworkCore;
using BookingManagementSystem.Models;

namespace BookingManagementSystem.Data
{
        public class BookingContext : DbContext
        {
            public BookingContext(DbContextOptions<BookingContext> options) : base(options)
            {
            }

            public DbSet<Booking> Bookings { get; set; }
            public DbSet<User> Users { get; set; } // Add this DbSet for User entity

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
            }
        }
    }
