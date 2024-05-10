using FSMS.Data.Types;
using System.ComponentModel.DataAnnotations.Schema;

namespace FSMS.Entities
{
    [Table("Nozzles", Schema = "Fuel")]
    public class Nozzle
    {
        public Guid Id { get; set; }
        public FuelType Fuel { get; set; }
    }
}
