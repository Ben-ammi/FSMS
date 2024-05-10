using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FSMS.Entities
{
    [Table("UserRoles", Schema = "User")]
    public class UserRole
    {
        public int Id { get; set; }

        [MaxLength(20)]
        public string Role { get; set; } = string.Empty;

        public List<User>? Users { get; set; }
    }
}
