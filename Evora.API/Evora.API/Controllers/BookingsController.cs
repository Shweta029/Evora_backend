using Microsoft.AspNetCore.Mvc;

namespace Evora.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingsController : ControllerBase
    {
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
    }
}
