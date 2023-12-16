using Invidux_Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Invidux_Data.Dtos.Request
{
    public class ActivateWalletDto
    {
        public DateTime? DateOfBirth { get; set; }
        public string? BVN { get; set; }
    }

    public class SetWalletPinDto
    {
        public int OldWalletPin { get; set; }
        public int NewWalletPin { get; set; }
    }

    public class FundWalletDto
    {
        public string Currency { get; set; }
        public decimal Amount { get; set; }
        public int PaymentMethodId { get; set; }
}
