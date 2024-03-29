﻿using Invidux_Domain.Models;
using Invidux_Data.Dtos.Request;
using Invidux_Data.Dtos.Response;

namespace Invidux_Core.Repository.Interfaces
{
    public interface IUserRepo
    {
        Task<bool> UserExists(string userId);
        bool IsValidEmail(string email);
        Task<LoginResponse> Authenticate(string userName, string password);
        Task<LoginResponse> VerifyOtp(int otp, string email);
        Task<AppUser> GetUserProfile(string userId);
        Task<UserInfo> GetUserInfo(string userId);
        Task<UserKycInfo> GetKycInfo(string userId);
        Task<KycIdCard> GetIdType(int id);
        void CreateNextOfKin(UserNextOfKin kin);
        Task<UserNextOfKin> GetUserNextOfKin (string userId);
        Task<bool> UpdateSecurity(SecurityDto securityDto, string userId);
    }
}
