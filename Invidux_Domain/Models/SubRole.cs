using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Invidux_Domain.Models
{
    /// <summary>
    /// On creation, Id = Guid.NewGuid().ToString()
    /// </summary>
    public class SubRole
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Roles")]
        public string RoleId { get; set; }
        public virtual AppRole Role { get; set; }
        public virtual ICollection<AppUser> Users { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
