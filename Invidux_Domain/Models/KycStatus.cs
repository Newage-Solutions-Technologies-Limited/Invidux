using System.ComponentModel.DataAnnotations;

namespace Invidux_Domain.Models
{
    public class KycStatus
    {
        [Key]
        public int Id { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; } 
        public DateTime UpdatedAt { get; set; }
    }
}
