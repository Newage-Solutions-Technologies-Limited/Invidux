using Invidux_Domain.Utilities;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Invidux_Data.Dtos.Request
{
    public class PersonalInfoDto
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public IFormFile? file { get; set; }
        [DataType(DataType.Date), DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime? Dob { get; set; } // Date of Birth
        public string? Gender { get; set; }
        public string? MaritalStatus { get; set; }
    }

    public class NextOfKinDto
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Relationship { get; set; }
    }

    public class KYCRequest
    {
        public int IdTypeId { get; set; }
        public string IdNumber { get; set; }
        public IFormFile file { get; set; }
        public DateTime ExpiryDate { get; set; } // Nullable if expiry date can be empty
    }

    public class SecurityDto
    {
        public string UserId { get; set; }
        public bool TwofactorEnabled { get; set; }
        public string TwoFactorType { get; set; }
        public List<string>? TwofactorCovers { get; set; } 
    }
}
