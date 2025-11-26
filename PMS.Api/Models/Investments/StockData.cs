using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMS.Api.Models.Investments
{
    /// <summary>
    /// Stock investment data - inherits from Investment base class.
    /// Stored in same table as other investment types with discriminator "Stock".
    /// </summary>
    [Table("Investments")]
    public class StockData : Investment
    {
        [MaxLength(100)]
        public string? Exchange { get; set; } // e.g., "NEPSE", "NYSE", "NASDAQ"

        [MaxLength(100)]
        public string? Sector { get; set; } // e.g., "Banking", "Technology", "Energy"
    }
}

