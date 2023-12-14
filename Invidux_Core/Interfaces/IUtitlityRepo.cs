using Invidux_Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invidux_Core.Interfaces
{
    public interface IUtitlityRepo
    {
        Task<IEnumerable<AppRole>> GetRolesAsync();
        Task<AppRole> GetRoleByIdAsync(string id);
        Task<IEnumerable<SubRole>> GetRoleSubRolesAsync(string id);
        Task<IEnumerable<SubRole>> GetSubRolesAsync();
        Task<SubRole> GetSubRoleAsync(string id);
        Task<IEnumerable<KycStatus>> GetKycStatusesAsync();
        Task<KycStatus> GetKycStatusAsync(int id);
        Task<IEnumerable<KycLevel>> GetKycLevelsAsync();
        Task<KycLevel> GetKycLevelAsync(int id);
        Task<IEnumerable<KycIdCard>> GetKycIdCardsAsync();
        Task<KycIdCard> GetKycIdCardAsync(int id);
        Task<IEnumerable<SecurityType>> GetSecurityTypesAsync();
        Task<SecurityType> GetSecurityTypeAsync(int id);
        Task<IEnumerable<TwoFactorCover>> GetTwoFactorCoversAsync();
        Task<TwoFactorCover> GetTwoFactorCoverAsync(int id);
        Task<IEnumerable<TwoFactorType>> GetTwoFactorTypes();
        Task<TwoFactorType> GetTwoFactorTypeAsync(int id);
        Task<IEnumerable<TokenListingStatus>> GetListingStatusesAsync();
        Task<TokenListingStatus> GetListingStatusAsync(int id);
        Task<IEnumerable<PropertyClass>> GetPropertyClassesAsync();
        Task<PropertyClass> GetPropertyClassAsync(int id);
        Task<IEnumerable<InvestmentType>> GetInvestmentTypesAsync();
        Task<InvestmentType> GetInvestmentTypeAsync(int id);
        Task<IEnumerable<TokenTransactionType>> GetTokenTransactionTypes();
        Task<TokenTransactionType> GetTokenTransactionType(int id);
        Task<IEnumerable<TransactionType>> GetTransactionTypesAsync();
        Task<TransactionType> GetTransactionTypeAsync(int id);
        Task<IEnumerable<PaymentMethod>> GetPaymentMethodsAsync();
        Task<PaymentMethod> GetPaymentMethodAsync(int id);

    }
}
