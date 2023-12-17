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
}
