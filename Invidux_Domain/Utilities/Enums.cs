﻿using System.ComponentModel;

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

    public enum TwoFactorTypeEnums
    {
        [Description("Email")]
        Email,
        [Description("Phone Number")]
        PhoneNumber,
        [Description("Google Auth")]
        GoogleAuth
    }

    public enum BankAccountType
    {
        [Description("Deposit Virtual Account")]
        DepositVirtualAccount,
        [Description("Withdrawal Bank Account")]
        WithdrawalBankAccount
    }

    /*public enum TransactionType
    {
        [Description("Deposit")]
        Deposit,
        [Description("Withdrawal")]
        Withdrawal,
        [Description("Earnings")]
        Earnings,
        [Description("Transfer")]
        Transfar
    }*/


    public enum EmploymentStatus
    {
        [Description("Unemployed")]
        Unemployed,
        [Description("Employed")]
        Employed,
    }

    public enum MonthlyIncomeRange
    {

    }
}
