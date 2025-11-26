using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMS.Api.Models.Investments
{
    /// <summary>
    /// Insurance payment records for tracking premium payments.
    /// </summary>
    public class InsurancePayment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PolicyId { get; set; }

        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; } = 0;

        [MaxLength(50)]
        public string Method { get; set; } = "Bank Transfer"; // "Bank Transfer", "Cash", "Credit Card", etc.

        // Navigation property
        [ForeignKey("PolicyId")]
        public virtual InsurancePolicy? Policy { get; set; }
    }
}

