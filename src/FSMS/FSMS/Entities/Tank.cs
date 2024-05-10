using FSMS.Data.Types;
using System.ComponentModel.DataAnnotations.Schema;

namespace FSMS.Entities
{
    [Table("Tanks", Schema = "Fuel")]
    public class Tank
    {
        public Guid Id { get; set; }
        public FuelType Fuel { get; set; }
        public VolumeStatus Status { get; set; }
        public List<State>? TankStates { get; set; }
        public List<SensorType>? Sensors { get; set; }
        public List<Dispenser>? Dispensers { get; set; }
    }
}
