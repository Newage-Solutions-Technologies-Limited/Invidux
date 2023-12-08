using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Invidux_Domain.Models
{
    public class UserInfo: BaseUser
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime? Dob { get; set; } // Date of Birth
        public string? Gender { get; set; }
        public string? MaritalStatus { get; set; }
    }
}
