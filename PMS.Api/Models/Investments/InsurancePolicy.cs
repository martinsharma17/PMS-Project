using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PMS.Api.Models.Core;

namespace PMS.Api.Models.Investments
{
    /// <summary>
    /// Insurance policy entity linked to a portfolio.
    /// Tracks policy details, premiums, and maturity information.
    /// </summary>
    public class InsurancePolicy
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PortfolioId { get; set; }

        [Required]
        [MaxLength(100)]
        public string PolicyNumber { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        public string CompanyName { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        public decimal PremiumValueAmount { get; set; } = 0; // Sum assured / Coverage amount

        [Column(TypeName = "decimal(18,2)")]
        public decimal PremiumAmount { get; set; } = 0; // Monthly/Annual premium payment

        [MaxLength(50)]
        public string PremiumFrequency { get; set; } = "Monthly"; // "Monthly", "Quarterly", "Annual"

        [MaxLength(200)]
        public string? NomineeName { get; set; }

        public DateTime? MaturityDate { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        [ForeignKey("PortfolioId")]
        public virtual Portfolio? Portfolio { get; set; }

        public virtual ICollection<InsurancePayment> Payments { get; set; } = new List<InsurancePayment>();
    }
}

