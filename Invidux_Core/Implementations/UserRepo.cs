using Invidux_Data.Context;
using Invidux_Core.Repository.Interfaces;
using Invidux_Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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
        public async Task<AppUser> Authenticate(string userName, string password)
        {
            var user = await dc.AppUsers.FirstOrDefaultAsync(x => x.Email == userName || x.UserName == userName);
            if (user == null)
                return null;
            var result = await _signInManager.PasswordSignInAsync(userName, password, isPersistent: false, lockoutOnFailure: false);
            if (!result.Succeeded)
                return null;

            return user;
        }
    }
}
