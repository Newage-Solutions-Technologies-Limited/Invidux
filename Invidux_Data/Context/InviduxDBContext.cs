﻿using Invidux_Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Invidux_Data.Context
{
    public class InviduxDBContext : IdentityDbContext
    {
        private readonly IUserContextService _userContextService;
        public InviduxDBContext(DbContextOptions<InviduxDBContext> options, IUserContextService userContextService)
            : base(options)
        {
            _userContextService = userContextService;   
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityUser>(entity =>
            {
                entity.ToTable(name: "Users");
            });

            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Roles");
            });

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Name = "SuperAdmin", NormalizedName = "SUPERADMIN" },
                new IdentityRole { Name = "Issuer", NormalizedName = "ISSUER" },
                new IdentityRole { Name = "Investor", NormalizedName = "INVESTOR" }
            );


            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles");
            });

            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims");
            });

            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins");
            });

            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims");

            });

            builder.Entity<TwoFactorCover>().HasData(
                new TwoFactorCover {Id = 1, Title = "Login" },
                new TwoFactorCover { Id = 2, Title = "Transaction" },
                new TwoFactorCover { Id = 3, Title = "Trading" }
            );
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TwoFactorCover> TwoFactorCovers { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<UserIncomeInfo> UserIncomeInfos { get; set; }
        public DbSet<UserInfo> UserInformation { get; set; }
        public DbSet<UserKycInfo> UserKycInfos { get; set; }
        public DbSet<UserNextOfKin> UserNextOfKins { get; set; }
        public DbSet<UserTwoFactorCover> UserTwoFactorCovers { get; set; }
        public DbSet<VerificationToken> VerificationTokens { get; set; }
        public DbSet<Wallet> Wallets { get; set; }


        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            // Capture the changes
            OnBeforeSaveChanges();
            var result = await base.SaveChangesAsync(cancellationToken);

            // Log the changes after they are committed to the database
            return result;
        }

        private void OnBeforeSaveChanges()
        {
            ChangeTracker.DetectChanges();

            var auditEntries = new List<AuditEntry>();
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is AuditLog || entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
                    continue;
                var auditEntry = new AuditEntry(entry);
                auditEntry.TableName = entry.Entity.GetType().Name;
                auditEntry.UserId = _userContextService.GetCurrentUserId();
                auditEntry.Action = entry.State.ToString();
                auditEntries.Add(auditEntry);
                foreach (var property in entry.Properties)
                {
                    string propertyName = property.Metadata.Name;
                    if (property.Metadata.IsPrimaryKey())
                    {
                        auditEntry.KeyValues[propertyName] = property.CurrentValue;
                        continue;
                    }

                    switch (entry.State)
                    {
                        case EntityState.Added:
                            auditEntry.NewValues[propertyName] = property.CurrentValue;
                            break;
                        case EntityState.Deleted:
                            auditEntry.OldValues[propertyName] = property.OriginalValue;
                            break;
                        case EntityState.Modified:
                            if (property.IsModified)
                            {
                                auditEntry.ChangedColumns.Add(propertyName);
                                auditEntry.OldValues[propertyName] = property.OriginalValue;
                                auditEntry.NewValues[propertyName] = property.CurrentValue;
                            }
                            break;
                    }
                }
            }

            foreach (var auditEntry in auditEntries)
            {
                AuditLogs.Add(auditEntry.ToAudit());
            }
        }
    }
}
