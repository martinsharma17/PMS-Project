using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMS.Api.Models.Liabilities
{
    /// <summary>
    /// EMI schedule entries for loan payments.
    /// Tracks each EMI installment with principal and interest breakdown.
    /// </summary>
    public class LoanEmiSchedule
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int LoanId { get; set; }

        public DateTime EmiDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal PrincipalComponent { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal InterestComponent { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalEmi { get; set; } = 0;

        public bool Paid { get; set; } = false;

        // Navigation property
        [ForeignKey("LoanId")]
        public virtual Loan? Loan { get; set; }
    }
}

