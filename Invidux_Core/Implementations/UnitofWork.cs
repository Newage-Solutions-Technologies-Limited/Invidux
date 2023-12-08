using Invidux_Data.Context;
using Invidux_Core.Repository.Interfaces;
using Invidux_Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Invidux_Core.Repository.Implementations
{
    public class UnitofWork: IUnitofWork
    {
        private readonly InviduxDBContext dc;

        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;

        public UnitofWork(InviduxDBContext dc, UserManager<AppUser> _userManager, RoleManager<IdentityRole> _roleManager, SignInManager<AppUser> _signInManager)
        {
            this.dc = dc;
            this._userManager = _userManager;
            this._roleManager = _roleManager;
            this._signInManager = _signInManager;
        }

        public IRegistrationRepo RegistrationRepo =>
            new RegistrationRepo(dc, _userManager, _roleManager);

        public IUserRepo UserRepo =>
            new UserRepo(dc, _signInManager);

        public async Task<bool> SaveAsync()
        {
            return await dc.SaveChangesAsync() > 0;
        }
    }
}
