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
        public string? InvestorName { get; set; }
        public string? InvestorEmail { get; set; }
        public string? InvestorContact { get; set; }
        public string? InvestorAddress { get; set; }

   
    }
}
