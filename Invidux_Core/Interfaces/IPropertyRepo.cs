using Invidux_Domain.Models;

namespace Invidux_Core.Interfaces
{
    public interface IPropertyRepo
    {
        Task<IEnumerable<int>> GetTokensAsync();
        Task<IEnumerable<int>> GetApprovedTokensAsync();
        Task<int> GetTokenAsync(string id);
        Task<int> GetTokensByCountry(int countryId);
       // Task InitiateTokenIssuanceAsync(TokenDetails tokenDetails);
        Task<bool> CheckTokenHoldingAsync(string tokenCode);
        Task<IEnumerable<Token>> GetHeldTokensAsync();
        Task<IEnumerable<Token>> GetHeldTokenDetailsAsync();
       // Task PurchaseTokenAsync(TokenPurchaseDetails purchaseDetails);
        Task CancelTokenPurchaseAsync(string transactionRef);
       // Task PayOnPledgeAsync(PledgePaymentDetails paymentDetails);
     //   Task TransferTokenAsync(TokenTransferDetails transferDetails);
        Task<IEnumerable<Order>> GetTokenTradeOrdersAsync();
      //  Task CreateTradeOrderAsync(TradeOrderDetails orderDetails);
        Task CancelTradeOrderAsync(string orderId);
     //   Task<IEnumerable<TradeHistory>> GetTradeHistoryAsync();
        Task DisburseInvestmentProceedsAsync(string tokenCode);
    //    Task SubmitRegularReportsAsync(ReportDetails reportDetails);
      //  Task DisburseReturnsAsync(DisbursementDetails disbursementDetails);
    }
}
