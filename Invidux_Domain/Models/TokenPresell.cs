namespace Invidux_Domain.Models
{
    public class TokenPresell: BaseToken
    {
        public decimal PledgeRate { get; set; }
        public decimal PledgedToken { get; set; }
        public int NoOfParticipants { get; set; }
        public DateTime? ExpiresAt { get; set; } // Nullable as it can be null
        public DateTime? StartsAt { get; set; } // Nullable as it can be null
        public int? MinimumUnit { get; set; } // Nullable as it can be null
    }
}
