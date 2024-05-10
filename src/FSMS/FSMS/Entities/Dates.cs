using System.ComponentModel.DataAnnotations.Schema;

namespace FSMS.Entities
{
    [Table("Dates", Schema = "Sales")]
    public class Dates
    {
        public int Id { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public Guid UnitPriceId { get; set; }
        public UnitPrice? UnitPrice { get; set; }
    }
}
