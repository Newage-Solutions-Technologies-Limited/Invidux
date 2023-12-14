using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Invidux_Domain.Models
{
    public class SubRole
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Roles")]
        public string RoleId { get; set; }
        public virtual AppRole Role { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
