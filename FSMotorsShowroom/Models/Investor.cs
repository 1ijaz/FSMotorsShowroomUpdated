using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FSMotorsShowroom.Models
{
    public class Investor
    {
        [Key]
        public int InvestorId { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string? InvestorName { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string? InvestorEmail { get; set; }
        [Required]
        [Display(Name = "Conatct Number")]
        public string? InvestorContact { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string? InvestorAddress { get; set; }

        [Display(Name = "Unallocated Invest Amount")]
        public decimal? InvestUnallocatedAmount { get; set; }
      
        [Display(Name = "Total Invest Amount")]
        public decimal? TotalInvestAmount { get; set; } 

        [Display(Name = "Allocated Invest Amount")]
        public decimal? InvestAllocatedAmount { get; set; }
      
        [Display(Name = "Profit")]
        public decimal? Profit { get; set; }
        public string? Status { get; set; }
        public enum StatusList
        {
            Active,
            DeActive
        }
    }
}
