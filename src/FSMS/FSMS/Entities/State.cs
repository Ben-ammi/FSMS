using System.ComponentModel.DataAnnotations.Schema;

namespace FSMS.Entities
{
    [Table("States", Schema = "Measures")]
    public class State
    {
        public int Id { get; set; }
        public Double Volume { get; set; }
        public Double Temperature { get; set; }
        public Double Humidity { get; set; }
        public DateTime TimeStamp { get; set; }
        public Guid TankId { get; set; }
        public Tank? Tank { get; set; }
    }
}
