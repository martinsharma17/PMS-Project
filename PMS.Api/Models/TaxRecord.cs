using System;
using System.ComponentModel.DataAnnotations;

namespace PMS.Api.Models
{
    public class TaxRecord
    {
        [Key]
        public int Id { get; set; }
        public int InvestmentId { get; set; }
        public Investment? Investment { get; set; }
        public string FinancialYear { get; set; } = "2081-82";  // Nepali FY
        public decimal CapitalGains { get; set; }
        public decimal TaxRate { get; set; }  // 5%, 7.5%, 10%
        public decimal TaxPaid { get; set; }
        public DateTime CalculationDate { get; set; }
    }
}
