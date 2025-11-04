using Evora.Repository;
using Evora.Repository.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace Evora.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingsController : ControllerBase
    {
        private readonly EvoraDbContext _context;

        public BookingsController(EvoraDbContext context)
        {
            _context = context;
        }

        [HttpGet("get-all-bookings")]
        public IActionResult GetBookings()
        {
            var bookings = new List<object>
            {
                new { Id = 1, CustomerName = "John Doe", Date = "2025-11-01", Amount = 2500 },
                new { Id = 2, CustomerName = "Jane Smith", Date = "2025-11-05", Amount = 1800 },
                new { Id = 3, CustomerName = "Michael Lee", Date = "2025-11-10", Amount = 3200 }
            };

            return Ok(bookings);
        }

        [HttpPost("add-booking")]
        public async Task<IActionResult> AddBooking([FromBody] Booking booking)
        {
            if (booking == null)
                return BadRequest("Invalid booking data.");

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Booking added successfully!" });
        }

        [HttpGet("get-all-bookings-1")]
        public async Task<IActionResult> GetBookings1()
        {
            var bookings = await _context.Bookings.ToListAsync();
            return Ok(bookings);
        }
    }
}
