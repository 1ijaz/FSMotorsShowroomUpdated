using System.ComponentModel.DataAnnotations;

namespace FSMotorsShowroom.Models
{
    public class WorkShop
    {
        [Key]
        public int WorkShopId { get; set; }
        [Required]
        [Display(Name = "WorkShop Name")]
        public string? WorkShopName { get; set; }
        [Required]
        [Display(Name = "Workshop Location")]
        public string? WorkshopLocation { get; set; }

    }
}
