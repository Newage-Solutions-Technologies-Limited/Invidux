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
        Task<int> FundWallet();
        Task<int> TransferFunds();
        Task<int> WithdrawToBank();
        Task<int> AddWithdrawalAccount();
        Task<int> GetWithdrawalAccount(string userId);
        Task<int> RemoveWithdrawalAccount();
        Task<int> WithdrawToStellar();
        Task<int> AddStellarAccount();
        Task<int> RemoveStellarAccount();
        // Get method
        Task<int> RecentTransactions();
        Task<int> GetTransactions();
        Task<int> GetTransactionByRef(string transactionRef);
        Task<int> GetStatement();
    }
}
