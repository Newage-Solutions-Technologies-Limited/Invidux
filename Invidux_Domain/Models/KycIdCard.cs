using System.ComponentModel.DataAnnotations;

namespace Invidux_Domain.Models
{
    public class KycIdCard
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }
    }
}
