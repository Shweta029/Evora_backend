using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Evora.Domain.Entity
{

    [Table("bookings", Schema = "Evora")]
    public class Booking
    {
        public int Id { get; set; }

        [JsonPropertyName("customer_name")]
        public string CustomerName { get; set; } = string.Empty;

        public string EventName { get; set; } = string.Empty;

        public DateTime BookingDate { get; set; }

        public decimal Amount { get; set; }
    }
}
