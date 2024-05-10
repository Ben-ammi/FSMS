using FSMS.Data.Types;
using System.ComponentModel.DataAnnotations.Schema;

namespace FSMS.Entities
{
    [Table("Dispensers", Schema = "Fuel")]
    public class Dispenser
    {
        public Guid Id { get; set; }
        public List<Nozzle>? Nozzles { get; set; }
        public List<Sale>? Sales { get; set; }
        public List<Tank>? Tanks { get; set; }
    }
}
