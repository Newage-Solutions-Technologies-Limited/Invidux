using Invidux_Domain.Utilities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Invidux_Domain.Models
{
    public class BankAccount
    {
        [Key]
        public int Id { get; set; }
        public BankAccountTypeEnums AccountType { get; set; }
        public string? AccountNumber { get; set; }
        public string? AccountName { get; set; }
        public string? BankName {  get; set; }
        [ForeignKey("UserToken")]
        public int TokenId { get; set; }
        public UserToken UserToken { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }
    }
}
