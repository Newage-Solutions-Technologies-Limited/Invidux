using Invidux_Domain.Utilities;
using System.ComponentModel.DataAnnotations;

namespace Invidux_Data.Dtos.Request
{
    public class LoginDTO
    {
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public SourceEnums? Source { get; set; }
    }

}
