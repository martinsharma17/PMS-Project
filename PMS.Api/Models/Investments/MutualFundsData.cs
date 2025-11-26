using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMS.Api.Models.Investments
{
    /// <summary>
    /// Mutual fund investment data - inherits from Investment base class.
    /// Stored in same table as other investment types with discriminator "MutualFund".
    /// </summary>
    [Table("Investments")]
    public class MutualFundsData : Investment
    {
        [MaxLength(200)]
        public string? FundName { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal? Nav { get; set; } // Net Asset Value
    }
}

