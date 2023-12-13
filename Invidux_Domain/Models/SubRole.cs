using System.ComponentModel.DataAnnotations.Schema;

namespace Invidux_Domain.Models
{
    public class SubRole
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Role")]
        public string RoleId { get; set; }
        public virtual Role Role { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }

    }
}
