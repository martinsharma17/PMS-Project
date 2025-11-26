using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PMS.Api.Models.Core;

namespace PMS.Api.Models.Savings
{
    /// <summary>
    /// Savings account entity linked to a portfolio.
    /// Tracks bank account details and balance information.
    /// </summary>
    public class SavingAccount
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PortfolioId { get; set; }

        [Required]
        [MaxLength(200)]
        public string BankName { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string AccountNumber { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Balance { get; set; } = 0;

        [Column(TypeName = "decimal(5,2)")]
        public decimal InterestRate { get; set; } = 0;

        public DateTime DateOpened { get; set; } = DateTime.UtcNow;

        // Navigation property
        [ForeignKey("PortfolioId")]
        public virtual Portfolio? Portfolio { get; set; }
    }
}

