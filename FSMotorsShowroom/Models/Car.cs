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
        public string? Name { get; set; }
        public string? Color { get; set; }
        public virtual CarModel? CarModel { get; set; }
        public string? Transmission { get; set; }
        public string? FuelType { get; set; }
        public string? FuelMilage { get; set; }
        public string? Features { get; set; }
        public string? Description { get; set; }
        public string? EngineNo { get; set; }
        public decimal BuyingPrice { get; set; }
        public decimal? SellingPrice { get; set; }  
        public decimal? MaintananceCost { get; set; }
        public decimal? ShowroomCost { get; set; }
        public decimal? SalesTax  { get; set; }
        public string? MakeCompany { get; set; }
        public DateTime MakeYear { get; set; }
        public string? NoOfCylinders { get; set; }
        public string? HoresPower { get; set; }
        public string? TransmissionMode { get; set; }
        public string? TankCapacity { get; set; }
        public int Doors { get; set; }
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
