using System.ComponentModel.DataAnnotations;

namespace Invidux_Domain.Models
{
    public class UserInfo: BaseUser
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string? ImageName { get; set; }
        public string? ImageUrl { get; set; } // Profile image

        [DataType(DataType.Date), DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime? Dob { get; set; } // Date of Birth
        public string? Gender { get; set; }
        public string? MaritalStatus { get; set; }
    }
}
