using Invidux_Data.Dtos.Response;
using Invidux_Domain.Models;

namespace Invidux_Core.Interfaces
{
    public interface IPortfolioRepo
    {
        Task<PortfolioTokens> GetPortfolio(string userId);
        Task<PortfolioToken> GetPortfolioToken(int id, string userId);
        Task<IEnumerable<Transaction>>GetTransactions(string userId);
    }
}
