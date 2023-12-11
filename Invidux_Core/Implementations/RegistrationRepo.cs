using Invidux_Data.Context;
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

namespace Invidux_Core.Repository.Implementations
{
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

        public async Task<string> UserAlreadyExists(string email)
        {
            var userExists = await _userManager.FindByEmailAsync(email);
            if (userExists != null)
            {
                return userExists.Status.ToString();

            }
            return null;
        }

        public async Task<UserRegistrationDto> Register(RegistrationDTO user)
        {
            var newUser = new AppUser
            {
                Email = user.Email,
                UserName = user.Email,
                Status = RegistrationStatus.Pending,
                OtpSentCount = 5,
                RegistrationDate = DateTime.UtcNow,
            };
            newUser.EmailConfirmed = false;
            var result = await _userManager.CreateAsync(newUser);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    Console.WriteLine(error.Description);
                }
                return null;
            }
            await _userManager.AddToRoleAsync(newUser, Roles.Investor.ToString());

            var token = new VerificationToken
            {
                UserId = newUser.Id,
                Email = newUser.Email,
                Type = VerificationType.UserRegistration,
                Otp = TokenGenerator.GetUniqueKey(6),
                CreatedOn = DateTime.UtcNow,
                ExpiresOn = DateTime.UtcNow.AddMinutes(10)
            };
            dc.VerificationTokens.Add(token);
            await dc.SaveChangesAsync();
            string subject = "Confirm your email";
            string message = $"<p>Your email confirmation token <span>{token.Otp}</span> expires in 10 minutes.</p>";
            await _emailSender.SendEmailAsync(newUser.Email, subject, message);
            var response = new UserRegistrationDto
            {
                Id = newUser.Id,
                Status = newUser.Status,
                Email = newUser.Email,
                //Otp = token.Otp,
                RegistrationDate = newUser.RegistrationDate,
                OtpAllowance = newUser.OtpSentCount,
            };

            return response;
        }

        public async Task<string> VerifyOtp(int otp)
        {
            // Find the OTP in the database
            var existingToken = await dc.VerificationTokens.SingleOrDefaultAsync(t => t.Otp == otp);

            if (existingToken != null)
            {
                // Check if the token has not expired
                if (existingToken.ExpiresOn >= DateTime.UtcNow)
                {

                    if(existingToken.Type == VerificationType.UserRegistration)
                    {
                        // Set email verification to true for the user
                        var user = await _userManager.FindByIdAsync(existingToken.UserId);
                        if (user != null)
                        {
                            if (user.Status == RegistrationStatus.Pending)
                            {
                                user.EmailConfirmed = true;
                                user.Status = RegistrationStatus.Active;
                                await _userManager.UpdateAsync(user);
                            }

                            // Delete the OTP record from the database
                            dc.VerificationTokens.Remove(existingToken);
                            await dc.SaveChangesAsync();

                            return user.Status.ToString();
                        }

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



        public async Task<int> ResendOtp(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user != null)
            {
                if(user.Status == RegistrationStatus.Pending)
                {
                    // Check if the user's otpsentcount is not 0
                    if (user.OtpSentCount != 0)
                    {
                        // Generate a new OTP
                        var token = new VerificationToken
                        {
                            UserId = user.Id,
                            Email = email,
                            Type = VerificationType.UserRegistration,
                            Otp = TokenGenerator.GetUniqueKey(6),
                            CreatedOn = DateTime.UtcNow,
                            ExpiresOn = DateTime.UtcNow.AddMinutes(10)
                        };
                        dc.VerificationTokens.Add(token);
                        await dc.SaveChangesAsync();
                        string subject = "Confirm your email";
                        string message = $"<p>Your email confirmation token <span>{token.Otp}</span> expires in 10 minutes.</p>";
                        await _emailSender.SendEmailAsync(email, subject, message);
                        // Update the user's OTP-related properties
                        user.OtpSentCount -= 1; // Subtract otpcount

                        // Save the changes to the user
                        var result = await _userManager.UpdateAsync(user);

                        if (result.Succeeded)
                        {
                            await dc.SaveChangesAsync(); // Save changes to the database
                            return token.Otp;
                        }
                        else
                        {
                            // Handle the case when updating the user fails
                            // You can return an error code or throw an exception as needed
                            throw new Exception("User not found or no OTP generate");
                        }
                    }
                    else
                    {
                        user.Status = RegistrationStatus.Restricted;
                        var result = await _userManager.UpdateAsync(user);

                        if (!result.Succeeded)
                        {
                            // Handle the case when updating the user fails
                            // You can return an error code or throw an exception as needed
                            throw new Exception("User not found or no OTP generate");
                        }
                        return -1;
                    }
                }
                else if (user.Status == RegistrationStatus.Restricted)
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



        public async Task<bool> CompleteRegistration(CompleteRegistration user)
        {
            // Find the existing user by their username or other unique identifier
            var existingUser = await _userManager.FindByEmailAsync(user.Email);

            if (existingUser != null)
            {
                // Perform validation on the user object
                var validationResults = new List<ValidationResult>();
                var isValid = Validator.TryValidateObject(user, new ValidationContext(user), validationResults, true);

                if (isValid)
                {
                    // Update the existing user's profile based on the CompleteRegistration data

                    existingUser.UserName = user.Username;
                    existingUser.PhoneNumber = user.Phone; // If you're using phone number for registration
                    
                    // Update the user's profile using the UserManager
                    var result = await _userManager.UpdateAsync(existingUser);

                    

                    if (result.Succeeded)
                    {
                        await _userManager.AddPasswordAsync(existingUser, user.Password);
                        var userInfo = new UserInfo
                        {
                            FirstName = user.FirstName,
                            MiddleName = user.MiddleName,
                            LastName = user.LastName,
                            UserId = existingUser.Id
                        };
                        dc.UserInformation.Add(userInfo);
                        await dc.SaveChangesAsync();
                        return true;
                    }
                    else
                    {
                        // Handle update failure (e.g., return error messages)
                        throw new Exception("Registration failed.");
                    }
                }
                else
                {
                    // Handle validation errors (e.g., return validation error messages)
                    // You can access the validationResults to get error details
                    throw new Exception("Registration failed.");
                }
            }
            else
            {
                
                return false;
            }
        }

    }
}
