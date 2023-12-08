using Invidux_Domain.Models;
using Microsoft.AspNetCore.Identity;
using System.Text.RegularExpressions;

namespace Invidux_Core.Helpers
{
    public class CustomValidator : UserValidator<AppUser>
    {
        public override async Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user)
        {
            var errors = new List<IdentityError>();

            // Perform your custom validation logic here
            // For example, you might want to skip validating the username if it's null or empty

            if (!string.IsNullOrWhiteSpace(user.UserName) && !IsValidUserName(user.UserName))
            {
                errors.Add(new IdentityError
                {
                    Description = "Username is invalid."
                });
            }

            // Add any other custom validations here

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
            var regex = new Regex("^[a-zA-Z0-9_@]+$");

            // Check the length of the username
            int minLength = 3; // minimum length
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
