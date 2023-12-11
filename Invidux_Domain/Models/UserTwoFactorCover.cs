using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invidux_Domain.Models
{
    public class UserTwoFactorCover
    {
        [ForeignKey("TwoFactorCover")]
        public int Id { get; set; }

        [ForeignKey("AppUser")]
        public string UserId { get; set; }
    }
}
