using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FSMotorsShowroom.Models
{
    public enum CarStatus
    {
        Sold,
        Showroom,
        Workshop
    }
    public class Car
    {
        [Key]
        public int CarId { get; set; }
        [Required]
        [DisplayName("Car Name")]
        public string? Name { get; set; }

        public string? Color { get; set; }
        public virtual CarModel? CarModel { get; set; }
        public string? Transmission { get; set; }
        public string? FuelType { get; set; }
        public string? FuelMilage { get; set; }
        public string? Features { get; set; }
        public string? Description { get; set; }
        [Required]
        [DisplayName("Engine #")]
        public string? EngineNo { get; set; }
        [Required]
        [DisplayName("Buying Price")]
        public decimal BuyingPrice { get; set; }
        [Required]
        [DisplayName("Selling Price")]
        public decimal? SellingPrice { get; set; }
        [Required]
        [DisplayName("Maintanance Cost")]
        public decimal? MaintananceCost { get; set; }
        [Required]
        [DisplayName("Showroom Cost")]
        public decimal? ShowroomCost { get; set; }
        [Required]
        [DisplayName("Sales Tax")]
        public decimal? SalesTax  { get; set; }
        [Required]
        [DisplayName("Make Company")]
        public string? MakeCompany { get; set; }
        [DisplayName("Make Year")]
        public DateTime MakeYear { get; set; }
        public string? NoOfCylinders { get; set; }
        public string? HoresPower { get; set; }
        public string? TransmissionMode { get; set; }
        public string? TankCapacity { get; set; }
        public int Doors { get; set; }
        [DisplayName("Passanger Capacity")]
        public int PassangerCapacity { get; set; }

        public string? FrontImage { get; set; }
        [NotMapped]
        [DisplayName("Front Image")]
        public IFormFile FrontImageFile { get; set; }
        [NotMapped]
        [DisplayName("Back Image")]
        public IFormFile BackImageFile { get; set; }
        public string? BackImage { get; set; }
        [NotMapped]
        [DisplayName("Interior Image")]
        public IFormFile InteriorImageFile { get; set; }

        public string? InteriorImage { get; set; }
        [NotMapped]
        [DisplayName("Engine Image")]
        public IFormFile EngineImageFile { get; set; }
        public string? EngineImage { get; set; }
        [NotMapped]
        [DisplayName("Body Image")]
        public IFormFile BodyImageFile { get; set; }
        public string? BodyImage { get; set; }
        public string? CarStatus { get; set; } //sold, showroom, worksop



    }
}
