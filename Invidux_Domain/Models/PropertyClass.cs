using System.ComponentModel.DataAnnotations;

namespace Invidux_Domain.Models
{
    public class PropertyClass
    {
        [Key]
        public int Id { get; set; }
        public string Class { get; set; }
        public DateTime CreatedAt { get; set; } 
        public DateTime UpdatedAt { get; set; }
    }
}
