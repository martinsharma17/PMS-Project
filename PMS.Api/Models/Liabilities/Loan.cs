using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PMS.Api.Models.Core;

namespace PMS.Api.Models.Liabilities
{
    /// <summary>
    /// Loan entity representing a liability in a portfolio.
    /// Tracks loan details, EMI schedule, and payment history.
    /// </summary>
    public class Loan
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PortfolioId { get; set; }

        [Required]
        [MaxLength(100)]
        public string LoanType { get; set; } = string.Empty; // "Home Loan", "Personal Loan", "Car Loan", etc.

        [Column(TypeName = "decimal(18,2)")]
        public decimal LoanAmount { get; set; } = 0;

        [Column(TypeName = "decimal(5,2)")]
        public decimal InterestRate { get; set; } = 0;

        public DateTime StartDate { get; set; } = DateTime.UtcNow;

        public DateTime? EndDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal EmiAmount { get; set; } = 0;

        [MaxLength(200)]
        public string? Lender { get; set; } // Bank or financial institution name

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        [ForeignKey("PortfolioId")]
        public virtual Portfolio? Portfolio { get; set; }

        public virtual ICollection<LoanEmiSchedule> EmiSchedules { get; set; } = new List<LoanEmiSchedule>();
    }
}

