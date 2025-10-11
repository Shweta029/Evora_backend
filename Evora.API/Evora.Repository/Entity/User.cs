using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Evora.Repository.Entity
{
    public class User
    {
        [Key]
        [Column("Id")]
        public Guid Id { get; set; }

        [Required]
        [Column("Name", TypeName = "varchar(100)")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Column("Email", TypeName = "varchar(150)")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Column("PasswordHash", TypeName = "varchar(255)")]
        public string PasswordHash { get; set; } = string.Empty;

        [Column("Role", TypeName = "varchar(20)")]
        public string Role { get; set; } = "User"; // Admin/User

        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}


