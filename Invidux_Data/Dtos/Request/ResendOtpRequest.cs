﻿using System.ComponentModel.DataAnnotations;

namespace Invidux_Data.Dtos.Request
{
    public class ResendOtpRequest
    {
        [Required]
        public string Email { get; set; }
    }

}
