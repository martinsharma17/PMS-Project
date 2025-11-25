using System.ComponentModel.DataAnnotations;

namespace PMS.Api.Models
{
    public class InvestmentType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public string? ComplianceNote { get; set; }  // e.g., for crypto ban
    }
}