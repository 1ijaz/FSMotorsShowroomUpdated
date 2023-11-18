using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FSMotorsShowroom.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        [Display(Name = "Transaction Name")]
        public string TransactionName { get; set; }
        public DateTime? Date{ get; set; }
        public int? CarId { get; set; }
        public string CarName { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public decimal? Amount { get; set; }
        public string? Description { get; set; }
        [Display(Name = "Transaction Type")]
        public string? TransactionType { get; set; }
        public enum TransactionTypeList
        {
            In,
            Out
        }
    }
}
