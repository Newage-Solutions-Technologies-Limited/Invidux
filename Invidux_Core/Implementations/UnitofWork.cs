using Invidux_Data.Context;
using Invidux_Core.Repository.Interfaces;
using Invidux_Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Invidux_Core.Interfaces;
using Invidux_Core.Implementations;
using Invidux_Domain.Utilities;
using AutoMapper;

namespace Invidux_Core.Repository.Implementations
{
    public class UnitofWork: IUnitofWork
    {
        private readonly InviduxDBContext dc;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly IConfiguration config;
        private readonly IMapper mapper;

        public UnitofWork(
            InviduxDBContext dc, 
            RoleManager<AppRole> _roleManager,
            UserManager<AppUser> _userManager, 
            SignInManager<AppUser> _signInManager,
            IEmailSender _emailSender,
            IConfiguration config,
            IMapper mapper)
        {
            this.dc = dc;
            this._roleManager = _roleManager;
            this._userManager = _userManager;
            this._signInManager = _signInManager;
            this._emailSender = _emailSender;
            this.config = config;
            this.mapper = mapper;
        }

        public IPortfolioRepo PortfolioRepo =>
            new PortfolioRepo(dc);

        public IRegistrationRepo RegistrationRepo =>
            new RegistrationRepo(dc, _userManager, _emailSender);

        public IUserRepo UserRepo =>
            new UserRepo(dc, _userManager, _signInManager, config, _emailSender);

        public IUtitlityRepo UtitlityRepo =>
            new UtilityRepo(dc, _roleManager);

        public IWalletRepo WalletRepo =>
            new WalletRepo(config, dc, mapper, _emailSender);

        public async Task<bool> SaveAsync()
        {
            return await dc.SaveChangesAsync() > 0;
        }
        public async Task<int> ValidateOtp(int otp, string email)
        {
            var securityToken = await dc.SecurityTokens.SingleOrDefaultAsync(t => t.Otp == otp || t.Email == email );
            if (securityToken == null)
            {
                return 0;
            }

            if (securityToken.Otp != otp)
            {
                var user = await _userManager.FindByIdAsync(securityToken.UserId);
                if (securityToken.OtpAttemptCount == 0)
                {
                    user.RegistrationStatus = StatusStrings.Restricted;
                    await _userManager.UpdateAsync(user);
                    dc.SecurityTokens.Remove(securityToken);
                }
                else
                {
                    securityToken.OtpAttemptCount -= 1;
                    dc.SecurityTokens.Update(securityToken);
                }

                await dc.SaveChangesAsync();
                return -1;
            }
            return 1;
        }

        /// <summary>
        /// Usage:
        /// CancellationTokenSource cts = new CancellationTokenSource();
        ///
        /// await uow.AuditSaveAsync(cts.Token);
        ///
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>

        public async Task<bool> AuditSaveAsync(CancellationToken cancellationToken = default)
        {
            return await dc.SaveChangesAsync(cancellationToken) > 0;
        }

    }
}
