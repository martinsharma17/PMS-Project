using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMS.Api.Models.Investments
{
    /// <summary>
    /// Gold investment data - inherits from Investment base class.
    /// Stored in same table as other investment types with discriminator "Gold".
    /// </summary>
    [Table("Investments")]
    public class GoldData : Investment
    {
        [Column(TypeName = "decimal(5,2)")]
        public decimal? Purity { get; set; } // e.g., 24.00, 22.00, 18.00

        [Column(TypeName = "decimal(18,4)")]
        public decimal? WeightInGrams { get; set; }

        [MaxLength(50)]
        public string? GoldType { get; set; } // e.g., "Physical", "ETF", "Futures"
    }
}

