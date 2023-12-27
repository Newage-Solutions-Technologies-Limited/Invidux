using Invidux_Core.Interfaces;
using Invidux_Data.Context;
using Invidux_Data.Dtos.Response;
using Invidux_Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Mail;

namespace Invidux_Core.Implementations
{
    public class UtilityRepo: IUtitlityRepo
    {
        private readonly InviduxDBContext dc;
        private readonly RoleManager<AppRole> _roleManager;
        public UtilityRepo(InviduxDBContext dc, RoleManager<AppRole> _roleManager) 
        { 
            this.dc = dc;
            this._roleManager = _roleManager;
        }

        public async Task<IEnumerable<AppRole>> GetRolesAsync()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return roles == null ? null : roles;
        }

        public async Task<AppRole> GetRoleByIdAsync(string id)
        {
            var role = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == id);
            return role == null ? null : role;
        }

        public async Task<IEnumerable<SubRole>> GetRoleSubRolesAsync(string id)
        {
            var subRoles = await dc.SubRoles.Include(sr => sr.Role).Where(x => x.RoleId == id).ToListAsync();
            return subRoles == null ? null : subRoles;
        }

        public async Task<IEnumerable<SubRole>> GetSubRolesAsync()
        {
            var subRoles = await dc.SubRoles.Include(sr => sr.Role).ToListAsync();
            return subRoles == null ? null : subRoles;
        }

        public async Task<SubRole> GetSubRoleAsync(string id)
        {
            var subRole = await dc.SubRoles.Include(sr => sr.Role).FirstOrDefaultAsync(x => x.Id == id);
            return subRole == null ? null : subRole;
        }

        public async Task<IEnumerable<KycStatus>> GetKycStatusesAsync()
        {
            var statuses = await dc.KycStatuses.ToListAsync();
            return statuses == null ? null : statuses;
        }

        public async Task<KycStatus> GetKycStatusAsync(int id)
        {
            var status = await dc.KycStatuses.FirstOrDefaultAsync(x => x.Id == id);
            return status == null ? null : status;
        }

        public async Task<IEnumerable<KycLevel>> GetKycLevelsAsync()
        {
            var levels = await dc.KycLevels.ToListAsync();
            return levels == null ? null : levels;
        }

        public async Task<KycLevel> GetKycLevelAsync(int id)
        {
            var level = await dc.KycLevels.FirstOrDefaultAsync(x => x.Id == id);
            return level == null ? null : level;
        }

        public async Task<IEnumerable<KycIdCard>> GetKycIdCardsAsync()
        {
            var idCards = await dc.IdCards.ToListAsync();
            return idCards == null ? null : idCards;
        }

        public async Task<KycIdCard> GetKycIdCardAsync(int id)
        {
            var idCard = await dc.IdCards.FirstOrDefaultAsync(x => x.Id == id);
            return idCard == null ? null : idCard;
        }

        public async Task<IEnumerable<SecurityType>> GetSecurityTypesAsync()
        {
            var types = await dc.SecurityTypes.ToListAsync();
            return types == null ? null : types;
        }

        public async Task<SecurityType> GetSecurityTypeAsync(int id)
        {
            var type = await dc.SecurityTypes.FirstOrDefaultAsync(x => x.Id == id);
            return type == null ? null : type;
        }

        public async Task<IEnumerable<TwoFactorCover>> GetTwoFactorCoversAsync()
        {
            var covers = await dc.TwoFactorCovers.ToListAsync();
            return covers == null ? null : covers;
        }

        public async Task<TwoFactorCover> GetTwoFactorCoverAsync(int id)
        {
            var cover = await dc.TwoFactorCovers.FirstOrDefaultAsync(x => x.Id == id);
            return cover == null ? null : cover;
        }

        public async Task<IEnumerable<TwoFactorType>> GetTwoFactorTypes()
        {
            var types = await dc.TwoFactorTypes.ToListAsync();
            return types == null ? null : types;
        }

        public async Task<TwoFactorType> GetTwoFactorTypeAsync(int id)
        {
            var type = await dc.TwoFactorTypes.FirstOrDefaultAsync(x => x.Id == id);
            return type == null ? null : type;
        }

        public async Task<IEnumerable<TokenListingStatus>> GetListingStatusesAsync()
        {
            var statuses = await dc.TokenListingStatuses.ToListAsync();
            return statuses == null ? null : statuses;
        }

        public async Task<TokenListingStatus> GetListingStatusAsync(int id)
        {
            var status = await dc.TokenListingStatuses.FirstOrDefaultAsync(x => x.Id == id);
            return status == null ? null : status;
        }

        public async Task<IEnumerable<PropertyClass>> GetPropertyClassesAsync()
        {
            var propClasses = await dc.PropertyClasses.ToListAsync();
            return propClasses;
        }

        public async Task<PropertyClass> GetPropertyClassAsync(int id)
        {
            var propClass = await dc.PropertyClasses.FirstOrDefaultAsync(x => x.Id == id);
            return propClass == null ? null : propClass;
        }

        public async Task<IEnumerable<InvestmentType>> GetInvestmentTypesAsync()
        {
            var types = await dc.InvestmentTypes.ToListAsync();
            return types == null ? null : types; 
        }
        public async Task<InvestmentType> GetInvestmentTypeAsync(int id)
        {
            var type = await dc.InvestmentTypes.FirstOrDefaultAsync(x => x.Id == id);
            return type == null ? null : type;
        }

        public async Task<IEnumerable<TokenTransactionType>> GetTokenTransactionTypes()
        {
            var types = await dc.TokenTransactionTypes.ToListAsync();
            return types == null ? null : types;
        }

        public async Task<TokenTransactionType> GetTokenTransactionType(int id)
        {
            var type = await dc.TokenTransactionTypes.FirstOrDefaultAsync(x => x.Id == id);
            return type == null ? null : type;
        }

        public async Task<IEnumerable<TransactionType>> GetTransactionTypesAsync()
        {
            var types = await dc.TransactionTypes.ToListAsync();
            return types == null ? null : types;
        }

        public async Task<TransactionType> GetTransactionTypeAsync(int id)
        {
            var type = await dc.TransactionTypes.FirstOrDefaultAsync(x => x.Id == id);
            return type == null ? null : type;
        }

        public async Task<IEnumerable<PaymentMethod>> GetPaymentMethodsAsync()
        {
            var methods = await dc.PaymentMethods.ToListAsync();
            return methods == null ? null : methods;
        }

        public async Task<PaymentMethod> GetPaymentMethodAsync(int id)
        {
            var method = await dc.PaymentMethods.FirstOrDefaultAsync(x => x.Id == id);
            return method == null ? null : method;
        }

        public async Task<IEnumerable<Country>> GetCountriesAsync()
        {
            var countries = await dc.Countries.ToListAsync();
            return countries == null ? null : countries;
        }
        public async Task<Country> GetCountryAsync(int id)
        {
            var country = await dc.Countries.FirstOrDefaultAsync(x => x.Id == id);
            return country == null ? null : country;
        }

        /// <summary>
        /// To be implemented
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<int> CompleteTransaction()
        {
            throw new NotImplementedException();
        }
    }
}
