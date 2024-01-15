using AutoMapper;
using Invidux_Core.Interfaces;
using Invidux_Data.Context;
using Invidux_Data.Dtos.Response;
using Invidux_Domain.Models;
using Invidux_Domain.Utilities;
using Microsoft.EntityFrameworkCore;

namespace Invidux_Core.Implementations
{
    public class PortfolioRepo: IPortfolioRepo
    {
        private readonly InviduxDBContext dc;
        private readonly IMapper mapper;

        public PortfolioRepo(InviduxDBContext dc, IMapper mapper) 
        {
            this.dc = dc;
            this.mapper = mapper;
        }

        public async Task<PortfolioTokens> GetPortfolio(string userId)
        {
            var wallet = await dc.Wallets.Include(w => w.UserTokens)
                                            .FirstOrDefaultAsync(w => w.UserId == userId);
            if(wallet == null || !wallet.Active)
            {
                throw new InvalidOperationException("Invalid wallet");
            }
            var inAppTokens = wallet.UserTokens.Where(t => t.TokenType == TokenTypeStrings.InAppToken).ToList();
            var externalTokens = wallet.UserTokens.Where(t => t.TokenType == TokenTypeStrings.ExternalToken).ToList();

            /*if (!inAppTokens.Any())
            {
                // Handle the case where there are no in-app tokens
                throw new Exception();
            }
            if (!externalTokens.Any())
            {
                // Handle the case where there are no external tokens
            }*/


            var inApp = new Inapp
            {
                TokenCount = inAppTokens.Count,
                TokenCodes = inAppTokens.Select(t => t.TokenCode).ToArray(),
                OwnedVolume = inAppTokens.Sum(t => t.Available),
                CoolingOffVolume = inAppTokens.Sum(t => t.CoolingOffVolume), 
                Currency = inAppTokens.FirstOrDefault()?.Currency,
                TotalCost = inAppTokens.Sum(t => t.TotalCost), 
                CurrentValue = inAppTokens.Sum(t => t.CurrentValue) 
            };

            // Aggregate data for External
            var external = new External
            {
                ExternalStellarIds = externalTokens.SelectMany(t => t.StellarAccounts.Select(sa => sa.DepositStellarId)).ToArray(),
                TokenCount = externalTokens.Count,
                TokenCodes = externalTokens.Select(t => t.TokenCode).ToArray(),
                OwnedVolume = externalTokens.Sum(t => t.Available),
                Currency = externalTokens.FirstOrDefault()?.Currency,
                CurrentValue = externalTokens.Sum(t => t.CurrentValue)
            };

            // Create and return the PortfolioTokens DTO
            var portfolioTokens = new PortfolioTokens
            {
                InApp = inApp,
                External = external
            };

            return portfolioTokens;
        }

        public async Task<PortfolioToken> GetPortfolioToken(int id, string userId)
        {
            var user = await dc.AppUsers.FirstOrDefaultAsync(u => u.Id == userId);
            var userToken = await dc.UserTokens
                        .Include(ut => ut.Token)
                        .ThenInclude(t => t.Images)
                        .FirstOrDefaultAsync(ut => ut.Id == id);

            if (userToken == null)
            {
                throw new Exception($"No user token with the Id: {id}");
            }
            var propertyImages = userToken.Token.Images.Select(img => img.ImageUrl).ToArray();

            var tokenYield = await dc.TokenAnnualYields.FirstOrDefaultAsync(ay => ay.TokenId == userToken.TokenId);
            var tokenTxns = await dc.Transactions
                                            .Where(txn => txn.TokenCode == userToken.TokenCode && 
                                            (txn.Sender == user.UserName || txn.Receiver == user.UserName))
                                            .ToListAsync();

            var transactions = mapper.Map<IEnumerable<TransactionRes>>(tokenTxns);
            var annualYield = mapper.Map<AnnualYield>(tokenYield);
            var portfolio = new PortfolioToken
            {
                TokenCode = userToken.TokenCode,
                PropertyImages = propertyImages,
                SupplyVolume = userToken.Token.Volume,
                OwnedVolume = userToken.Available,
                CoolingOffVolume = userToken.CoolingOffVolume,
                Currency = userToken.Currency,
                TotalCost = userToken.TotalCost,
                TotalValue = userToken.Token.MarketCap,
                DistributionFrequency = userToken.Token.DistributionFrequency,
                Transactions = transactions,
                AnnualYield = annualYield
            };

            return portfolio;
        }

        public async Task<IEnumerable<Transaction>> GetTransactions(string userId)
        {
            var user = await dc.AppUsers.FirstOrDefaultAsync(u => u.Id == userId);
            if(user == null)
            {
                throw new Exception("User does not exist");
            }
            var transactions = await dc.Transactions
                                       .Where(tr => tr.Sender == user.UserName || tr.Receiver == user.UserName)
                                       .OrderByDescending(tr => tr.TransactionDate) // Sort by date, most recent first
                                       .ToListAsync();
            return transactions;
        }

    }
}
