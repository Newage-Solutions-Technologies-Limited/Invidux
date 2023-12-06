using Invidux_Domain.Utilities;
using System.ComponentModel.DataAnnotations;

namespace Invidux_Data.Dtos.Request
{
    /// <summary>
    /// This verification can be done with just the otp,
    /// the system can check the validity of by checking through
    /// the VerificationToken Table
    /// </summary>
    public class VerifyOtp
    {
        public string Id { get; set; }

        public VerificationType VerificationType { get; set; } = VerificationType.UserRegistration;

        [Required]
        public int Otp { get; set; } // The OTP to be verified
    }
}
