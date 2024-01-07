using Invidux_Domain.Utilities;

namespace Invidux_Data.Dtos.Response
{
    public class WalletResponseDto
    {
        public string UserId { get; set; }
        public UserWalletDto Wallet { get; set; }
    }

    public class UserWalletDto
    {
        public string WalletId { get; set; }
        public string BVN { get; set; }
        public string DepositStellarId { get; set; }
        public bool Active { get; set; }
        public bool PinSet { get; set; }
        public ICollection<WalletTokenDto> Tokens { get; set; }
    }

    public class WalletTokenDto
    {
        public string Currency { get; set; }
        public int NumberOfBankAccounts { get; set; }
        public BalancesDto Balances { get; set; }
        public DepositAccountDto DepositVirtualAccount { get; set; }
        public WithdrawalAccountDto WithdrawalBankAccount { get; set; }
    }

    public class BalancesDto
    {
        public decimal Available { get; set; }
        public decimal Earnings { get; set; }
    }

    public class DepositAccountDto
    {
        public string AccountNumber { get; set;}
        public string BankName { get; set;}
    }

    public class WithdrawalAccountDto
    {
        public string AccountNumber { get; set; }
        public string BankName { get; set; }
    }

    public class AccountResponseDto
    {
        public int AccountId { get; set; }
        public string AccountNumber { get; set; }
        public string BankName { get; set; }
        public string Currency { get; set; }
        public DateTime? Date { get; set; }
    }

    public class TransactionResponse
    {
        public string InternalRef { get; set; }
        public string ExternalRef { get; set; }
        public DateTime Date { get; set; }
        public TransactionStatusStrings Status { get; set; }
        public TransactionTypeStrings TransactionType { get; set; }
        public bool Inflow { get; set; }
        public PaymentMethodStrings PaymentMethod { get; set; }
        public Decimal Amount { get; set; }
        public string Currency { get; set; }
    }

    public class TransactionListResponse
    {
        public string InternalRef { get; set; }
        public string ExternalRef { get; set; }
        public DateTime Date { get; set; }
        public TransactionStatusStrings Status { get; set; }
        public TransactionTypeStrings TransactionType { get; set; }
        public bool Inflow { get; set; }
        public PaymentMethodStrings PaymentMethod { get; set; }
        public Decimal Amount { get; set; }
        public string Currency { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Description { get; set; }
    }
    
    public class AccountStatement
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public ICollection<WalletTokenDto> TokenBalances { get; set; }
        public ICollection<TransactionListResponse> Transactions { get; set; }
    }
}
