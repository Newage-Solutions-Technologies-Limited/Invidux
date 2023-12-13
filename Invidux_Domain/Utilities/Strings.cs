using System.ComponentModel;

namespace Invidux_Domain.Utilities
{
    public class Roles
    {
        public const string Admin = "Admin";
        public const string Dealer_Broker = "Dealer/Broker";
        public const string Investor = "Investor";
        public const string Partner = "Partner";
    }

    public class SubRoles
    {
        public const string SuperAdmin = "Super Admin";
        public const string CustomerSupport = "Customer Support";
        public const string Broker = "Broker";
        public const string Custodian = "Custodian";
        public const string Accrediated = "Accrediated";
        public const string Institutional = "Institutional";
        public const string Retail = "Retail";
        public const string PropertyManager = "Property Manager";
    }

    public class TwoFactorCover
    {
        public static string Login = "Login";
        public static string Transaction = "Transaction";
        public static string Trading = "Trading";
    }

    public class TransactionStatus
    {
        public static string Pending = "Pending";
        public static string Successfull = "Success";
        public static string Failed = "Failed";
    }

    public class TransactionFlow
    {
        public static string Inflow = "Inflow";
        public static string Outflow = "Outflow";
    }
}
