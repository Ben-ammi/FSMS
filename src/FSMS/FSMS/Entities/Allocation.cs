using System.ComponentModel.DataAnnotations.Schema;

namespace FSMS.Entities
{
    [Table("Allocations", Schema = "User")]
    public class Allocation
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public Guid UserId { get; set; }
    }
}
