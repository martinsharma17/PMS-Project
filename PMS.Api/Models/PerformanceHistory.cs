using System;
using System.ComponentModel.DataAnnotations;

namespace PMS.Api.Models
{
    public class PerformanceHistory
    {
        [Key]
        public int Id { get; set; }
        public int InvestmentId { get; set; }
        public Investment? Investment { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
        public decimal Value { get; set; }
    }
}
