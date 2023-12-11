using Microsoft.AspNetCore.Identity;
using Invidux_Domain.Utilities;

namespace Invidux_Domain.Models
{
    public class AppUser : IdentityUser
    {
        public RegistrationStatus Status { get; set; }
        public int OtpSentCount { get; set; }
        public TwoFactorCover TwoFactorCover { get; set; }
        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public UserInfo? Personal { get; set; }
        //public UserIncomeInfo? Income { get; set; }
        //public UserKycInfo? Kyc { get; set; }
        //public UserNextOfKin? NextOfKin { get; set; }
        //public UserAddress? Address { get; set; }
        //public Wallet? Wallet { get; set; }
    }
}
