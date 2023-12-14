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

           
            //============================Post mappings==================================

            // User Personal Information Request
            CreateMap<UserInfo, PersonalInfoDto>().ReverseMap();

            // User Next of Kin Request
            CreateMap<UserNextOfKin, NextOfKinDto>().ReverseMap();

            // User KYC Request
            CreateMap<UserKycInfo, KYCRequest>().ReverseMap();
        }
    }
}
