using System;
using System.ComponentModel.DataAnnotations;

namespace PMS.Api.Models
{
    public class Investment
    {
        [Key]
        public int Id { get; set; }
        public int PortfolioId { get; set; }
        public Portfolio? Portfolio { get; set; }
        public int InvestmentTypeId { get; set; }
        public InvestmentType? InvestmentType { get; set; }
        public string Name { get; set; } = string.Empty;  // e.g., "NABIL"
        public decimal Quantity { get; set; }
        public decimal PurchasePrice { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal CurrentPrice { get; set; }  // Updated via NEPSE API
        public string? DematAccountNumber { get; set; }  // BOID for stocks
        public string? BrokerName { get; set; }
        public bool IsLocked { get; set; }  // IPO lock-in
        public DateTime? IpoAllotmentDate { get; set; }
        public string Currency { get; set; } = "NPR";
        public string SourceOfFund { get; set; } = "Local Income";  // For NRB reporting
    }
}