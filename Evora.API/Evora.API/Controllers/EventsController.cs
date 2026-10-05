using Microsoft.AspNetCore.Mvc;

namespace Evora.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        [HttpGet("get-all-booked-events")]
        public IActionResult GetBookings()
        {
            var bookedEvents = new List<object> {
                new { Id = 1,CustomerName = "Rahul Sharma",EventName = "Corporate Annual Meetup", Date = "2026-10-05", Amount = 2500 },
                new { Id = 2, CustomerName = "Priya Patel", EventName = "Wedding Ceremony", Date = "2026-10-12", Amount = 1800 },
                new{ Id = 3, CustomerName = "Amit Shah", EventName = "Birthday Celebration", Date = "2026-10-18", Amount = 3200 },
                new{ Id = 4, CustomerName = "Neha Mehta",EventName = "Product Launch", Date = "2026-10-22", Amount = 4500 },
                new{ Id = 5, CustomerName = "Rohan Desai",EventName = "Music Concert", Date = "2026-10-28", Amount = 3800 }
            };

            return Ok(bookedEvents);
        }

        [HttpGet("config")]
        public IActionResult GetConfig()
        {
            return Ok(new
            {
                Environment = Environment.GetEnvironmentVariable("APP_ENVIRONMENT"),
                Version = Environment.GetEnvironmentVariable("APP_VERSION")
            });
        }
    }
}
