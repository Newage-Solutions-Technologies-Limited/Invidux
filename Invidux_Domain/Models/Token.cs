using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invidux_Domain.Models
{
    public class Token
    {
        [Key]
        public Guid Id { get; set; }
        public string? Status { get; set; } // e.g., Pre-selling, Selling, Fully Sold, Exited
        public string? TokenCode { get; set; }
        public string? TokenIssuer { get; set; }
        public bool TokenDeployed { get; set; }
        public List<string>? Image { get; set; }
        public string? Location { get; set; }
        public string? Estate { get; set; }
        public string? Area { get; set; }
        public string? City { get; set; }
        public string? Lga { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public decimal Volume { get; set; }
        public decimal Available { get; set; }
        public decimal IssuePrice { get; set; }
        public decimal CurrentPrice { get; set; }
        public decimal MarketCap { get; set; }
        public string? DistributionFrequency { get; set; }
        public TokenAnnualYield? AnnualYield { get; set; }
        public TokenPresell? Presell { get; set; }
        public TokenApproval? Approval { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }

}
