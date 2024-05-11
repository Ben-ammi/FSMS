using FSMS.Data.Types;
using System.ComponentModel.DataAnnotations.Schema;
namespace FSMS.Entities
{
    [Table("Sensors", Schema = "Measures")]
    public class Sensor
    {
        public Guid Id { get; set; }
        public SensorType Type { get; set; }
        public Guid TankId { get; set; }
        public Tank? Tank { get; set; }
    }
}
