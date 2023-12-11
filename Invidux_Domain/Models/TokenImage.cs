using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invidux_Domain.Models
{
    public class TokenImage: BaseToken
    {
        public string PublicId { get; set; }
        public string ImageUrl { get; set; }
        public bool IsPrimary { get; set; }
    }
}
