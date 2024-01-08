using Invidux_Core.Interfaces;
using Invidux_Data.Context;
using Invidux_Data.Dtos.Request;
using Invidux_Data.Dtos.Response;
using Invidux_Domain.Models;
using Invidux_Domain.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Invidux_Core.Helpers;
using stellar_dotnet_sdk;
using stellar_dotnet_sdk.responses;
using Microsoft.AspNetCore.Identity;
using CloudinaryDotNet;
using AutoMapper;
using Microsoft.AspNetCore.Identity.UI.Services;
using iText.Kernel.Pdf;

namespace Invidux_Core.Implementations
{
    public class WalletRepo: IWalletRepo
    {
        private readonly InviduxDBContext dc;
        private readonly IConfiguration config;
        private readonly IMapper mapper;
        private readonly IEmailSender _emailSender;

        public WalletRepo(IConfiguration config, InviduxDBContext dc, IMapper mapper, IEmailSender _emailSender)
        {
            this.config = config;
            this.dc = dc;
            this.mapper = mapper;
            this._emailSender = _emailSender;
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

        public async Task<BvnResponse> GetBvnDetail(string bvn, string secretKey)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", secretKey);
                HttpResponseMessage response = await client.GetAsync($"https://api.paystack.co/bank/resolve_bvn/{bvn}");

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    return System.Text.Json.JsonSerializer.Deserialize<BvnResponse>(jsonResponse);
                }
                else
                {
                    // Handle the error (or throw an exception)
                    throw new HttpRequestException($"Error: {response.StatusCode}");
                }
            }
        }

        public async Task<string> GetBvnDetails(string bvn, string secretKey)
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
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    // Handle the error (or throw an exception)
                    return $"Error: {response.StatusCode}";
                }
            }
        }
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
                bool response = await GetBvnDetailsAsync(activateWalletDto.BVN, secretKey);
                string result = await GetBvnDetails(activateWalletDto.BVN, secretKey);
                var bvn = await GetBvnDetail(activateWalletDto.BVN, secretKey);
                Console.WriteLine(bvn.ToString());
                Console.WriteLine(result);
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

        /// <summary>
        /// The following are to be implemented with proper dto
        /// </summary>
        /// <returns></returns>

        public async Task<bool> ResendOtp(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<Invidux_Domain.Models.Transaction> FundWallet(FundWalletDto walletDto, string userId)
        {
            // Create a new Transaction object
            var transaction = new Invidux_Domain.Models.Transaction();

            // Retrieve the wallet for the given userId
            var wallet = await dc.Wallets
                                        .Include(w => w.UserTokens) // Include UserTokens
                                        .FirstOrDefaultAsync(w => w.UserId == userId);

            var user = await dc.AppUsers.FirstOrDefaultAsync(u => u.Id == userId);

            if (user.TwoFactorEnabled)
            {
                // Handle two factor case
                // To be implemented
                throw new NotImplementedException("Not yet implemented");
            }

            if (wallet == null)
            {
                // Handle the case where the wallet doesn't exist
                throw new Exception("Wallet not found");
            }

            if (!wallet.Active)
            {
                // Handle the case where the wallet is not activated
                throw new Exception("Activate your wallet");
            }

            // Find the UserToken with the matching currency in the wallet
            var userToken = wallet.UserTokens.FirstOrDefault(ut => ut.Currency == walletDto.Currency);
            if (userToken == null)
            {
                userToken = new UserToken
                {
                    Currency = walletDto.Currency,
                    Available = 0, // Initialize with 0, will be updated with the amount below
                    Earnings = 0, // Assuming you need to initialize this as well
                    WalletId = wallet.Id,
                };

                // Add the new UserToken to the wallet
                dc.UserTokens.Add(userToken);
            }

            // Update the userToken's Available or Earnings based on your business logic
            userToken.Available += walletDto.Amount;
            dc.UserTokens.Update(userToken);
            var paymentMethod = await dc.PaymentMethods.FirstOrDefaultAsync(pm => pm.Id == walletDto.PaymentMethodId);

            // Set values for transaction object
            transaction.Sender = "Self Funding";
            transaction.Receiver = wallet.Id;
            transaction.InternalRef = GenerateInternalRef.TransactionRef(); 
            transaction.ExternalRef = ""; // Update based on business logic
            transaction.Type = TransactionTypeStrings.Deposit;
            transaction.PaymentMethod = paymentMethod.Name;
            transaction.Status = "Completed"; // Or other status based on your system's logic
            transaction.Amount = walletDto.Amount.ToString();
            transaction.Inflow = true;
            transaction.CurrencySymbol = walletDto.Currency;
            transaction.Description = "Funding Wallet";
            transaction.TransactionDate = DateTime.UtcNow;

            // Add the transaction to the database and save changes
            dc.Transactions.Add(transaction);
            await dc.SaveChangesAsync();

            // Return a Transaction object 
            return transaction;
        }

        public async Task<Invidux_Domain.Models.Transaction> TransferFunds(TranferFundsDto tranferFunds, string userId)
        {
            // Create a new Transaction object
            var transaction = new Invidux_Domain.Models.Transaction();

            // Retrieve the wallet for the given userId
            var wallet = await dc.Wallets
                                        .Include(w => w.UserTokens) // Include UserTokens
                                        .FirstOrDefaultAsync(w => w.UserId == userId);
            var receiver = await dc.AppUsers
                                            .Include(r => r.Wallet.UserTokens)
                                            .FirstOrDefaultAsync(r => r.UserName == tranferFunds.ReceiverUsername);
            if (wallet == null)
            {
                // Handle the case where the wallet doesn't exist
                throw new Exception("Wallet not found");
            }

            if (!wallet.Active)
            {
                // Handle the case where the wallet is not activated
                throw new Exception("Activate your wallet");
            }

            if(wallet.WalletPin != tranferFunds.WalletPin)
            {
                throw new Exception("Invalid wallet pin");
            }

            if (receiver == null)
            {
                throw new Exception("User not found");
            }

            if (!receiver.Wallet.Active)
            {
                // Handle the case where the wallet is not activated
                throw new Exception("Receiver wallet not active");
            }

            // Find the UserToken with the matching currency in the wallet
            var userToken = wallet.UserTokens.FirstOrDefault(ut => ut.Currency == tranferFunds.Currency);

            var receiverToken = receiver.Wallet.UserTokens.FirstOrDefault(rt => rt.Currency == tranferFunds.Currency);

            if (userToken == null)
            {
                throw new Exception("Token not found");
            }

            if (receiverToken == null)
            {
                receiverToken = new UserToken
                {
                    Currency = tranferFunds.Currency,
                    Available = 0, // Initialize with 0, will be updated with the amount below
                    Earnings = 0, // Assuming you need to initialize this as well
                    WalletId = receiver.Wallet.Id,
                };

                // Add the new UserToken to the wallet
                dc.UserTokens.Add(receiverToken);
            }

            if (userToken.Available < tranferFunds.Amount)
            {
                throw new Exception("Insufficient funds");
            }

            userToken.Available -= tranferFunds.Amount;
            receiverToken.Available += tranferFunds.Amount;
            dc.UserTokens.Update(userToken);
            dc.UserTokens.Update(receiverToken);

            // Set values for transaction object
            transaction.Sender = wallet.Id;
            transaction.Receiver = receiver.Wallet.Id;
            transaction.InternalRef = GenerateInternalRef.TransactionRef();
            transaction.ExternalRef = ""; // Update based on business logic
            transaction.Type = TransactionTypeStrings.Transfer;
            transaction.Status = "Completed"; 
            transaction.Amount = tranferFunds.Amount.ToString();
            transaction.Inflow = true;
            transaction.CurrencySymbol = tranferFunds.Currency;
            transaction.Description = "Transfer";
            transaction.TransactionDate = DateTime.UtcNow;

            // Add the transaction to the database and save changes
            dc.Transactions.Add(transaction);
            await dc.SaveChangesAsync();

            return transaction;
        }

        /// <summary>
        /// Third party api needed to facilitate a transfer of held amount by invidux to user's bank
        /// </summary>
        /// <param name="withdrawTo"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<Invidux_Domain.Models.Transaction> WithdrawToBank(WithdrawToBankDto withdrawTo, string userId)
        {
            // Create a new Transaction object
            var transaction = new Invidux_Domain.Models.Transaction();

            // Retrieve the wallet for the given userId
            var wallet = await dc.Wallets
                                        .Include(w => w.UserTokens) // Include UserTokens
                                        .FirstOrDefaultAsync(w => w.UserId == userId);
            if (wallet == null)
            {
                // Handle the case where the wallet doesn't exist
                throw new Exception("Wallet not found");
            }

            if (!wallet.Active)
            {
                // Handle the case where the wallet is not activated
                throw new Exception("Activate your wallet");
            }

            if (wallet.WalletPin != withdrawTo.WalletPin)
            {
                throw new Exception("Invalid wallet pin");
            }

            // Find the UserToken with the matching currency in the wallet
            var userToken = wallet.UserTokens.FirstOrDefault(ut => ut.Currency == withdrawTo.Currency);

            if (userToken == null)
            {
                throw new Exception("You have no such token with associated currency");
            }

            if(userToken.Available < withdrawTo.Amount)
            {
                throw new Exception("Insufficient fund");
            }

            var bankAccount = await dc.BankAccounts
                                        .Where(ba => ba.AccountType == BankAccountTypeEnums.WithdrawalBankAccount)
                                        .FirstOrDefaultAsync(ba => ba.TokenId == userToken.Id);

            if (bankAccount == null)
            {
                throw new Exception("You don't have a withdrawal account for this token");
            }

            userToken.Available -= withdrawTo.Amount;

            // Call api to facilitate bank transaction 
            // upon success update the token available balance
            dc.UserTokens.Update(userToken);

            // Set values for transaction object
            transaction.Sender = wallet.Id;
            transaction.Receiver = "Bank withdrawal";
            transaction.InternalRef = GenerateInternalRef.TransactionRef();
            transaction.ExternalRef = ""; // Update based on business logic
            transaction.Type = TransactionTypeStrings.Withdrawal;
            transaction.Status = "Completed"; // to be update for proper use case of failure
            transaction.Amount = withdrawTo.Amount.ToString();
            transaction.Inflow = true;
            transaction.CurrencySymbol = withdrawTo.Currency;
            transaction.Description = "Withdrawal of funds";
            transaction.TransactionDate = DateTime.UtcNow;

            // Add the transaction to the database and save changes
            dc.Transactions.Add(transaction);
            await dc.SaveChangesAsync();

            return transaction;
        }
        public async Task<AccountResponseDto> AddWithdrawalAccount(AddWithdrawalAccountDto addWithdrawal, string userId)
        {
            // Retrieve the wallet for the given userId
            var wallet = await dc.Wallets
                                        .Include(w => w.UserTokens) // Include UserTokens
                                        .FirstOrDefaultAsync(w => w.UserId == userId);
            // Find the UserToken with the matching currency in the wallet
            var userToken = wallet.UserTokens.FirstOrDefault(ut => ut.Currency == addWithdrawal.Currency);
            var user = await dc.AppUsers.Include(ba => ba.BankAccounts).FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            if(addWithdrawal.Adding)
            {
                if (user.BankAccounts.Count > 3)
                {
                    throw new Exception("You have more than 3 Bank accounts");
                }
            }

            /* There will be a check to see if the user bvn matches with bank account
             * This will be carried out when paystack is fixed             
             */
            var existingAcct = user.BankAccounts.FirstOrDefault(ea => ea.AccountNumber == addWithdrawal.AccountNumber);
            if (existingAcct != null)
            {
                throw new Exception("This accounts exist already");
            }
            if (userToken == null)
            {
                userToken = new UserToken
                {
                    Currency = addWithdrawal.Currency,
                    Available = 0, // Initialize with 0, will be updated with the amount below
                    Earnings = 0, // Assuming you need to initialize this as well
                    WalletId = wallet.Id,
                };

                // Add the new UserToken to the wallet
                dc.UserTokens.Add(userToken);
            }
            existingAcct = new BankAccount
            {
                AccountNumber = addWithdrawal.AccountNumber,
                BankName = addWithdrawal.BankName,
                UserId = userId,
                AccountType = BankAccountTypeEnums.WithdrawalBankAccount,
                TokenId = userToken.Id,
                Currency = addWithdrawal.Currency
            };
            dc.BankAccounts.Add(existingAcct);
            dc.SaveChanges();
            var response = new AccountResponseDto
            {
                AccountId = existingAcct.Id,
                AccountNumber = existingAcct.AccountNumber,
                BankName = existingAcct.BankName,
                Currency = addWithdrawal.Currency,
                Date = DateTime.UtcNow
            };
           return response;
        }
        
        public async Task<IEnumerable<BankAccount>> GetWithdrawalAccounts(string userId)
        {
            var accounts = await dc.BankAccounts
                                            .Where(ba => 
                                                        ba.UserId == userId 
                                                        && ba.AccountType == BankAccountTypeEnums.WithdrawalBankAccount)
                                            .ToListAsync();
            return accounts;
        }

        /// <summary>
        /// To be completely implemented when ambiguity of wallet and token is solved
        /// </summary>
        /// <param name="withdrawDto"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<string> WithdrawToStellar(WithdrawToStellar withdrawDto, string userId)
        {
            // Retrieve the wallet for the given userId
            var wallet = await dc.Wallets
                                        .Include(w => w.UserTokens) // Include UserTokens
                                        .FirstOrDefaultAsync(w => w.UserId == userId);
            if (wallet == null || !wallet.Active)
            {
                throw new Exception("Invalid wallet, activate your wallet");
            }

            if (wallet.WalletPin != withdrawDto.WalletPin)
            {
                throw new Exception("Invalid wallet pin");
            }

            Network.UsePublicNetwork(); // Use `Network.UseTestNetwork();` for testing
            var server = new Server("https://horizon.stellar.org");

            // Load your account
            var sourceAccountKeyPair = KeyPair.FromSecretSeed("Your_Secret_Seed");
            var sourceAccount = await server.Accounts.Account(sourceAccountKeyPair.AccountId);

            // Build a transaction
            var transaction = new TransactionBuilder(sourceAccount)
                .AddOperation(new PaymentOperation.Builder(KeyPair.FromAccountId(wallet.DepositStellarId), new AssetTypeNative(), withdrawDto.Amount.ToString()).Build())
                // Optionally add a memo here if needed
                .Build();

            // Sign the transaction with your secret key
            transaction.Sign(sourceAccountKeyPair);

            // Submit the transaction to the Stellar network
            try
            {
                var response = await server.SubmitTransaction(transaction);
                return response.Hash;
            }
            catch (Exception e)
            {
                // Handle exceptions
                return $"Error: {e.Message}";
            }
        }
        public async Task<int> AddStellarAccount(AddStellarDto stellarDto, string userId)
        {
            // Retrieve the wallet for the given userId
            var wallet = await dc.Wallets.FirstOrDefaultAsync(w => w.UserId == userId);
            if (wallet == null || !wallet.Active)
            {
                return -1;
            }
            if(wallet.WalletPin != stellarDto.WalletPin)
            {
                return 0;
            }
            wallet.DepositStellarId = stellarDto.StellarId;
            dc.Wallets.Update(wallet);
            dc.SaveChanges();
            return 1;
        }

        public async Task<IEnumerable<Invidux_Domain.Models.Transaction>> RecentTransactions(string userId)
        {
            var transactions = await dc.Transactions
                                       .Where(tr => tr.Sender == userId || tr.Receiver == userId)
                                       .OrderByDescending(tr => tr.TransactionDate) // Sort by date, most recent first
                                       .Take(8) // Take only the top 8 transactions
                                       .ToListAsync();

            return transactions;
        }

        public async Task<IEnumerable<Invidux_Domain.Models.Transaction>> GetTransactions(string userId)
        {
            var transactions = await dc.Transactions
                                       .Where(tr => tr.Sender == userId || tr.Receiver == userId)
                                       .OrderByDescending(tr => tr.TransactionDate) // Sort by date, most recent first
                                       .ToListAsync();
            return transactions;
        }

        public async Task<Invidux_Domain.Models.Transaction> GetTransactionByRef(string transactionRef)
        {
            var transaction = await dc.Transactions.FirstOrDefaultAsync(tr => tr.InternalRef == transactionRef);
            return transaction == null ? null : transaction;
        }

        public async Task<int> GetStatement(StatementReq statementReq, string userId)
        {
            var user = await dc.AppUsers.Include(u => u.Personal).FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            // Fetch user's wallet data 
            var wallet = await dc.Wallets
                                 .Include(w => w.UserTokens)
                                 .FirstOrDefaultAsync(w => w.UserId == userId);


            if (wallet == null || !wallet.Active)
            {
                throw new Exception("Wallet not found, activate your wallet");
            }

            // Fetch transactions for the user within the specified date range
            var transactions = await dc.Transactions
                                      .Where(tr => (tr.Sender == userId || tr.Receiver == userId) &&
                                                   tr.TransactionDate >= statementReq.DateFrom &&
                                                   tr.TransactionDate <= statementReq.DateTo)
                                      .OrderByDescending(tr => tr.TransactionDate)
                                      .ToListAsync();
            var accountStatement = new AccountStatement
            {
                Name = user.Personal.FirstName + " " + user.Personal.LastName,  // Fetch the actual name from your user data source
                Username = user.UserName,  // Fetch the actual username from your user data source
                TokenBalances = mapper.Map<ICollection<WalletTokenDto>>(wallet.UserTokens),
                Transactions = mapper.Map<ICollection<TransactionListResponse>>(transactions)
            };
            // To implement Pdf generator
            throw new NotImplementedException();
        }

        
    }
}
