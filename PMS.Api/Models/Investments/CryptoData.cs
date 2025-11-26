using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMS.Api.Models.Investments
{
    /// <summary>
    /// Cryptocurrency investment data - inherits from Investment base class.
    /// Stored in same table as other investment types with discriminator "Crypto".
    /// </summary>
    [Table("Investments")]
    public class CryptoData : Investment
    {
        [MaxLength(100)]
        public string? Blockchain { get; set; } // e.g., "Ethereum", "Bitcoin", "Polygon"

        [MaxLength(50)]
        public string? TokenType { get; set; } // e.g., "ERC-20", "Native"
    }
}

