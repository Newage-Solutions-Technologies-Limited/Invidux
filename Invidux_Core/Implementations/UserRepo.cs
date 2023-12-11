﻿using Invidux_Data.Context;
using Invidux_Core.Repository.Interfaces;
using Invidux_Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Invidux_Data.Dtos.Request;
using Invidux_Data.Dtos.Response;
using Invidux_Domain.Utilities;
using Invidux_Core.Helpers;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace Invidux_Core.Repository.Implementations
{
    public class UserRepo: IUserRepo
    {
        private readonly InviduxDBContext dc;

        private readonly UserManager<AppUser> _userManager;
        //private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration config;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IEmailSender _emailSender;

        public UserRepo(
            InviduxDBContext dc, 
            UserManager<AppUser> _userManager, 
            SignInManager<AppUser> _signInManager, 
            IConfiguration config,
            IEmailSender _emailSender)
        {
            this.dc = dc;
            this.config = config;
            this._userManager = _userManager;
            this._signInManager = _signInManager;
            this._emailSender = _emailSender;
        }

        // To return jwt
        public async Task<LoginResponse> Authenticate(string userName, string password)
        {
            var jwtHelper = new JWT(config);
            var user = await dc.AppUsers.FirstOrDefaultAsync(x => x.UserName == userName || x.Email == userName);
            if (user == null)
                return null;
            var result = await _signInManager.PasswordSignInAsync(userName, password, isPersistent: false, lockoutOnFailure: false);
            Console.WriteLine("User Info\n" + result.ToString());
            
            var response = new LoginResponse();
            if (result.Succeeded)
            {
                if (user.Status == RegistrationStatus.Active)
                {
                    response.UserId = user.Id;
                    response.Email = user.Email;
                    response.Username = user.UserName;
                    response.Status = user.Status;
                    response.Token = jwtHelper.CreateJWT(user);

                    return response;
                }

                if (user.Status == RegistrationStatus.Restricted)
                {
                    response.UserId = user.Id;
                    response.Email = user.Email;
                    response.Username = user.UserName;
                    response.Status = user.Status;
                    return response;
                }
            }
            if (result.RequiresTwoFactor)
            {
                
                if (user.Status == RegistrationStatus.Active)
                {
                    var token = new VerificationToken
                    {
                        UserId = user.Id,
                        Email = user.Email,
                        Type = VerificationType.TwoFactorVerification,
                        Otp = TokenGenerator.GetUniqueKey(6),
                        CreatedOn = DateTime.UtcNow,
                        ExpiresOn = DateTime.UtcNow.AddMinutes(10)
                    };
                    dc.VerificationTokens.Add(token);
                    await dc.SaveChangesAsync();
                    string subject = "Verify login";
                    string message = $"<p>Your login confirmation token <span>{token.Otp}</span> expires in 10 minutes.</p>";
                    await _emailSender.SendEmailAsync(user.Email, subject, message);
                    response.UserId = user.Id;
                    response.Email = user.Email;
                    response.Username = user.UserName;
                    response.Status = user.Status;
                    response.TwoFactorEnabled = user.TwoFactorEnabled;
                    //response.Otp = token.Otp;
                    return response;
                }

                if (user.Status == RegistrationStatus.Restricted)
                {
                    response.UserId = user.Id;
                    response.Email = user.Email;
                    response.Username = user.UserName;
                    response.Status = user.Status;
                    return response;
                }
            }
            

            return null;
        }

        public async Task<LoginResponse> VerifyOtp(int otp)
        {
            // Find the OTP in the database
            var existingToken = await dc.VerificationTokens.SingleOrDefaultAsync(t => t.Otp == otp);
            var jwtHelper = new JWT(config);


            if (existingToken != null)
            {
                // Check if the token has not expired
                if (existingToken.ExpiresOn >= DateTime.UtcNow)
                {

                    if (existingToken.Type == VerificationType.TwoFactorVerification)
                    {
                        // Set email verification to true for the user
                        var user = await _userManager.FindByIdAsync(existingToken.UserId);
                        if (user != null)
                        {
                            var response = new LoginResponse();
                            if (user.Status == RegistrationStatus.Active)
                            {
                                response.UserId = user.Id;
                                response.Email = user.Email;
                                response.Username = user.UserName;
                                response.Status = user.Status;
                                response.Token = jwtHelper.CreateJWT(user);

                                // Delete the OTP record from the database
                                dc.VerificationTokens.Remove(existingToken);
                                await dc.SaveChangesAsync();
                                return response;
                            }

                            else if (user.Status == RegistrationStatus.Restricted)
                            {
                                response.UserId = user.Id;
                                response.Email = user.Email;
                                response.Username = user.UserName;
                                response.Status = user.Status;

                                // Delete the OTP record from the database
                                dc.VerificationTokens.Remove(existingToken);
                                await dc.SaveChangesAsync();
                                return response;
                            }

                        }
                        // Delete the OTP record from the database
                        dc.VerificationTokens.Remove(existingToken);
                        await dc.SaveChangesAsync();

                        return null;
                    }
                    return null;
                }
                // Return null if the OTP has expired
                return null;
            }

            // Return null if the OTP does not exist
            return null;
        }
    }
}
