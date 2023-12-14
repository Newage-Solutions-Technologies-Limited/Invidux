using Invidux_Domain.Utilities;

namespace Invidux_Data.Dtos.Response
{
    public class UserProfileDto
    {
        public Contact Contact { get; set; }
        public IncomeInfo Income { get; set; }
        public InvestmentLimit InvestmentLimit { get; set; }
        public KYC KYC { get; set; }
        public Security Security { get; set; }
    }

    public class Contact
    {
        public string Email { get; set; }
        public string? Phone { get; set; }
        public Address Address { get; set; }    
        public NextOfKin NextOfKin { get; set; }
    }

    public class IncomeInfo
    {
        public MonthlyIncomeRange? IncomeRange { get; set; }
        public EmploymentStatus? EmploymentStatus { get; set; }
        public string? JobSector { get; set; }
    }

    public class InvestmentLimit
    {
        public decimal? LimitUsed { get; set; }
        public decimal? RemainingAllowance { get; set; }
    }

    public class KYC
    {
        public string Level { get; set; }
        public string IdType { get; set; }
        public string? IdNumber { get; set; }
        public DateTime? ExpiryDate { get; set; } // Nullable if expiry date can be empty
        public bool Verified { get; set; } = false;
        public bool CanExpire { get; set; } = true;
    }

    public class Security
    {
        public bool TwoFactorEnabled { get; set; } = false;
        public string TwoFactorType { get; set; } = TwoFactorTypeStrings.Email;
        public List<String>? TwoFactorCovers { get; set; }
    }

    public class NextOfKin
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Relationship { get; set; }
    }

    public class Address
    {
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public string? CountryName { get; set; }
    }

}
