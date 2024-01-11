using Invidux_Data.Dtos.Response;

namespace Invidux_Core.Interfaces
{
    public interface IPortfolioRepo
    {
        Task<PortfolioTokens> GetPortfolio(string userId);
        Task<PortfolioToken> GetPortfolioToken(int id, string userId);
        Task<int>GetTransactions(string userId);
        Task<int>GetTransaction(string userId);
    }
}
