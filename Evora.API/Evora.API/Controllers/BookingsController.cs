using Evora.Interface.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Evora.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingsController(IBookingService bookingService)
        {
            _bookingService = bookingService;
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

        [HttpGet("get-all-booked-events")]
        public async Task<IActionResult> GetAllBookedEvents()
        {
            var bookings = await _bookingService.GetAllBookingsAsync();

            return Ok(bookings);
        }

        [HttpGet("environment")]
        public IActionResult GetEnvironment()
        {
            return Ok(new
            {
                Environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"),
                DotnetEnvironment = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT")
            });
        }
        //[HttpPost("add-booking")]
        //public async Task<IActionResult> AddBooking([FromBody] Booking booking)
        //{
        //    if (booking == null)
        //        return BadRequest("Invalid booking data.");

        //    _context.Bookings.Add(booking);
        //    await _context.SaveChangesAsync();

        //    return Ok(new { message = "Booking added successfully!" });
        //}

        //[HttpGet("get-all-bookings-1")]
        //public async Task<IActionResult> GetBookings1()
        //{
        //    var bookings = await _context.Bookings.ToListAsync();
        //    return Ok(bookings);
        //}
    }
}
