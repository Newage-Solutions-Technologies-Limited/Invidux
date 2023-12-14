using System.ComponentModel.DataAnnotations;

namespace Invidux_Domain.Models
{
    public class TwoFactorType
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public DateTime CreatedAt { get; set; } 
        public DateTime UpdatedAt { get; set; } 
    }
}
