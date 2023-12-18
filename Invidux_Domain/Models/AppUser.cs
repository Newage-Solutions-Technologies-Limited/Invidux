using Microsoft.AspNetCore.Identity;
using Invidux_Domain.Utilities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Invidux_Domain.Models
{
    public class AppUser : IdentityUser
    {
        public string RegistrationStatus  { get; set; }
        public int OtpSentCount { get; set; }
        public string TwoFactorType { get; set; }
        [ForeignKey("SubRole")]
        public string? SubRoleId { get; set; } // Cascade delete removed
        public virtual SubRole SubRole { get; set; } // Cascade delete removed
        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public virtual UserInfo? Personal { get; set; }
        public virtual UserIncomeInfo? Income { get; set; }
        public virtual UserKycInfo? Kyc { get; set; }
        public virtual UserNextOfKin? NextOfKin { get; set; }
        public virtual UserAddress? Address { get; set; }
        public virtual Wallet? Wallet { get; set; }
        public virtual ICollection<UserTwoFactorCover>? TwoFactorCovers { get; set; }
    }
}
