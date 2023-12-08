using Invidux_Domain.Utilities;

namespace Invidux_Data.Dtos.Response
{
    public class UserRegistrationDto
    {
        public string Id { get; set; }
        public RegistrationStatus Status { get; set; }
        public string Email { get; set; }
        public int? Otp {  get; set; }
        public DateTime? RegistrationDate { get; set; }
        public int? OtpAllowance { get; set; }
    }

}
