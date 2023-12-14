using System.ComponentModel.DataAnnotations.Schema;

namespace Invidux_Domain.Models
{
    public class SubRole
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Roles")]
        public string RoleId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
