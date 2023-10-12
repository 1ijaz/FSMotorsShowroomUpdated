using System.ComponentModel.DataAnnotations;

namespace FSMotorsShowroom.Models
{
    public class Showroom
    {
        [Key]
        public int ShowroomId { get; set; }
        [Required]
        [Display(Name = "Showroom Name")]
        public string? ShowroomName { get; set; }
        [Required]
        [Display(Name = "Showroom Address")]
        public string? ShowroomAddress { get; set; }
    }
}
