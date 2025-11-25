using System;
using System.ComponentModel.DataAnnotations;

namespace PMS.Api.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        public int InvestmentId { get; set; }
        public Investment? Investment { get; set; }
        public string Type { get; set; } = "Buy";  // "Buy", "Sell", "Dividend"
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string? Notes { get; set; }
    }
}
