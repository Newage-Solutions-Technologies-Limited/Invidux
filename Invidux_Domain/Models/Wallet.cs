using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Invidux_Domain.Models
{
    /// <summary>
    /// On creation, Id = Guid.NewGuid().ToString()
    /// </summary>
    public class Wallet
    {

        [Key]
        public string Id { get; set; }
        public string BVN { get; set; }
        public string DepositStellarId { get; set; }
        public bool Active { get; set; }
        public bool PinSet {  get; set; }
        public int WalletPin {  get; set; }
        [ForeignKey("AppUser")]
        public string UserId { get; set; }
        public virtual AppUser User { get; set; }
    }
}
