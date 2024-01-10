using Invidux_Core.Interfaces;
using Invidux_Data.Context;
using Invidux_Data.Dtos.Response;

namespace Invidux_Core.Implementations
{
    public class PortfolioRepo: IPortfolioRepo
    {
        private readonly InviduxDBContext dc;

        public PortfolioRepo(InviduxDBContext dc) 
        {
            this.dc = dc;
        }

        public async Task<PortfolioTokens> GetPortfolio(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<PortfolioToken> GetPortfolioToken(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetTransactions(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetTransaction(string userId)
        {
            throw new NotImplementedException();
        }

    }
}
