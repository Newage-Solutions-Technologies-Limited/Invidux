namespace Invidux_Domain.Models
{
    public class UserKycInfo: BaseUser
    {
        public string? Level { get; set; }
        public string? IdType { get; set; }
        public string? Status { get; set; }
        public string? IdNumber { get; set; }
        public string? ImageName { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? ExpiryDate { get; set; } // Nullable if expiry date can be empty
        public bool CanExpire { get; set; }
    }
}
