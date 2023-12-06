using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Invidux_Domain.Models
{
    public class Wallet
    {
        [Key]
        public Guid Id { get; set; }
        public string BVN { get; set; }
        public string DepositStellarId { get; set; }
        public bool Active { get; set; }
        public ICollection<Token> Tokens { get; set; }

        [ForeignKey("AppUser")]
        public string UserId { get; set; }
        public virtual AppUser User { get; set; }
    }
}
