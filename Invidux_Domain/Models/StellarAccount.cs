using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Invidux_Domain.Models
{
    public class StellarAccount: BaseUser
    {
        [Required]
        public string DepositStellarId { get; set; }
        [ForeignKey("Wallet")]
        public string WalletId { get; set; }
        public virtual Wallet Wallet { get; set; }
        [ForeignKey("UserToken")]
        public int TokenId { get; set; }
        public UserToken UserToken { get; set; }
    }
}
