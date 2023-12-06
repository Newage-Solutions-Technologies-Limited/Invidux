using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invidux_Domain.Models
{
    public class UserKycInfo: BaseUser
    {
        public int Level { get; set; }
        public string? IdType { get; set; }
        public string? IdNumber { get; set; }
        public DateTime? ExpiryDate { get; set; } // Nullable if expiry date can be empty
    }
}
