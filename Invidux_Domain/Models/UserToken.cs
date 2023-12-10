using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Invidux_Domain.Models
{
    public class UserToken: BaseToken
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Wallet")]
        public string WalletId { get; set; }
        public virtual Wallet Wallet { get; set; }
    }
}
