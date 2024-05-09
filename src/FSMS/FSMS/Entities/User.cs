using System.ComponentModel.DataAnnotations;

namespace FSMS.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        [MaxLength(20)]
        public string Username { get; set; } = string.Empty;

        [MaxLength(20)]
        public string Password { get; set; } = string.Empty;

        [MaxLength(50)]
        public string? Email { get; set; } = string.Empty;

        [MaxLength(20)]
        public string FirstName { get; set; } = string.Empty;

        [MaxLength(20)]
        public string LastName { get; set; } = string.Empty;

        [MaxLength(10)]
        public string Phone { get; set; } = string.Empty;

        [MaxLength(30)]
        public string? Address { get; set; } = string.Empty;

        [MaxLength(30)]
        public string? City { get; set; } = string.Empty;

        public bool IsActive { get; set; }

        // Safe Delete Implementation
        public bool IsDeleted { get; set; }

        // Auditing Fields
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Foreign Key and Navigation Property
        public int RoleId { get; set; }
        public UserRole? Role { get; set; }
    }
}
