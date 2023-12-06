using System.ComponentModel.DataAnnotations;

namespace Invidux_Data.Dtos.Request
{
    public class LoginDTO
    {
        public string Username { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

}
