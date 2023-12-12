using System.ComponentModel.DataAnnotations.Schema;

namespace Invidux_Domain.Models
{
    public class UserTwoFactorCover: BaseUser
    {

        [ForeignKey("TwoFactorCover")]
        public int TwoFactorCoverId { get; set; }
        public virtual TwoFactorCover TwoFactorCover { get; set; }
    }
}
