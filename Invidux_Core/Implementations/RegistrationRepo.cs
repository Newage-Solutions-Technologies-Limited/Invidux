﻿using Invidux_Data.Context;
using Invidux_Data.Dtos.Request;
using Invidux_Core.Helpers;
using Invidux_Core.Repository.Interfaces;
using Invidux_Domain.Models;
using Invidux_Domain.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Invidux_Data.Dtos.Response;
using Microsoft.AspNetCore.Identity.UI.Services;
using static System.Net.WebRequestMethods;

namespace Invidux_Core.Repository.Implementations
{
    /// <summary>
    /// This repository takes care of registration unit of work
    /// </summary>
    public class RegistrationRepo: IRegistrationRepo
    {
        private readonly InviduxDBContext dc;
        private readonly UserManager<AppUser> _userManager;
        private readonly IEmailSender _emailSender;
        public RegistrationRepo(InviduxDBContext dc, UserManager<AppUser> _userManager, IEmailSender _emailSender)
        {
            this.dc = dc;
            this._userManager = _userManager;
            this._emailSender = _emailSender;
        }

        // Checks if a user with the provided userId exists in the system
        public async Task<string> UserAlreadyExists(string email)
        {
            // Searches for a user with the given userId in the database
            var userExists = await _userManager.FindByEmailAsync(email);

            // Returns the user status if user exists
            if (userExists != null)
            {
                return userExists.RegistrationStatus;

            }
            // Returns null if the user doesn't exist
            return null;
        }

        // This unit of work takes care of user registration
        public async Task<UserRegistrationDto> Register(RegistrationDTO user)
        {
            var newUser = new AppUser
            {
                Email = user.Email,
                UserName = user.Email ,
                RegistrationStatus = StatusStrings.Pending,
                OtpSentCount = 5,
                RegistrationDate = DateTime.UtcNow,
            };
            newUser.EmailConfirmed = false;
            var result = await _userManager.CreateAsync(newUser, user.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    Console.WriteLine(error.Description);
                }
                return null;
            }
            await _userManager.AddToRoleAsync(newUser, RoleStrings.Investor);

            var token = new SecurityToken
            {
                UserId = newUser.Id,
                Email = newUser.Email ,
                SecurityType = SecurityTypeStrings.UserRegistration,
                Otp = TokenGenerator.GetUniqueKey(6)
            };
            dc.SecurityTokens.Add(token);
            await dc.SaveChangesAsync();
            string subject = "Confirm your email";
            string message = $"<p>Your email confirmation token <span>{token.Otp}</span> expires in 1 hour.</p>";
            await _emailSender.SendEmailAsync(newUser.Email, subject, message);
            var response = new UserRegistrationDto
            {
                Id = newUser.Id,
                Status = newUser.RegistrationStatus,
                Email = newUser.Email,
                Role = RoleStrings.Investor,
                //Otp = token.Otp,
                CreatedAt = newUser.RegistrationDate,
                OtpAllowance = newUser.OtpSentCount,
            };

            return response;
        }

        // This unit of work takes care of user email verifation
        public async Task<string> VerifyOtp(int otp, string email)
        {
            var existingToken = await dc.SecurityTokens.SingleOrDefaultAsync(t => t.Otp == otp);
            if (existingToken == null)
            {
                // Return null if the OTP does not exist
                throw new Exception("Invalid otp");
            }
            if (existingToken.Email == email)
            {
                // Check if the token has not expired
                if (existingToken.ExpiresOn >= DateTime.UtcNow)
                {

                    if (existingToken.SecurityType == SecurityTypeStrings.UserRegistration)
                    {
                        // Set email verification to true for the user
                        var user = await _userManager.FindByIdAsync(existingToken.UserId);
                        if (user != null)
                        {
                            if (user.RegistrationStatus == StatusStrings.Pending)
                            {
                                user.EmailConfirmed = true;
                                user.RegistrationStatus = StatusStrings.Verified;
                                user.OtpSentCount = 5;
                                user.UpdatedAt = DateTime.UtcNow;
                                await _userManager.UpdateAsync(user);
                            }

                            // Delete the OTP record from the database
                            dc.SecurityTokens.Remove(existingToken);
                            await dc.SaveChangesAsync();

                            return user.RegistrationStatus;
                        }

                        return null;
                    }
                    return null;
                }
                dc.SecurityTokens.Remove(existingToken);
                await dc.SaveChangesAsync();
                // Throw exception if the OTP has expired
                throw new Exception("Otp has expired");
            }
            throw new Exception("Invalid account");
        }

        // This unit of work takes care of verifation otp request
        public async Task<int> ResendOtp(string email)
        {
            string subject = "Confirm your email";
            string message;
            var user = await _userManager.FindByEmailAsync(email );
            var existingToken = await dc.SecurityTokens
                .Where(st => 
                    st.SecurityType == SecurityTypeStrings.UserRegistration)
                .FirstOrDefaultAsync(st => st.Email == email);

            if (user != null)
            {
                if(user.RegistrationStatus == StatusStrings.Pending)
                {
                    // Check if the user's otpsentcount is not 0
                    if (user.OtpSentCount != 0)
                    {
                        if(existingToken != null)
                        {
                            if(existingToken.OtpAttemptCount != 0)
                            {
                                existingToken.Otp = TokenGenerator.GetUniqueKey(6);
                                existingToken.OtpAttemptCount -= 1;
                                existingToken.ExpiresOn = DateTime.UtcNow.AddMinutes(60);
                                dc.SecurityTokens.Update(existingToken);                                
                                message = $"<p>Your email confirmation token <span>{existingToken.Otp}</span> expires in 1 hour.</p>";
                                await _emailSender.SendEmailAsync(email, subject, message);
                            }
                            else
                            {
                                dc.SecurityTokens.Remove(existingToken);
                                user.RegistrationStatus = StatusStrings.Restricted;
                                await _userManager.UpdateAsync(user); 
                                await dc.SaveChangesAsync();
                                return -1;
                            }
                        }
                        else
                        {
                            // Generate a new OTP
                            var token = new SecurityToken
                            {
                                UserId = user.Id,
                                Email = email,
                                SecurityType = SecurityTypeStrings.UserRegistration,
                                Otp = TokenGenerator.GetUniqueKey(6)
                            };
                            dc.SecurityTokens.Add(token);
                            message = $"<p>Your email confirmation token <span>{token.Otp}</span> expires in 1 hour.</p>";
                            await _emailSender.SendEmailAsync(email, subject, message);
                        }
                        // Update the user's OTP-related properties
                        user.OtpSentCount -= 1; // Subtract otpcount

                        // Save the changes to the user
                        var result = await _userManager.UpdateAsync(user);
                        await dc.SaveChangesAsync();

                        if (result.Succeeded)
                        {
                            await dc.SaveChangesAsync(); // Save changes to the database
                            return 1;
                        }
                        else
                        {
                            // Handle the case when updating the user fails
                            // You can return an error code or throw an exception as needed
                            throw new Exception("User not found or no OTP generated");
                        }
                    }
                    else
                    {
                        user.RegistrationStatus = StatusStrings.Restricted;
                        var result = await _userManager.UpdateAsync(user);

                        if (!result.Succeeded)
                        {
                            // Handle the case when updating the user fails
                            // You can return an error code or throw an exception as needed
                            throw new Exception("User not found or no OTP generated");
                        }
                        return -1;
                    }
                }
                else if (user.RegistrationStatus == StatusStrings.Restricted)
                {
                    return -1;
                }
            }
            else
            {
                throw new Exception("User not found or no OTP generated");
            }

            // Default return value if no OTP was generated or user not found
            throw new Exception("User not found or no OTP generated");
        }

        // This unit of work takes care of user registration completion
        public async Task<UserRegistrationDto> CompleteRegistration(CompleteRegistration user)
        {
            // Find the existing user by their username or other unique identifier
            var existingUser = await _userManager.FindByEmailAsync(user.Email );

            if (existingUser != null)
            {
                // Perform validation on the user object
                var validationResults = new List<ValidationResult>();
                var isValid = Validator.TryValidateObject(user, new ValidationContext(user), validationResults, true);

                if (isValid)
                {
                    // Update the existing user's profile based on the CompleteRegistration data

                    var subRole = await dc.SubRoles.FirstAsync(sr => sr.Name == SubRolesStrings.Retail);
                    existingUser.UserName = user.Username;
                    existingUser.PhoneNumber = user.Phone;
                    existingUser.OtpSentCount = 5;
                    existingUser.UpdatedAt = DateTime.UtcNow;

                    // Update the user's profile using the UserManager
                    var result = await _userManager.UpdateAsync(existingUser);

                    if (result.Succeeded)
                    {
                        var userInfo = new UserInfo
                        {
                            FirstName = user.FirstName,
                            MiddleName = user.MiddleName,
                            LastName = user.LastName,
                            UserId = existingUser.Id,
                            // Assuming uploadedFile is an array or a list
                            //ImageName = uploadedFile?[0] ?? "",
                            CreatedAt = DateTime.UtcNow,
                        };
                        var userSubRole = new UserSubRole
                        {
                            UserId = existingUser.Id,
                            SubRoleId = subRole.Id,
                        };
                        var userAddress = new UserAddress
                        {
                            UserId = existingUser.Id,
                            CreatedAt = DateTime.UtcNow,
                            CountryId = user.CountryId
                        };

                        var kycInfo = new UserKycInfo
                        {
                            UserId = existingUser.Id,
                            Level = KycLevelStrings.Level1,
                            Status = KycStatusStrings.Pending,
                            CreatedAt = DateTime.UtcNow
                        };
                        var wallet = new Wallet
                        {
                            Id = Guid.NewGuid().ToString(),
                            Active = false,
                            PinSet = false,
                            WalletPin = 0,
                            UserId = existingUser.Id
                        };
                        dc.Wallets.Add(wallet);
                        dc.UserKycInfos.Add(kycInfo);
                        dc.UserAddresses.Add(userAddress);
                        dc.UserSubRoles.Add(userSubRole);
                        dc.UserInformation.Add(userInfo);
                        await dc.SaveChangesAsync();
                        var response = new UserRegistrationDto
                        {
                            Id = existingUser.Id,
                            Role = RoleStrings.Investor,
                            SubRole = userSubRole.SubRole.Name,
                            Username = existingUser.UserName,
                            Status = existingUser.RegistrationStatus,
                            Email = existingUser.Email,
                            FirstName = userInfo.FirstName,
                            LastName = userInfo.LastName,
                            CreatedAt = existingUser.RegistrationDate,
                            OtpAllowance = existingUser.OtpSentCount,
                            WalletActivated = wallet.Active,
                            HasTokenHistory = false,
                            HoldingToken = false
                        };
                        return response;
                    }
                    else
                    {
                        // Handle update failure (e.g., return error messages)
                        throw new Exception("Failed to update account.");
                    }
                }
                else
                {
                    // Handle validation errors (e.g., return validation error messages)
                    // You can access the validationResults to get error details
                    throw new Exception("Invalid information provided");
                }
            }
            else
            {                
                return null;
            }
        }

    }
}
