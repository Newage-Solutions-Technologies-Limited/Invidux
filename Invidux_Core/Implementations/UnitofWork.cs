﻿using Invidux_Data.Context;
using Invidux_Core.Repository.Interfaces;
using Invidux_Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;

namespace Invidux_Core.Repository.Implementations
{
    public class UnitofWork: IUnitofWork
    {
        private readonly InviduxDBContext dc;

        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly IConfiguration config;

        public UnitofWork(
            InviduxDBContext dc, 
            UserManager<AppUser> _userManager, 
            SignInManager<AppUser> _signInManager,
            IEmailSender _emailSender,
            IConfiguration config)
        {
            this.dc = dc;
            this._userManager = _userManager;
            this._signInManager = _signInManager;
            this._emailSender = _emailSender;
            this.config = config;
        }

        public IRegistrationRepo RegistrationRepo =>
            new RegistrationRepo(dc, _userManager, _emailSender);

        public IUserRepo UserRepo =>
            new UserRepo(dc, _userManager, _signInManager, config, _emailSender);

        public async Task<bool> SaveAsync()
        {
            return await dc.SaveChangesAsync() > 0;
        }
    }
}