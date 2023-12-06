namespace Invidux_Domain.Models
{
    public class UserIncomeInfo: BaseUser
    {
        public int MonthlyIncomeRangeID { get; set; }
        public int EmploymentStatusId { get; set; }
        public string? JobSector { get; set; }
    }
}
