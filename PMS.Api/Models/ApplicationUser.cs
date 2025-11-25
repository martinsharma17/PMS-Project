using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace PMS.Api.Models
{
    public class ApplicationUser : IdentityUser
    {
        // NRN Card Number (for Non-Resident Nepali)
        public string? NrnCardNumber { get; set; }
        public string CitizenshipStatus { get; set; } = "Resident"; // "Resident", "NRN", "Foreign"
        public string? TaxIdPan { get; set; } // PAN number for tax reports
        public bool RepatriationEligible { get; set; } = false; // Can take money out?

        // One user → many portfolios
        public ICollection<Portfolio> Portfolios { get; set; } = new List<Portfolio>();
    }
}