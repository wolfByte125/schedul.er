using schedul.er.Utils;
using System.ComponentModel.DataAnnotations;

namespace schedul.er.Models
{
    public class EventType
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; } = string.Empty;
    }
}
