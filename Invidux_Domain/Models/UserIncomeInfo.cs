using Invidux_Domain.Utilities;

namespace Invidux_Domain.Models
{
    public class UserIncomeInfo: BaseUser
    {
        public MonthlyIncomeRange IncomeRange { get; set; }
        public EmploymentStatus EmploymentStatus { get; set; }
        public string? JobSector { get; set; }
        public decimal? InvestmentLimitUsed { get; set; }
        public decimal? RemainingAllowance { get; set; }
    }
}
