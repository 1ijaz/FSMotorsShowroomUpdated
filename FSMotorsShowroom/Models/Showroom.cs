using System.ComponentModel.DataAnnotations;

namespace FSMotorsShowroom.Models
{
    public class Showroom
    {
        [Key]
        public int ShowroomId { get; set; }
        public string? ShowroomName { get; set; }
        public string? ShowroomAddress { get; set; }
    }
}
