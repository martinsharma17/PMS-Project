using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMS.Api.Models.Core
{
    /// <summary>
    /// Watchlist entity for users to track assets they're interested in.
    /// </summary>
    public class Watch
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(450)]
        public string UserId { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Symbol { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string AssetType { get; set; } = string.Empty; // "Stock", "Crypto", "MutualFund", etc.

        public DateTime AddedOn { get; set; } = DateTime.UtcNow;

        // Navigation property
        [ForeignKey("UserId")]
        public virtual User? User { get; set; }
    }
}

