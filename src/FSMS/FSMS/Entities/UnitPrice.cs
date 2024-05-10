using FSMS.Data.Types;
using System.ComponentModel.DataAnnotations.Schema;

namespace FSMS.Entities
{
    [Table("UnitPrices", Schema = "Sales")]
    public class UnitPrice
    {
        public Guid Id { get; set; }
        public FuelType Fuel { get; set; }
        public Double Price { get; set; }
        public List<Dates>? Dates { get; set; }
    }
}
