using Microsoft.AspNetCore.Identity;
using Invidux_Domain.Models;
using System.Text.RegularExpressions;

namespace Invidux_Core.Helpers
{
    public class CustomUsernamePolicy : UserValidator<AppUser>
    {
        public override async Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user)
        {
            IdentityResult result = await base.ValidateAsync(manager, user);
            List<IdentityError> errors = result.Succeeded ? new List<IdentityError>() : result.Errors.ToList();

            if (user.UserName == "google")
            {
                errors.Add(new IdentityError
                {
                    Description = "Google cannot be used as a user name"
                });
            }

            if (!string.IsNullOrWhiteSpace(user.UserName) && !IsValidUserName(user.UserName))
            {
                errors.Add(new IdentityError
                {
                    Description = "Username is invalid."
                });
            }
            if (errors.Count > 0)
            {
                return IdentityResult.Failed(errors.ToArray());
            }
            return await base.ValidateAsync(manager, user);
        }
        private bool IsValidUserName(string userName)
        {
            // Check if the username is null or empty
            if (string.IsNullOrWhiteSpace(userName))
            {
                return false;
            }

            // Define a regular expression for allowed username (modify as needed)
            // For example, this regex allows letters, digits, and underscores
            var regex = new Regex("^[a-zA-Z0-9_@.]+$");

            // Check the length of the username
            int minLength = 8; // minimum length
            int maxLength = 15; // maximum length
            if (userName.Length < minLength || userName.Length > maxLength)
            {
                return false;
            }

            // Check if the username matches the regular expression
            return regex.IsMatch(userName);
        }
    }
}
