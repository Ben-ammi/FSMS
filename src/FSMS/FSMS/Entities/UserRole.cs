using System.ComponentModel.DataAnnotations;

namespace FSMS.Entities
{
    public class UserRole
    {
        public int Id { get; set; }

        [MaxLength(20)]
        public string Role { get; set; } = string.Empty;

        public List<User>? Users { get; set; }
    }
}
