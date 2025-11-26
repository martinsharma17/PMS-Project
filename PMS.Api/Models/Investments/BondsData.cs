using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMS.Api.Models.Investments
{
    /// <summary>
    /// Bonds investment data - inherits from Investment base class.
    /// Stored in same table as other investment types with discriminator "Bond".
    /// </summary>
    [Table("Investments")]
    public class BondsData : Investment
    {
        [MaxLength(200)]
        public string? Issuer { get; set; } // e.g., "Government of Nepal", "Corporate"

        public DateTime? MaturityDate { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal? CouponRate { get; set; } // Annual interest rate percentage
    }
}

