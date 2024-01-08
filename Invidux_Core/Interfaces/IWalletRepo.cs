using Invidux_Data.Dtos.Request;
using Invidux_Data.Dtos.Response;
using Invidux_Domain.Models;

namespace Invidux_Core.Interfaces
{
    public interface IWalletRepo
    {
        // To be completed
        Task<bool> ResendOtp(string email);
        Task<Wallet> GetWalletAsync(string userId);
        Task<BvnResponse> GetBvnDetail(string bvn, string secretKey);
        Task<string> GetBvnDetails(string bvn, string secretKey);
        Task<bool> GetBvnDetailsAsync(string bvn, string secretKey);
        Task<bool> ActivateWallet(ActivateWalletDto activateWalletDto, string userId);
        Task<bool> SetWalletPin(SetWalletPinDto pinDto, string userId);
        /// <summary>
        /// The following are skeletons to be implemented
        /// </summary>
        /// <returns></returns>
        // DTO to be included
        Task<Transaction> FundWallet(FundWalletDto walletDto, string userId);
        Task<Transaction> TransferFunds(TranferFundsDto tranferFunds, string userId);
        Task<Transaction> WithdrawToBank(WithdrawToBankDto withdrawTo, string userId);
        Task<AccountResponseDto> AddWithdrawalAccount(AddWithdrawalAccountDto addWithdrawal, string userId);
        Task<IEnumerable<BankAccount>> GetWithdrawalAccounts(string userId);
        Task<string> WithdrawToStellar(WithdrawToStellar withdrawDto, string userId);
        Task<int> AddStellarAccount(AddStellarDto stellarDto, string userId);
        // Get method
        Task<IEnumerable<Transaction>> RecentTransactions(string userId);
        Task<IEnumerable<Transaction>> GetTransactions(string userId);
        Task<Transaction> GetTransactionByRef(string transactionRef);
        Task<int> GetStatement(StatementReq statementReq, string userId);
    }
}
