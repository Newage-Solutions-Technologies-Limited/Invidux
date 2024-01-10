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
        public float OwnedVolume { get; set; }
        public float CoolingOffVolume { get; set; }
        public string Currency { get; set; }
        public float TotalCost { get; set; }
        public float CurrentValue { get; set; }
    }

    public class External
    {
        public object[] ExternalStellarIds { get; set; }
        public int TokenCount { get; set; }
        public string[] TokenCodes { get; set; }
        public float OwnedVolume { get; set; }
        public string Currency { get; set; }
        public float CurrentValue { get; set; }
    }
   

    public class PortfolioToken
    {
        public string TokenCode { get; set; }
        public string[] PropertyImages { get; set; }
        public float SupplyVolume { get; set; }
        public float OwnedVolume { get; set; }
        public float CoolingOffVolume { get; set; }
        public string Currency { get; set; }
        public float TotalCost { get; set; }
        public float TotalValue { get; set; }
        public string DistributionFrequency { get; set; }
        public TransactionRes[] Transactions { get; set; }
        public AnnualYield AnnualYield { get; set; }
    }

    public class AnnualYield
    {
        public float RegularReturns { get; set; }
        public object OperatingYieldEstimate { get; set; }
        public float AppreciationEstimate { get; set; }
    }

    public class TransactionRes
    {
        public float Units { get; set; }
        public int PurchasePrice { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}