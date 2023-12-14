using System.ComponentModel.DataAnnotations;

namespace Invidux_Domain.Models
{
    public class PaymentMethod
    {
        [Key] 
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
