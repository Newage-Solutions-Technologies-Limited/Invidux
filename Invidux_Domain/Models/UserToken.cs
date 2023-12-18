using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Invidux_Domain.Models
{
    public class UserToken
    {
        [Key]
        public int Id { get; set; }
        public string? Currency { get; set; }
        public decimal Available { get; set; }
        public decimal Earnings { get; set; }
        [ForeignKey("Wallet")]
        public string WalletId { get; set; }
        public virtual Wallet Wallet { get; set; }
        public ICollection<BankAccount> BankAccounts { get; set; }
    }
}
