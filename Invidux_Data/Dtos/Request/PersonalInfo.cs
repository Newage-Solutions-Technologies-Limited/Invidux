using Invidux_Domain.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invidux_Data.Dtos.Request
{
    public class PersonalInfoDto
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string? ImagePublicId { get; set; } // Profile image
        public string? ImageUrl { get; set; } // Profile image

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
        public string UserId { get; set; }
        public KYCLevel? Level { get; set; }
        public KYCType? IdType { get; set; }
        public string? IdNumber { get; set; }
        public DateTime? ExpiryDate { get; set; } // Nullable if expiry date can be empty
        public bool Verified { get; set; }
        public bool CanExpire { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
