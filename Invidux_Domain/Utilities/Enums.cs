using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invidux_Domain.Utilities
{
    public enum RegistrationStatus
    {
        [Description("Pending")]
        Pending,
        [Description("Active")]
        Active,
        [Description("Restricted")]
        Restricted
    }

    public enum VerificationType
    {
        [Description("User Registration")]
        UserRegistration,
        [Description("Two Factor")]
        TwoFactorVerification
    }
}
