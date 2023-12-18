﻿using Invidux_Data.Dtos.Request;
using Invidux_Domain.Models;

namespace Invidux_Core.Interfaces
{
    public interface IWalletRepo
    {
        Task<Wallet> GetWalletAsync(string userId);
        Task<bool> ActivateWallet(ActivateWalletDto activateWalletDto, string userId);
        Task<bool> SetWalletPin(SetWalletPinDto pinDto, string userId);
    }
}