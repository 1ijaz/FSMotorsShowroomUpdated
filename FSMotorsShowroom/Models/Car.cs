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
        [DisplayName("Registration Number")]
        public string RegistrationNumber { get; set; }
        [DisplayName("Car Name")]
        public string? Name { get; set; }
        [DisplayName("Interior Color")]
        public string? InteriorColor { get; set; }
        [DisplayName("Exterior Color")]
        public string? ExteriorColor { get; set; }
        [Display(Name = "Car Model")]
        public int CarModelId { get; set; }
        [ForeignKey("CarModeilId")]
        public CarModel CarModel { get; set; }
        [DisplayName("Fuel Type")]
        public string? FuelType { get; set; }
        [DisplayName("Fuel Milage")]
        public decimal? FuelMilage { get; set; }
        public string? Features { get; set; }
        public string? Description { get; set; }
        [Required]
        [DisplayName("Engine #")]
        public string? EngineNo { get; set; }
        [Required]
        [DisplayName("Buying Price")]
        public decimal BuyingPrice { get; set; }
        [DisplayName("Selling Price")]
        public decimal? SellingPrice { get; set; }
        [DisplayName("Maintanance Cost")]
        public decimal? MaintananceCost { get; set; }
        [DisplayName("Showroom Cost")]
        public decimal? ShowroomCost { get; set; }
        [DisplayName("Sales Tax")]
        public decimal? SalesTax  { get; set; }
        [DisplayName("TotalPrice")]
        public decimal? TotalPrice { get; set; }
        [Required]
        [DisplayName("Make Company")]
        public string? MakeCompany { get; set; }
        [DisplayName("Make Year")]
        public DateTime MakeYear { get; set; }
        [DisplayName("No of Cylinders")]
        public string? NoOfCylinders { get; set; }
        [DisplayName("Horse Power")]
        public string? HorsePower { get; set; }
        public enum TransmissionType
        {
            Automatic,
            Manual
        }
        [DisplayName("Transmission Mode")]
        public string? TransmissionMode { get; set; }
        [DisplayName("Tank Capacity")]
        public string? TankCapacity { get; set; }
        public int Doors { get; set; }
        [DisplayName("Passanger Capacity")]
        public int PassengerCapacity { get; set; }

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
        public enum CarStatusEnum
        {
            Workshop,
            Showroom,
            Sold
        }
        public string? CarStatus { get; set; }
        public string? CarInvestor { get; set; } 



    }
}
