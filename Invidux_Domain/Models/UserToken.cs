using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Invidux_Domain.Models
{
    public class UserToken: BaseToken
    {
        [Key]
        public string? Currency { get; set; }
        public decimal Available { get; set; }
        public decimal Earnings { get; set; }
        public string TokenCode { get; set; }
        public string TokenType { get; set; }
        [ForeignKey("Wallet")]
        public string WalletId { get; set; }
        public virtual Wallet Wallet { get; set; }
        public ICollection<BankAccount>? BankAccounts { get; set; }
        public ICollection<StellarAccount>? StellarAccounts { get; set;}
    }
}
