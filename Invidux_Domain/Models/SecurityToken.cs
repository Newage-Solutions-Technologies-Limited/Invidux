﻿using Invidux_Domain.Utilities;
using System.ComponentModel.DataAnnotations;

namespace Invidux_Domain.Models
{
    public class SecurityToken
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string SecurityType { get; set; }
        public int Otp { get; set; }
        public int OtpAttemptCount { get; set; } = 5;
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime ExpiresOn { get; set; } = DateTime.UtcNow.AddMinutes(60);
    }
}
