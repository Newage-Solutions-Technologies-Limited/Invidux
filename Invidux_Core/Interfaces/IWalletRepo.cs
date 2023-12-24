using Invidux_Data.Dtos.Request;
using Invidux_Data.Dtos.Response;
using Invidux_Domain.Models;

namespace Invidux_Core.Interfaces
{
    public interface IWalletRepo
    {
        Task<Wallet> GetWalletAsync(string userId);
        Task<BvnResponse> GetBvnDetail(string bvn, string secretKey);
        Task<string> GetBvnDetails(string bvn, string secretKey);
        Task<bool> GetBvnDetailsAsync(string bvn, string secretKey);
        Task<bool> ActivateWallet(ActivateWalletDto activateWalletDto, string userId);
        Task<bool> SetWalletPin(SetWalletPinDto pinDto, string userId);
    }
}
