using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMS.Api.Models.Investments
{
    /// <summary>
    /// Real estate investment data - inherits from Investment base class.
    /// Stored in same table as other investment types with discriminator "RealEstate".
    /// </summary>
    [Table("Investments")]
    public class RealEstateData : Investment
    {
        [MaxLength(500)]
        public string? Location { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Area { get; set; } // in square feet or square meters

        [MaxLength(100)]
        public string? PropertyType { get; set; } // e.g., "Residential", "Commercial", "Land"
    }
}

