namespace Invidux_Domain.Models
{
    public class TokenApproval: BaseToken
    {
        public string? Status { get; set; }
        public string? By { get; set; }
        public DateTime ApprovalDate { get; set; } = DateTime.UtcNow;
    }
}
