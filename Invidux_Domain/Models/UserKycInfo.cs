using Invidux_Domain.Utilities;

namespace Invidux_Domain.Models
{
    public class UserKycInfo: BaseUser
    {
        public KYCLevel Level { get; set; }
        public string? IdType { get; set; }
        public string? IdNumber { get; set; }
        public DateTime? ExpiryDate { get; set; } // Nullable if expiry date can be empty
        public bool Verified { get; set; }
        public bool CanExpire { get; set; }
    }
}
