using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invidux_Domain.Models
{
    public class TokenAnnualYield: BaseToken
    {
        public decimal RegularReturns { get; set; }
        public decimal? OperatingYieldEstimate { get; set; } // Nullable as it can be null
        public decimal AppreciationEstimate { get; set; }
    }
}
