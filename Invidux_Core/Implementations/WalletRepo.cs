using Invidux_Core.Interfaces;
using Invidux_Data.Context;
using Invidux_Data.Dtos.Request;
using Invidux_Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Invidux_Core.Implementations
{
    public class WalletRepo: IWalletRepo
    {
        private readonly InviduxDBContext dc;

        public WalletRepo(InviduxDBContext dc)
        {
            this.dc = dc;
        }

        public async Task<Wallet> GetWalletAsync(string userId)
        {
            var wallet = await dc.Wallets.Include(w => w.UserTokens)
                .ThenInclude(ut => ut.BankAccounts)
            .FirstOrDefaultAsync(w => w.UserId == userId);

            if (wallet == null)
            {
                // Handle the case where the wallet is not found
                return null;
            }

            return wallet;
        }

        public async Task<bool> ActivateWallet(ActivateWalletDto activateWalletDto, string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SetWalletPin(SetWalletPinDto pinDto, string userId)
        {
            var wallet = await dc.Wallets.FirstOrDefaultAsync(w => w.UserId == userId);
            if (wallet == null)
            {
                throw new Exception("Wallet not found");
            }
            if (!wallet.PinSet)
            {
                wallet.WalletPin = pinDto.NewWalletPin;
                wallet.PinSet = true;
            }
            else
            {
                if (wallet.WalletPin != pinDto.OldWalletPin)
                {
                    return false;
                }
                wallet.WalletPin = pinDto.NewWalletPin;
            }
            dc.Wallets.Update(wallet);
            await dc.SaveChangesAsync();
            return true;
        }
    }
}
