using System.ComponentModel.DataAnnotations;

namespace FSMotorsShowroom.Models
{
    public class WorkShop
    {
        [Key]
        public int WorkShopId { get; set; }
        public string? WorkShopName { get; set; }
        public string? WorkshopLocation { get; set; }

    }
}
