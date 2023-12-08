using Invidux_Data.Context;
using Invidux_Core.Repository.Interfaces;
using Invidux_Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Invidux_Data.Dtos.Request;
using Invidux_Data.Dtos.Response;
using Invidux_Domain.Utilities;
using Invidux_Core.Helpers;

namespace Invidux_Core.Repository.Implementations
{
    public class UserRepo: IUserRepo
    {
        private readonly InviduxDBContext dc;

        private readonly UserManager<AppUser> _userManager;
        //private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;

        public UserRepo(InviduxDBContext dc, SignInManager<AppUser> _signInManager)
        {
            this.dc = dc;
            this._signInManager = _signInManager;
        }

        // To return jwt
        public async Task<LoginResponse> Authenticate(string userName, string password)
        {
            var user = await dc.AppUsers.FirstOrDefaultAsync(x => x.Email == userName || x.UserName == userName);
            if (user == null)
                return null;
            var result = await _signInManager.PasswordSignInAsync(userName, password, isPersistent: false, lockoutOnFailure: false);
            if (!result.Succeeded)
                return null;
            var response = new LoginResponse();
            if(user.Status == RegistrationStatus.Active)
            {
                if (user.TwoFactorEnabled)
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
                    response.UserId = user.Id;
                    response.Email = user.Email;
                    response.Username = user.UserName;
                    response.Status = user.Status;
                    response.TwoFactorEnabled = user.TwoFactorEnabled;
                    response.Otp = token.Otp;
                    return response;
                }

                response.UserId = user.Id;
                response.Email = user.Email;
                response.Username = user.UserName;
                response.Status = user.Status;
                response.Token = JWT.CreateJWT(user);

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

            return null;
        }

        public async Task<LoginResponse> VerifyOtp(int otp)
        {
            // Find the OTP in the database
            var existingToken = await dc.VerificationTokens.SingleOrDefaultAsync(t => t.Otp == otp);

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
                                response.Token = JWT.CreateJWT(user);

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
