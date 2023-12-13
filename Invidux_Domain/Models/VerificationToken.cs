using Invidux_Domain.Utilities;
using System.ComponentModel.DataAnnotations;

namespace Invidux_Domain.Models
{
    public class VerificationToken
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public VerificationType Type { get; set; }
        public int Otp { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime ExpiresOn { get; set; } = DateTime.UtcNow.AddMinutes(10);
    }
}
