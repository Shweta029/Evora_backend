using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Evora.Repository.Entity
{

    [Table("Bookings")]
    public class Booking
    {
        [Key]
        [Column("Id")]
        public Guid Id { get; set; }

        [Required]
        [ForeignKey("User")]
        [Column("UserId")]
        public int UserId { get; set; }

        public User? User { get; set; }

        [Required]
        [ForeignKey("Event")]
        [Column("EventId")]
        public int EventId { get; set; }

        public Event? Event { get; set; }

        [Required]
        [Column("SeatsBooked")]
        public int SeatsBooked { get; set; }

        [Required]
        [Column("TotalAmount", TypeName = "decimal(10,2)")]
        public decimal TotalAmount { get; set; }

        [Column("Status", TypeName = "varchar(20)")]
        public string Status { get; set; } = "Pending"; // Pending / Confirmed / Cancelled

        [ForeignKey("Payment")]
        [Column("PaymentId")]
        public Guid? PaymentId { get; set; }

        public Payment? Payment { get; set; }

        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
