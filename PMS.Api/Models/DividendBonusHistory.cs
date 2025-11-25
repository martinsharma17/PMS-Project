using System;
using System.ComponentModel.DataAnnotations;

namespace PMS.Api.Models
{
    public class DividendBonusHistory
    {
        [Key]
        public int Id { get; set; }
        public int InvestmentId { get; set; }
        public Investment? Investment { get; set; }
        public DateTime RecordDate { get; set; }
        public decimal CashDividend { get; set; }
        public decimal BonusRatio { get; set; }  // e.g., 0.5 for 1:0.5
        public decimal TaxDeducted { get; set; }  // 5% TDS
    }
}
