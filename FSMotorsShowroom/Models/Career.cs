using System.ComponentModel.DataAnnotations;

namespace FSMotorsShowroom.Models
{
    public class Career
    {
        [Key]
        public int Id { get; set; }
        public string Position { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Application> Applications { get; set; } = new List<Application>();
    }
}
