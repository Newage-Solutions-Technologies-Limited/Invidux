using System.ComponentModel;

namespace Invidux_Domain.Utilities
{
    public class KycLevelStrings
    {
        public const string Level1 = "Level1";
        public const string Level2 = "Level2";
        public const string Level3 = "Level2";
    }

    public class KycStatusStrings
    {
        public const string Pending = "Pending";
        public const string Verified = "Verified";
        public const string Restricted = "Restricted";
    }

    public class StatusStrings
    {
        public const string Pending = "Pending";
        public const string Verified = "Verified";
        public const string Restricted = "Restricted";
    }
    public class RoleStrings
    {
        public const string Admin = "Admin";
        public const string Dealer_Broker = "Dealer/Broker";
        public const string Investor = "Investor";
        public const string Partner = "Partner";
    }

    public class SecurityTypeStrings
    {
        public const string UserRegistration = "User Registration";
        public const string TwoFactorActivation = "Two Factor Activation";
        public const string TwoFactorVerification = "Two Factor Verification";
        public const string BvnVerification = "BVN Verification";
    }

    public class SubRolesStrings
    {
        public const string SuperAdmin = "Super Admin";
        public const string CustomerSupport = "Customer Support";
        public const string Broker = "Broker";
        public const string Dealer = "Dealer";
        public const string Custodian = "Custodian";
        public const string Accrediated = "Accrediated";
        public const string Institutional = "Institutional";
        public const string Retail = "Retail";
        public const string PropertyManager = "Property Manager";
    }

    public class TwoFactorCoverStrings
    {
        public const string Login = "Login";
        public const string Transaction = "Transaction";
        public const string Trading = "Trading";
    }

    public class TwoFactorTypeStrings
    {
        public const string Email = "Email";
        public const string GoogleAuth = "Google Auth";
    }

    public class TransactionStatusStrings
    {
        public const string Pending = "Pending";
        public const string Successfull = "Success";
        public const string Failed = "Failed";
    }

    public class TransactionFlowStrings
    {
        public const string Inflow = "Inflow";
        public const string Outflow = "Outflow";
    }
}
