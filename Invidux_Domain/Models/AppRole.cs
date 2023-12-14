using Microsoft.AspNetCore.Identity;

namespace Invidux_Domain.Models
{
    public class AppRole: IdentityRole
    {
        public ICollection<SubRole> SubRoles { get; set; }
    }
}
