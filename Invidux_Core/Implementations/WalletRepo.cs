using Invidux_Core.Interfaces;
using Invidux_Data.Context;
using Invidux_Data.Dtos.Request;
using Invidux_Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace Invidux_Core.Implementations
{
    public class WalletRepo: IWalletRepo
    {
        private readonly InviduxDBContext dc;
        private readonly IConfiguration config;

        public WalletRepo(IConfiguration config, InviduxDBContext dc)
        {
            this.config = config;
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

        //public async Task<string> GetBvnDetailsAsync(string bvn, string secretKey)
        public async Task<bool> GetBvnDetailsAsync(string bvn, string secretKey)
        {
            using (var client = new HttpClient())
            {
                // Set the Authorization header
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", secretKey);

                // Make the GET request
                HttpResponseMessage response = await client.GetAsync($"https://api.paystack.co/bank/resolve_bvn/{bvn}");

                if (response.IsSuccessStatusCode)
                {
                    // Read and return the response body
                    Console.WriteLine(response.Content);
                    // return await response.Content.ReadAsStringAsync();
                    return true;
                }
                else
                {
                    // Handle the error (or throw an exception)
                    // return $"Error: {response.StatusCode}";
                    return false;
                }
            }
        }

        /// <summary>
        /// In progress
        /// Currently can't get response message back from paystack due to legal reasons
        /// </summary>
        /// <param name="activateWalletDto"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<bool> ActivateWallet(ActivateWalletDto activateWalletDto, string userId)
        {
            
            try
            {
                string secretKey = config.GetSection("PaystackTest:SecretKey").Value;
                // string response = await GetBvnDetailsAsync(activateWalletDto.BVN, secretKey);
                bool response = await GetBvnDetailsAsync(activateWalletDto.BVN, secretKey);
                Console.WriteLine(response);
                if(response)
                {
                    var wallet = await dc.Wallets.FirstOrDefaultAsync(w => w.UserId == userId);
                    if (wallet == null)
                    {
                        return false;
                    }
                    wallet.BVN = activateWalletDto.BVN;
                    wallet.Active = true;
                    dc.Wallets.Update(wallet);
                    dc.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                throw ex;
            }
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
