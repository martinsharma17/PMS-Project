using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PMS.Api.Models.Investments;
using PMS.Api.Models.Liabilities;
using PMS.Api.Models.Savings;

namespace PMS.Api.Models.Core
{
    /// <summary>
    /// Portfolio entity representing a user's investment portfolio.
    /// Contains aggregated financial metrics and relationships to all asset/liability types.
    /// </summary>
    public class Portfolio
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(450)]
        public string UserId { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        public string PortfolioName { get; set; } = string.Empty;

        [MaxLength(10)]
        public string Currency { get; set; } = "NPR";

        [MaxLength(1000)]
        public string? Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalInvested { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalCurrentValue { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalProfitLoss { get; set; } = 0;

        [Column(TypeName = "decimal(5,2)")]
        public decimal TotalReturnPercentage { get; set; } = 0;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        [ForeignKey("UserId")]
        public virtual User? User { get; set; }

        public virtual ICollection<Investment> Investments { get; set; } = new List<Investment>();
        public virtual ICollection<InsurancePolicy> InsurancePolicies { get; set; } = new List<InsurancePolicy>();
        public virtual ICollection<Loan> Loans { get; set; } = new List<Loan>();
        public virtual ICollection<SavingAccount> SavingAccounts { get; set; } = new List<SavingAccount>();
        public virtual ICollection<FixedDeposit> FixedDeposits { get; set; } = new List<FixedDeposit>();
    }
}

