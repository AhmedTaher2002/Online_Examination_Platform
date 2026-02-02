using ExaminationSystem.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace ExaminationSystem.Models
{
    public abstract class User : BaseModel
    {
        
        [Required]
        [StringLength(100)]
        public string FullName { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string Username { get; set; } = null!;

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; } = null!;

        [Required]
        public string PasswordHash { get; set; } = null!;
        
        [Required]
        public Role Role { get; set; }
    }
} 