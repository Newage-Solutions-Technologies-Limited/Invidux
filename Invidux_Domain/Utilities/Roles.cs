using System.ComponentModel;

namespace Invidux_Domain.Utilities
{
    public class Roles
    {
        [Description("SuperAdmin")]
        public const string SuperAdmin = "SuperAdmin";
        [Description("Admin")]
        public const string Admin = "Admin";
        [Description("Issuer")]
        public const string Issuer = "Issuer";
        [Description("Investor")]
        public const string Investor = "Investor";
    }
}
