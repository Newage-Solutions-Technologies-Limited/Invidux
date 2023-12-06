using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invidux_Domain.Models
{
    public class BaseToken
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Token")]
        public string TokenId { get; set; }
        public virtual Token? Token { get; set; }
    }
}
