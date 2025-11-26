using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace PMS.Api.Models.Core
{
    /// <summary>
    /// User entity extending IdentityUser for authentication.
    /// Includes additional profile fields and navigation properties.
    /// </summary>
    public class User : IdentityUser
    {
        [MaxLength(100)]
        public string? Name { get; set; }

        [MaxLength(20)]
        public string? Phone { get; set; }

        [MaxLength(500)]
        public string? ProfilePhotoUrl { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public virtual ICollection<Portfolio> Portfolios { get; set; } = new List<Portfolio>();
        public virtual ICollection<Watch> Watchlist { get; set; } = new List<Watch>();
    }
}

