﻿using System.ComponentModel.DataAnnotations;

namespace Invidux_Data.Dtos.Request
{
    public class RegistrationDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public bool AgreeToTerm { get; set; }
    }

}
