using Invidux_Domain.Utilities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Invidux_Domain.Models
{
    public class BankAccount: BaseUser
    {
        public BankAccountTypeEnums AccountType { get; set; }
        public string? AccountNumber { get; set; }
        public string? AccountName { get; set; }
        public string? BankName {  get; set; }
        public string? Currency { get; set; }
        [ForeignKey("UserToken")]
        public int TokenId { get; set; }
        public UserToken? UserToken { get; set; }
    }
}
