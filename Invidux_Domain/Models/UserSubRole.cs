using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Invidux_Domain.Models
{
    public class UserSubRole
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("AppUser")]
        public string UserId { get; set; }
        [ForeignKey("SubRole")]
        public string SubRoleId { get; set; }
        public virtual SubRole SubRole { get; set; }

    }
}
