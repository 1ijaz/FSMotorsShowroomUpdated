using System.ComponentModel.DataAnnotations;

namespace FSMotorsShowroom.Models
{
    public class CarModel
    {
        [Key]
        public int CarModelId { get; set; }
        [Required]
        [Display(Name = "Model Name")]
        public string? CarModelName { get; set; }

    }
}
