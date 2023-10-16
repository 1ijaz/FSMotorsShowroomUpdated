using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FSMotorsShowroom.Models
{
    public class Investment
    {
        [Key]
        public int InvestmentId { get; set; }  
       [Required]
        [Display(Name = "Car Name")]
        public string? CarName { get; set; }
        [Required]
        [Display(Name = "Buying Price")]
        public decimal BuyingPrice { get; set; }
        [Required]
        [Display(Name = "Selling Price")]
        public decimal? SellingPrice { get; set; }
        [Required]
        [Display(Name = "Maintanance Cost")]
        public decimal? MaintananceCost { get; set; }
        [Required]
        [Display(Name = "Showroom Cost")]
        public decimal? ShowroomCost { get; set; }
        [Required]
        [Display(Name = "Sales Tax")]
        public decimal? SalesTax { get; set; }
        [Required]
        [Display(Name = "Sold Date")]
        public DateTime SoldDate { get; set; }
        public string CarStatus { get; set; }
       
        public int CarId { get; set; }
        [ForeignKey("CarId")] // This sets up the foreign key relationship.
        public Car Car { get; set; }
        
        public int InvestorId { get; set; }
        [ForeignKey("InvestorId")]
        public Investor Investor { get; set; }
    }
}
