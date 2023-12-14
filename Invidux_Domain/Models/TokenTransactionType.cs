using System.ComponentModel.DataAnnotations;

namespace Invidux_Domain.Models
{
    public class TokenTransactionType
    {
        [Key]
        public int Id { get; set; }
        public string TransactionType { get; set; }
        public DateTime CreatedAt { get; set; } 
        public DateTime UpdatedAt { get; set; }
    }
}
