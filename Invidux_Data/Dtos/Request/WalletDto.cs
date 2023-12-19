using Invidux_Domain.Models;
using Invidux_Domain.Utilities;
using System.ComponentModel.DataAnnotations;

namespace Invidux_Data.Dtos.Request
{
    public class ActivateWalletDto
    {
        public DateTime? DateOfBirth { get; set; }
        public string? BVN { get; set; }
        public SourceEnums? Source { get; set; }
    }

    public class SetWalletPinDto
    {
        public int OldWalletPin { get; set; }
        public int NewWalletPin { get; set; }
        public SourceEnums? Source { get; set; }
    }

    public class FundWalletDto
    {
        public string Currency { get; set; }
        public decimal Amount { get; set; }
        public int PaymentMethodId { get; set; }
        public SourceEnums? Source { get; set; }
    }

    public class WithdrawToBankDto
    {
        public string Currency { get; set; }
        public decimal Amount { get; set; }
        public int WithdrawalAccountId { get; set; }
        public int WalletPin { get; set; }
        public SourceEnums? Source { get; set; }
    }

    public class AddWithdrawalAccountDto
    {
        public string AccountNumber { get; set; }
        public string BankName { get; set; }
        public bool Adding { get; set; }
        public SourceEnums? Source { get; set; }
    }
}
