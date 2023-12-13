using Microsoft.AspNetCore.Identity;

namespace Invidux_Domain.Models
{
    public class Role: IdentityRole
    {
        public ICollection<SubRole> SubRoles { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }
    }
}
