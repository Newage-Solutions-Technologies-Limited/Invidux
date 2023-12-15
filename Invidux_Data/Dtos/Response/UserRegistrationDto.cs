using Invidux_Domain.Utilities;

namespace Invidux_Data.Dtos.Response
{
    public class UserRegistrationDto
    {
        public string Id { get; set; }
        public string? Role { get; set; }
        public string? SubRole { get; set; }
        public string? Username { get; set; } 
        public string Status { get; set; }
        public string Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        //public int? Otp {  get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? OtpAllowance { get; set; }
        public bool WalletActivated { get; set; } 
        public bool HasTokenHistory { get; set; }
        public bool HoldingToken { get; set; }
    }

}
