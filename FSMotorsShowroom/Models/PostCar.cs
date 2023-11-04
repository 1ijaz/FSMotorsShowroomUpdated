using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FSMotorsShowroom.Models
{
 
    public class PostCar
    {
        public string RegistrationNumber { get; set; }
        public string? Name { get; set; }
        public string? CarModel { get; set; }
        public decimal? FuelMilageMinimum { get; set; }
        public decimal? FuelMilageMaximum { get; set; }
        public string? EngineNo { get; set; }
        public decimal? TotalPriceMinimum { get; set; }
        public decimal? TotalPriceMaximum { get; set; }
        public string? MakeCompany { get; set; }
        public string MakeYearMinimum { get; set; }
        public string MakeYearMaximum { get; set; }
        public string? TransmissionMode { get; set; }




    }
}
