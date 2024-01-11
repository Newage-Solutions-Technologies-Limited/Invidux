using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invidux_Data.Dtos.Response
{
    public class PortfolioTokens
    {
        public Inapp InApp { get; set; }
        public External External { get; set; }
    }


    public class Inapp
    {
        public int TokenCount { get; set; }
        public string[] TokenCodes { get; set; }
        public decimal OwnedVolume { get; set; }
        public decimal CoolingOffVolume { get; set; }
        public string Currency { get; set; }
        public decimal TotalCost { get; set; }
        public decimal CurrentValue { get; set; }
    }

    public class External
    {
        public object[] ExternalStellarIds { get; set; }
        public int TokenCount { get; set; }
        public string[] TokenCodes { get; set; }
        public decimal OwnedVolume { get; set; }
        public string Currency { get; set; }
        public decimal CurrentValue { get; set; }
    }
   

    public class PortfolioToken
    {
        public string TokenCode { get; set; }
        public string[] PropertyImages { get; set; }
        public decimal SupplyVolume { get; set; }
        public decimal OwnedVolume { get; set; }
        public decimal CoolingOffVolume { get; set; }
        public string Currency { get; set; }
        public decimal TotalCost { get; set; }
        public decimal TotalValue { get; set; }
        public string DistributionFrequency { get; set; }
        public TransactionRes[] Transactions { get; set; }
        public AnnualYield AnnualYield { get; set; }
    }

    public class AnnualYield
    {
        public decimal RegularReturns { get; set; }
        public object OperatingYieldEstimate { get; set; }
        public decimal AppreciationEstimate { get; set; }
    }

    public class TransactionRes
    {
        public decimal Units { get; set; }
        public decimal PurchasePrice { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}