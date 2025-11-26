using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PMS.Api.Models.Core;

namespace PMS.Api.Models.Investments
{
    /// <summary>
    /// Base abstract class for all investment types using Table-Per-Hierarchy (TPH) pattern.
    /// All investment types share a single table with a discriminator column "InvestmentType".
    /// </summary>
    public abstract class Investment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PortfolioId { get; set; }

        [Required]
        [MaxLength(50)]
        public string InvestmentType { get; set; } = string.Empty; // Discriminator: "Stock", "MutualFund", "Crypto", etc.

        [Required]
        [MaxLength(200)]
        public string SymbolOrName { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,4)")]
        public decimal Quantity { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal PurchasePrice { get; set; } = 0;

        public DateTime PurchaseDate { get; set; } = DateTime.UtcNow;

        [Column(TypeName = "decimal(18,2)")]
        public decimal CurrentPrice { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal CurrentValue { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal ProfitLoss { get; set; } = 0;

        [Column(TypeName = "decimal(5,2)")]
        public decimal ReturnPercentage { get; set; } = 0;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation property
        [ForeignKey("PortfolioId")]
        public virtual Portfolio? Portfolio { get; set; }
    }
}

