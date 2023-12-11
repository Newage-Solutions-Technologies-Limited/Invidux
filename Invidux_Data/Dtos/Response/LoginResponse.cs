using Invidux_Domain.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invidux_Data.Dtos.Response
{
    public class LoginResponse
    {
        public string UserId { get; set; }
        public RegistrationStatus? Status { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string? Token { get; set; }
        public bool? TwoFactorEnabled { get; set; }
        //public int? Otp {  get; set; }
    }
}
