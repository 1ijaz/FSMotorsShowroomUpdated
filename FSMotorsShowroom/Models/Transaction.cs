using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FSMotorsShowroom.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        public int Amount { get; set; }


        // [ForeignKey("Car")]
        // public int CarId { get; set; }

        // // You can have a direct reference to Car or any other relevant properties
        //// public Car Car { get; set; }

        // //[ForeignKey("Investor")]
        // //public int InvestorId { get; set; }

        // // You can have a direct reference to Investor or any other relevant properties
        //// public Investor Investor { get; set; }

        // public DateTime? TransactionDate { get; set; }
        // public string BuyerName { get; set; }
        // public string BuyerContact { get; set; }
        // public string BuyerAddress { get; set; }
        // public int? TaxRate { get; set; }

        // [Column(TypeName = "decimal(18,2)")]
        // public decimal? TotalAmount { get; set; }

        // [Column(TypeName = "decimal(18,2)")]
        // public decimal Profit { get; set; }


        // // Method to calculate profit and set the Profit property
        // private void CalculateProfit(decimal carPrice, decimal workshopCost, decimal showroomCost, decimal taxRate)
        // {
        //     decimal profit = carPrice + workshopCost + showroomCost + (carPrice * taxRate);
        //     Profit = profit;
        // }
    }
}
