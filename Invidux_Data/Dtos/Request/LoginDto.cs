using System.ComponentModel.DataAnnotations;

namespace Invidux_Data.Dtos.Request
{
    public class LoginDTO
    {
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string? Source { get; set; }
    }

}
