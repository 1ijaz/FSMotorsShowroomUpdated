using System.ComponentModel.DataAnnotations;

namespace FSMotorsShowroom.Models
{
    public class CarModel
    {
        [Key]
        public int CarModelId { get; set; }
        public string? CarModelName { get; set; }

    }
}
