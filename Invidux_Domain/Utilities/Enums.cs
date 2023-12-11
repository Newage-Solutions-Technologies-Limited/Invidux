using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invidux_Domain.Utilities
{
    public enum RegistrationStatus
    {
        [Description("Pending")]
        Pending,
        [Description("Active")]
        Active,
        [Description("Restricted")]
        Restricted
    }

    public enum VerificationType
    {
        [Description("User Registration")]
        UserRegistration,
        [Description("Two Factor")]
        TwoFactorVerification,
        [Description("BVN")]
        BVN,
    }

    public enum TwoFactorCover
    {
        [Description("Login")]
        Login,
        [Description("Transactiosn")]
        Transaction,
        [Description("Trading")]
        Trading
    }

    public enum BankAccountType
    {
        [Description("Deposit Virtual Account")]
        DepositVirtualAccount,
        [Description("Withdrawal Bank Account")]
        WithdrawalBankAccount
    }

    public enum TransactionType
    {
        [Description("Deposit")]
        Deposit,
        [Description("Withdrawal")]
        Withdrawal,
        [Description("Earnings")]
        Earnings,
        [Description("Transfer")]
        Transfar
    }

    public enum TransactionStatus
    {
        [Description("Pending")]
        Pending,
        [Description("Successful")]
        Successful,
        [Description("Failed")]
        Failed

    }

    public enum TransactionFlow
    {
        [Description("Inflow")]
        Inflow,
        [Description("Outflow")]
        Outflow
    }

    public enum KYCLevel
    {

    }

    public enum EmploymentStatus
    {

    }

    public enum MonthlyIncomeRange
    {

    }
}
