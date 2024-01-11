using AutoMapper;
using Invidux_Data.Dtos.Request;
using Invidux_Data.Dtos.Response;
using Invidux_Domain.Models;
using Invidux_Domain.Utilities;

namespace Invidux_Data.Dtos.AutoMapping
{
    public class Mapping : Profile
    {
        public Mapping() 
        {
            // ====================================Get Mappings=====================================
            // User to UserProfileDto mapping
            CreateMap<AppUser, UserProfileDto>()
                .ForMember(dest => dest.Contact, opt => opt.MapFrom(src => src.Personal))
                .ForMember(dest => dest.Income, opt => opt.MapFrom(src => src.Income))
                .ForMember(dest => dest.InvestmentLimit, opt => opt.MapFrom(src => new InvestmentLimit
                {
                    LimitUsed = src.Income.InvestmentLimitUsed,
                    RemainingAllowance = src.Income.RemainingAllowance
                }))
                .ForMember(dest => dest.KYC, opt => opt.MapFrom(src => src.Kyc))
                .ForMember(dest => dest.Security, opt => opt.MapFrom(src => new Security
                {
                    TwoFactorEnabled = src.TwoFactorType != TwoFactorTypeStrings.Email,
                    TwoFactorType = src.TwoFactorType,
                    TwoFactorCovers = src.TwoFactorCovers
                        .Where(ufc => ufc.UserId == src.Id) 
                        .Select(ufc => ufc.TwoFactorCover.Type).ToList()
                }));


            // UserAddress to Address mapping
            CreateMap<UserAddress, Address>()
                .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.Country.Name));

            // UserIncomeInfo to IncomeInfo mapping
            CreateMap<UserIncomeInfo, IncomeInfo>();

            // UserKycInfo to KYC mapping
            CreateMap<UserKycInfo, KYC>();

            // UserNextOfKin to NextOfKin mapping
            CreateMap<UserNextOfKin, NextOfKin>();

            CreateMap<TwoFactorCover, string>() 
                .ConvertUsing(src => src.Type);

            /****************************Utility Get Mappings**************************/
            CreateMap<Country, CountryResponse>();
            CreateMap<InvestmentType, InvestmentTypeDto>();
            CreateMap<KycIdCard, KycIdCardDto>();
            CreateMap<KycLevel,  KycLevelDto>();
            CreateMap<KycStatus, KycStatusDto>();
            CreateMap<PaymentMethod, PaymentMethodDto>();
            CreateMap<PropertyClass, PropertyClassDto>();
            CreateMap<AppRole, RoleDto>()
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Name));
            CreateMap<SecurityType, SecurityTypeDto>();
            CreateMap<SubRole, SubRoleDto>()
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.Name));
            CreateMap<TokenListingStatus, TokenListingStatusDto>();
            CreateMap<TokenTransactionType, TokenTransactionTypeDto>();
            CreateMap<TransactionType, TransactionTypeDto>();
            CreateMap<TwoFactorCover, TwoFactorCoverDto>();
            CreateMap<TwoFactorType, TwoFactorTypeDto>();

           
            //============================User Post mappings==================================

            // User Personal Information Request
            CreateMap<UserInfo, PersonalInfoDto>().ReverseMap();

            // User Next of Kin Request
            CreateMap<UserNextOfKin, NextOfKinDto>().ReverseMap();

            // User KYC Request
            CreateMap<UserKycInfo, KYCRequest>().ReverseMap();

            //============================Wallet mappings==================================

            // Mapping from Wallet (domain model) to WalletResponseDto (DTO)
            CreateMap<Wallet, WalletResponseDto>()
                .ForMember(dest => dest.Wallet, opt => opt.MapFrom(src => src));

            // Mapping from Wallet (domain model) to UserWalletDto (DTO)
            CreateMap<Wallet, UserWalletDto>()
                .ForMember(dest => dest.WalletId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Tokens, opt => opt.MapFrom(src => src.UserTokens));

            // Mapping from UserToken (domain model) to WalletTokenDto (DTO)
            CreateMap<UserToken, WalletTokenDto>()
                .ForMember(dest => dest.Balances, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.DepositVirtualAccount, opt => opt.MapFrom(src =>
                    src.BankAccounts.FirstOrDefault(ba => ba.AccountType == BankAccountTypeEnums.DepositVirtualAccount)))
                .ForMember(dest => dest.WithdrawalBankAccount, opt => opt.MapFrom(src =>
                    src.BankAccounts.FirstOrDefault(ba => ba.AccountType == BankAccountTypeEnums.WithdrawalBankAccount)));

            // Mapping from UserToken (domain model) to BalancesDto (DTO)
            CreateMap<UserToken, BalancesDto>();

            // Mapping for BankAccount to DepositAccountDto and WithdrawalAccountDto
            CreateMap<BankAccount, DepositAccountDto>();
            CreateMap<BankAccount, WithdrawalAccountDto>();

            // Mapping for transsactions
            CreateMap<Transaction, TransactionResponse>()
                .ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.CurrencySymbol))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.TransactionDate));


            CreateMap<Transaction, TransactionListResponse>()
                .ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.CurrencySymbol))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.TransactionDate));
            
            CreateMap<Wallet, AccountStatement>()
                .ForMember(dest => dest.TokenBalances, opt => opt.MapFrom(src => src.UserTokens));

            CreateMap<Transaction, AccountStatement>()
                .ForMember(dest => dest.Transactions, opt => opt.MapFrom(src => src));

            CreateMap<BankAccount, AccountResponseDto>()
                .ForMember(dest => dest.AccountId, opt => opt.MapFrom(src => src.Id));

            // Portfolio mappings

            // Mapping from UserToken to Inapp
            CreateMap<UserToken, Inapp>()
                .ForMember(dest => dest.TokenCount, opt => opt.MapFrom(src => src.BankAccounts.Count))
                .ForMember(dest => dest.TokenCodes, opt => opt.MapFrom(src => new string[] { src.TokenCode }))
                .ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.Currency))
                .ForMember(dest => dest.OwnedVolume, opt => opt.MapFrom(src => src.Available))
                // Other properties mapping
                ;

            // Mapping from UserToken to External
            CreateMap<UserToken, External>()
                .ForMember(dest => dest.TokenCount, opt => opt.MapFrom(src => src.StellarAccounts.Count))
                .ForMember(dest => dest.TokenCodes, opt => opt.MapFrom(src => new string[] { src.TokenCode }))
                .ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.Currency))
                .ForMember(dest => dest.OwnedVolume, opt => opt.MapFrom(src => src.Available))
                // Other properties mapping
                ;
        }
    }
}
