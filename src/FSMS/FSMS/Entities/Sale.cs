using System.ComponentModel.DataAnnotations.Schema;

namespace FSMS.Entities
{
    [Table("Sales", Schema = "Sales")]
    public class Sale
    {
        public Guid Id { get; set; }
        public Guid NozzleId { get; set; }
        public Guid UnitPriceId { get; set; }
        public Double Volume { get; set; }
        public Double Price { get; set; }
        public Nozzle? Nozzle { get; set; }
        public UnitPrice? UnitPrice { get; set; }
    }
}
