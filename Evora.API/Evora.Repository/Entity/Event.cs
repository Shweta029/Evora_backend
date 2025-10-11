using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Evora.Repository.Entity
{
    [Table("Events")]
    public class Event
    {
        [Key]
        [Column("Id")]
        public Guid Id { get; set; }

        [Required]
        [Column("Title", TypeName = "varchar(200)")]
        public string Title { get; set; } = string.Empty;

        [Column("Description", TypeName = "text")]
        public string? Description { get; set; }

        [Column("Location", TypeName = "varchar(255)")]
        public string? Location { get; set; }

        [Required]
        [Column("StartDate")]
        public DateTime StartDate { get; set; }

        [Required]
        [Column("EndDate")]
        public DateTime EndDate { get; set; }

        [Required]
        [Column("Price", TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        [Required]
        [Column("TotalSeats")]
        public int TotalSeats { get; set; }

        [Required]
        [Column("AvailableSeats")]
        public int AvailableSeats { get; set; }

        [Column("ImageUrl", TypeName = "text")]
        public string? ImageUrl { get; set; }

        [ForeignKey("CreatedByUser")]
        [Column("CreatedBy")]
        public int CreatedBy { get; set; }

        public User? CreatedByUser { get; set; }

        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}