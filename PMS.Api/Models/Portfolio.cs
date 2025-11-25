using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PMS.Api.Models
{
    public class Portfolio
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = "Personal";  // "Personal", "Family", "Institutional"
        public decimal TotalInvestment { get; set; }
        public decimal TotalProfit { get; set; }
        public decimal TotalValue { get; set; }
        public decimal TotalReturnPercentage { get; set; }
        public string UserId { get; set; } = string.Empty;  // FK to ApplicationUser
        public string? AdvisorId { get; set; }  // For advisors
        public ApplicationUser? User { get; set; }
        public ICollection<Investment> Investments { get; set; } = new List<Investment>();
    }
}