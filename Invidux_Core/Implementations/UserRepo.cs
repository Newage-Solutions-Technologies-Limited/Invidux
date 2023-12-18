using Invidux_Core.Helpers;
using Invidux_Core.Repository.Interfaces;
using Invidux_Data.Context;
using Invidux_Data.Dtos.Request;
using Invidux_Data.Dtos.Response;
using Invidux_Domain.Models;
using Invidux_Domain.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Invidux_Core.Repository.Implementations
{
    /// <summary>
    /// This repository takes care of user centric unit of work
    /// </summary>
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

        // Checks if a user with the provided userId exists in the system
        public async Task<bool> UserExists(string userId)
        {
            // Searches for a user with the given userId in the database
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);

            // Returns true if the user is found, false otherwise
            return user == null ? false : true;
        }

        // To return jwt
        // Authenticates a user based on provided username and password
        public async Task<LoginResponse> Authenticate(string userName, string password)
        {
            // Helper class for JWT operations
            var jwtHelper = new JWT(config);

            // Fetches the user based on provided username or email
            var user = await dc.AppUsers.FirstOrDefaultAsync(x => x.UserName == userName || x.Email == userName);

            // If user is not found, returns null
            if (user == null)
                return null;

            // Performs the password sign-in attempt
            var result = await _signInManager.PasswordSignInAsync(userName, password, isPersistent: false, lockoutOnFailure: false);

            // Logs user info to the console
            Console.WriteLine("User Info\n" + result.ToString());

            var response = new LoginResponse();

            // Checks if the password sign-in attempt succeeded
            if (result.Succeeded)
            {
                // Handles scenarios based on user status
                if (user.RegistrationStatus == StatusStrings.Verified)
                {
                    // Creates JWT token for the user
                    response.UserId = user.Id;
                    response.Email = user.Email;
                    response.Username = user.UserName;
                    response.RegistrationStatus = user.RegistrationStatus;
                    response.Token = jwtHelper.CreateJWT(user);

                    return response;
                }

                if (user.RegistrationStatus == StatusStrings.Restricted)
                {
                    // Returns response for a restricted user
                    response.UserId = user.Id;
                    response.Email = user.Email;
                    response.Username = user.UserName;
                    response.RegistrationStatus = user.RegistrationStatus;
                    return response;
                }
            }

            // Handles Two-Factor Authentication scenarios
            if (result.RequiresTwoFactor)
            {
                // Handles scenarios based on user status for Two-Factor Authentication
                if (user.RegistrationStatus == StatusStrings.Verified)
                {
                    // Generates and sends a verification token for Two-Factor Authentication
                    var token = new SecurityToken
                    {
                        // Creates a verification token with expiration
                        // Saves the token in the database and sends it via email
                        UserId = user.Id,
                        Email = user.Email,
                        SecurityType = SecurityTypeStrings.TwoFactorVerification,
                        Otp = TokenGenerator.GetUniqueKey(6),
                        CreatedOn = DateTime.UtcNow,
                        ExpiresOn = DateTime.UtcNow.AddMinutes(10)
                    };

                    // Adds the token to the database
                    dc.SecurityTokens.Add(token);
                    await dc.SaveChangesAsync();
                    string subject = "Verify login";
                    string message = $"<p>Your login confirmation token <span>{token.Otp}</span> expires in 10 minutes.</p>";
                    // Sends an email with the verification token
                    await _emailSender.SendEmailAsync(user.Email, subject, message);

                    // Prepares the response with necessary user info for Two-Factor Authentication
                    response.UserId = user.Id;
                    response.Email = user.Email;
                    response.Username = user.UserName;
                    response.RegistrationStatus = user.RegistrationStatus;
                    response.TwoFactorEnabled = user.TwoFactorEnabled;

                    return response;
                }

                if (user.RegistrationStatus == StatusStrings.Restricted)
                {
                    // Returns response for a restricted user during Two-Factor Authentication
                    response.UserId = user.Id;
                    response.Email = user.Email;
                    response.Username = user.UserName;
                    response.RegistrationStatus = user.RegistrationStatus;
                    return response;
                }
            }

            // Returns null for any other scenarios not covered
            return null;
        }


        // Verifies the provided OTP (One-Time Password)
        public async Task<LoginResponse> VerifyOtp(int otp, string email)
        {
            // Find the OTP in the database
            var existingToken = await dc.SecurityTokens.SingleOrDefaultAsync(t => t.Otp == otp);
            var jwtHelper = new JWT(config);

            if (existingToken != null)
            {
               if(existingToken.Email == email)
                {
                    // Check if the token has not expired
                    if (existingToken.ExpiresOn >= DateTime.UtcNow)
                    {
                        // If the token type is for Two-Factor Verification
                        if (existingToken.SecurityType == SecurityTypeStrings.TwoFactorVerification)
                        {
                            // Retrieve the user associated with the token
                            var user = await _userManager.FindByIdAsync(existingToken.UserId);

                            // If the user is found
                            if (user != null)
                            {
                                var response = new LoginResponse();

                                // If user status is active, create JWT token for user
                                if (user.RegistrationStatus == StatusStrings.Verified)
                                {
                                    // Prepare the response with user information and JWT token
                                    response.UserId = user.Id;
                                    response.Email = user.Email;
                                    response.Username = user.UserName;
                                    response.RegistrationStatus = user.RegistrationStatus;
                                    response.Token = jwtHelper.CreateJWT(user);

                                    // Delete the used OTP record from the database
                                    dc.SecurityTokens.Remove(existingToken);
                                    await dc.SaveChangesAsync();
                                    return response;
                                }
                                // If user status is restricted, return response without JWT token
                                else if (user.RegistrationStatus == StatusStrings.Restricted)
                                {
                                    // Prepare the response without a JWT token
                                    response.UserId = user.Id;
                                    response.Email = user.Email;
                                    response.Username = user.UserName;
                                    response.RegistrationStatus = user.RegistrationStatus;

                                    // Delete the used OTP record from the database
                                    dc.SecurityTokens.Remove(existingToken);
                                    await dc.SaveChangesAsync();
                                    return response;
                                }
                            }
                            // If user not found, delete the OTP record from the database
                            dc.SecurityTokens.Remove(existingToken);
                            await dc.SaveChangesAsync();

                            return null;
                        }
                        return null; // Return null for non-Two-Factor Verification tokens
                    }
                    return null; // Return null if the OTP has expired
                }
               throw new Exception("Invalid account");
            }

            return null; // Return null if the OTP does not exist in the database
        }

        // Retrieves a user's complete profile information based on their ID
        public async Task<AppUser> GetUserProfile(string id)
        {
            // Queries the database to fetch user details including related entities
            AppUser user = await _userManager.Users
                .Include(a => a.NextOfKin)
                .Include(a => a.Income)
                .Include(a => a.Address)
                .Include(a => a.Kyc)
                .Include(a => a.TwoFactorCovers)
                .AsSingleQuery()
                .FirstOrDefaultAsync(a => a.Id == id);

            // Checks if the user exists and returns the user profile or null if not found
            if (user == null)
            {
                return null;
            }
            return user;
        }


        // Retrieves specific user information based on the provided userId
        public async Task<UserInfo> GetUserInfo(string userId)
        {
            // Queries the database to retrieve user-specific information
            var userInfo = await dc.UserInformation.Where(dc => dc.UserId == userId).FirstOrDefaultAsync();

            // Returns user information or null if not found
            return userInfo == null ? null : userInfo;
        }

        // Retrieves specific user kyc information based on the provided userId
        public async Task<UserKycInfo> GetKycInfo(string userId)
        {
            // Queries the database to retrieve user-specific kyc information
            var kycInfo = await dc.UserKycInfos.Where(dc => dc.UserId == userId).FirstOrDefaultAsync();

            // Returns user kyc information or null if not found
            return kycInfo == null ? null : kycInfo;
        }

        public async Task<KycIdCard> GetIdType(int id)
        {
            var idType = await dc.IdCards.FirstOrDefaultAsync(i => i.Id == id);
            return idType == null ? null : idType;
        }

        // Adds a new next-of-kin record to the database
        public void CreateNextOfKin(UserNextOfKin kin)
        {
            // Adds the provided next-of-kin entity to the context for insertion
            dc.UserNextOfKins.Add(kin);
        }

        // Retrieves the next-of-kin information for a specific user
        public async Task<UserNextOfKin> GetUserNextOfKin(string userId)
        {
            // Queries the database to retrieve the next-of-kin information for the user
            var nextOfKin = await dc.UserNextOfKins.Where(dc => dc.UserId == userId).FirstOrDefaultAsync();

            // Returns the next-of-kin information or null if not found
            return nextOfKin == null ? null : nextOfKin;
        }

        /// <summary>
        /// Currently only creating
        /// To be updated later
        /// </summary>
        /// <param name="securityDto"></param>
        /// <returns></returns>
        public async Task<bool> UpdateSecurity(SecurityDto securityDto)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == securityDto.UserId);
            if (user == null) return false;
            user.TwoFactorEnabled = securityDto.TwofactorEnabled;
            user.TwoFactorType = securityDto.TwoFactorType;
            foreach(var twofactorCover in securityDto.TwofactorCovers)
            {
                var _twoFactor = await dc.TwoFactorCovers.FirstOrDefaultAsync(t => t.Type == twofactorCover);
                var newCover = new UserTwoFactorCover
                {
                    UserId = securityDto.UserId,
                    TwoFactorCoverId = _twoFactor.Id,
                };
                dc.UserTwoFactorCovers.Add(newCover);
            }
            await dc.SaveChangesAsync();
            return true;

        }
    }
}
