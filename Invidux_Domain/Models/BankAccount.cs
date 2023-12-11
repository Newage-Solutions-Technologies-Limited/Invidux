using Invidux_Domain.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invidux_Domain.Models
{
    /// <summary>
    /// Bank name can be replaced by an api that can get banks 
    /// </summary>
    public class BankAccount: BaseUser
    {
        public BankAccountType AccountType { get; set; }
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public string BankName {  get; set; } 
    }
}
