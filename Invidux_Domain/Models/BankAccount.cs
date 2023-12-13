using Invidux_Domain.Utilities;

namespace Invidux_Domain.Models
{
    public class BankAccount: BaseUser
    {
        public BankAccountType AccountType { get; set; }
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public string BankName {  get; set; } 
    }
}
