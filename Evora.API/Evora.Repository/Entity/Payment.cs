using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Evora.Repository.Entity
{
    [Table("Payments")]
    public class Payment
    {
        [Key]
        [Column("Id")]
        public Guid Id { get; set; }

        [Column("RazorpayOrderId", TypeName = "varchar(100)")]
        public string? RazorpayOrderId { get; set; }

        [Column("RazorpayPaymentId", TypeName = "varchar(100)")]
        public string? RazorpayPaymentId { get; set; }

        [Column("RazorpaySignature", TypeName = "varchar(255)")]
        public string? RazorpaySignature { get; set; }

        [Required]
        [Column("Amount", TypeName = "decimal(10,2)")]
        public decimal Amount { get; set; }

        [Column("Currency", TypeName = "varchar(10)")]
        public string Currency { get; set; } = "INR";

        [Column("Status", TypeName = "varchar(20)")]
        public string Status { get; set; } = "Initiated"; // Initiated / Success / Failed

        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
