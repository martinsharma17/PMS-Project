using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PMS.Api.Models.Core;

namespace PMS.Api.Models.Savings
{
    /// <summary>
    /// Fixed deposit entity linked to a portfolio.
    /// Tracks FD details, tenure, and maturity information.
    /// </summary>
    public class FixedDeposit
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PortfolioId { get; set; }

        [Required]
        [MaxLength(200)]
        public string BankName { get; set; } = string.Empty;

        [MaxLength(50)]
        public string? AccountNumber { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Principal { get; set; } = 0;

        [Column(TypeName = "decimal(5,2)")]
        public decimal InterestRate { get; set; } = 0;

        public int TenureMonths { get; set; } = 0;

        public DateTime? MaturityDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal MaturityAmount { get; set; } = 0;

        // Navigation property
        [ForeignKey("PortfolioId")]
        public virtual Portfolio? Portfolio { get; set; }
    }
}

