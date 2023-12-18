using System.ComponentModel.DataAnnotations;

namespace Invidux_Data.Dtos.Request
{
    public class RegistrationDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public bool AgreeToTerm { get; set; }

        public string? Source { get; set; }
    }

}
