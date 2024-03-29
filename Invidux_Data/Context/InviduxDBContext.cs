﻿using Invidux_Data.CountySeeding;
using Invidux_Domain.Models;
using Invidux_Domain.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

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

        // Seed Countries if table is empty
        public static void SeedCountries(InviduxDBContext dc)
        {
            if (!dc.Countries.Any())
            {
                dc.Database.ExecuteSqlRaw(SqlScripts.SeedCountriesSql);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var adminRoleId = Guid.NewGuid().ToString();
            var dealerBrokerRoleId = Guid.NewGuid().ToString();
            var investorRoleId = Guid.NewGuid().ToString();
            var issuerRoleId = Guid.NewGuid().ToString();
            var partnerRoleId = Guid.NewGuid().ToString();

            base.OnModelCreating(builder);
            builder.Entity<IdentityUser>(entity =>
            {
                entity.ToTable(name: "Users");
            });

            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Roles");
            });

            /*
            builder.Entity<AppUser>()
               .HasOne(au => au.SubRole) // AppUser has one SubRole
               .WithMany(sr => sr.Users) // SubRole can be associated with many AppUsers
               .HasForeignKey(au => au.SubRoleId) // Foreign key in AppUser
               .OnDelete(DeleteBehavior.NoAction); // Prevent cascade delete
            */

            builder.Entity<BankAccount>()
                .HasOne(ba => ba.User)
                .WithMany(u => u.BankAccounts)
                .HasForeignKey(ba => ba.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<StellarAccount>()
                .HasOne(sa => sa.User) 
                .WithMany(u => u.StellarAccounts)
                .HasForeignKey(sa => sa.UserId) 
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<StellarAccount>()
                .HasOne(sa => sa.Wallet)
                .WithMany(w => w.StellarAccounts)
                .HasForeignKey(sa => sa.WalletId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<AppRole>().HasData(
                new AppRole { Id = adminRoleId, Name = RoleStrings.Admin, NormalizedName = RoleStrings.Admin.ToUpper(), ConcurrencyStamp = Guid.NewGuid().ToString() },
                new AppRole { Id = dealerBrokerRoleId, Name = RoleStrings.Dealer_Broker, NormalizedName = RoleStrings.Dealer_Broker.ToUpper(), ConcurrencyStamp = Guid.NewGuid().ToString() },
                new AppRole { Id = investorRoleId, Name = RoleStrings.Investor, NormalizedName = RoleStrings.Investor.ToUpper() , ConcurrencyStamp = Guid.NewGuid().ToString() },
                new AppRole { Id = issuerRoleId, Name = RoleStrings.TokenIssuer, NormalizedName = RoleStrings.TokenIssuer.ToUpper(), ConcurrencyStamp = Guid.NewGuid().ToString() },
                new AppRole { Id = partnerRoleId, Name = RoleStrings.Partner, NormalizedName = RoleStrings.Partner.ToUpper() , ConcurrencyStamp = Guid.NewGuid().ToString() }
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

            builder.Entity<InvestmentType>().HasData(
                new InvestmentType { Id = 1, Type = "Long Co-own", CreatedAt = DateTime.UtcNow},
                new InvestmentType { Id = 2, Type = "Medium Co-own", CreatedAt = DateTime.UtcNow },
                new InvestmentType { Id = 3, Type = "Debt", CreatedAt = DateTime.UtcNow },
                new InvestmentType { Id = 4, Type = "Co-build", CreatedAt = DateTime.UtcNow },
                new InvestmentType { Id = 5, Type = "Rental", CreatedAt = DateTime.UtcNow }
            );

            builder.Entity<KycIdCard>().HasData(
                new KycIdCard { Id = 1, Name = "Driver License", Expires = true, CreatedAt = DateTime.UtcNow },
                new KycIdCard { Id = 2, Name = "International Passport", Expires = true , CreatedAt = DateTime.UtcNow },
                new KycIdCard { Id = 3, Name = "NIN" , Expires = false , CreatedAt = DateTime.UtcNow },
                new KycIdCard { Id = 4, Name = "Voter's Card" , Expires = false , CreatedAt = DateTime.UtcNow }
            );

            builder.Entity<KycLevel>().HasData(
                new KycLevel { Id = 1, Status = KycLevelStrings.Level1, CreatedAt = DateTime.UtcNow },
                new KycLevel { Id = 2, Status = KycLevelStrings.Level2, CreatedAt = DateTime.UtcNow },
                new KycLevel { Id = 3, Status = KycLevelStrings.Level3, CreatedAt = DateTime.UtcNow }
            );

            builder.Entity<KycStatus>().HasData(
                new KycStatus { Id = 1, Status = KycStatusStrings.Pending , CreatedAt = DateTime.UtcNow },
                new KycStatus { Id = 2, Status = KycStatusStrings.Verified , CreatedAt = DateTime.UtcNow },
                new KycStatus { Id = 3, Status = KycStatusStrings.Restricted , CreatedAt = DateTime.UtcNow }
            );

            builder.Entity<PaymentMethod>().HasData(
                new PaymentMethod { Id = 1, Name = "Wallet", CreatedAt = DateTime.UtcNow },
                new PaymentMethod { Id = 2, Name = "Card", CreatedAt = DateTime.UtcNow },
                new PaymentMethod { Id = 3, Name = "Bank Transfer", CreatedAt = DateTime.UtcNow },
                new PaymentMethod { Id = 4, Name = "KongaPay", CreatedAt = DateTime.UtcNow }
            );

            builder.Entity<PropertyClass>().HasData(
                new PropertyClass { Id = 1, Class = "Off-plan", CreatedAt = DateTime.UtcNow },
                new PropertyClass { Id = 2, Class = "Pre-purchased", CreatedAt = DateTime.UtcNow },
                new PropertyClass { Id = 3, Class = "Wait-listed", CreatedAt = DateTime.UtcNow },
                new PropertyClass { Id = 4, Class = "Rented", CreatedAt = DateTime.UtcNow },
                new PropertyClass { Id = 5, Class = "Mortgage-Like", CreatedAt = DateTime.UtcNow },
                new PropertyClass { Id = 6, Class = "Under Management", CreatedAt = DateTime.UtcNow }
            );

            builder.Entity<SecurityType>().HasData(
                new SecurityType { Id = 1, Type = "User Registration" , CreatedAt = DateTime.UtcNow },
                new SecurityType { Id = 2, Type = "Two Factor Activation" , CreatedAt = DateTime.UtcNow },
                new SecurityType { Id = 3, Type = "Two Factor Verification" , CreatedAt = DateTime.UtcNow },
                new SecurityType { Id = 4, Type = "BVN Verification" , CreatedAt = DateTime.UtcNow }
            );

            builder.Entity<SubRole>().HasData(
                new SubRole { Id = Guid.NewGuid().ToString(), Name = SubRolesStrings.SuperAdmin, RoleId = adminRoleId, CreatedAt = DateTime.UtcNow },
                new SubRole { Id = Guid.NewGuid().ToString(), Name = SubRolesStrings.CustomerSupport, RoleId = adminRoleId, CreatedAt = DateTime.UtcNow },
                new SubRole { Id = Guid.NewGuid().ToString(), Name = SubRolesStrings.Broker, RoleId = dealerBrokerRoleId, CreatedAt = DateTime.UtcNow },
                new SubRole { Id = Guid.NewGuid().ToString(), Name = SubRolesStrings.Dealer, RoleId = dealerBrokerRoleId, CreatedAt = DateTime.UtcNow },
                new SubRole { Id = Guid.NewGuid().ToString(), Name = SubRolesStrings.Accrediated, RoleId = investorRoleId, CreatedAt = DateTime.UtcNow },
                new SubRole { Id = Guid.NewGuid().ToString(), Name = SubRolesStrings.Institutional, RoleId = investorRoleId, CreatedAt = DateTime.UtcNow },
                new SubRole { Id = Guid.NewGuid().ToString(), Name = SubRolesStrings.Retail, RoleId = investorRoleId, CreatedAt = DateTime.UtcNow },
                new SubRole { Id = Guid.NewGuid().ToString(), Name = SubRolesStrings.TokenIssuer, RoleId = issuerRoleId, CreatedAt = DateTime.UtcNow },
                new SubRole { Id = Guid.NewGuid().ToString(), Name = SubRolesStrings.Custodian, RoleId = partnerRoleId, CreatedAt = DateTime.UtcNow },
                new SubRole { Id = Guid.NewGuid().ToString(), Name = SubRolesStrings.PropertyManager, RoleId = partnerRoleId, CreatedAt = DateTime.UtcNow }
            );

            builder.Entity<TokenListingStatus>().HasData(
                new TokenListingStatus { Id = 1, Status = "Off-Plan", CreatedAt = DateTime.UtcNow},
                new TokenListingStatus { Id = 2, Status ="Wait-listed", CreatedAt = DateTime.UtcNow }, 
                new TokenListingStatus { Id = 3, Status = "Selling" , CreatedAt = DateTime.UtcNow },
                new TokenListingStatus { Id = 4, Status = "Fully Sold" , CreatedAt = DateTime.UtcNow },
                new TokenListingStatus { Id = 5, Status = "Trading", CreatedAt = DateTime.UtcNow },
                new TokenListingStatus { Id = 6, Status = "Exited", CreatedAt = DateTime.UtcNow }
            );

            builder.Entity<TokenTransactionType>().HasData(
                new TokenTransactionType { Id = 1, TransactionType = "Buy", CreatedAt = DateTime.UtcNow },
                new TokenTransactionType { Id = 2, TransactionType = "Sell", CreatedAt = DateTime.UtcNow },
                new TokenTransactionType { Id = 3, TransactionType = "Transfer-in", CreatedAt = DateTime.UtcNow },
                new TokenTransactionType { Id = 4, TransactionType = "Transfer-out", CreatedAt = DateTime.UtcNow },
                new TokenTransactionType { Id = 5, TransactionType = "Exited", CreatedAt = DateTime.UtcNow }
            );

            builder.Entity<TransactionType>().HasData(
                new TransactionType { Id = 1, Type = "Deposit", CreatedAt = DateTime.UtcNow },
                new TransactionType { Id = 2, Type = "Withdrawal", CreatedAt = DateTime.UtcNow },
                new TransactionType { Id = 3, Type = "Token Earnings", CreatedAt = DateTime.UtcNow },
                new TransactionType { Id = 4, Type = "Referal Earnings", CreatedAt = DateTime.UtcNow },
                new TransactionType { Id = 5, Type = "Tranfer-in", CreatedAt = DateTime.UtcNow },
                new TransactionType { Id = 6, Type = "Transfer-out", CreatedAt = DateTime.UtcNow },
                new TransactionType { Id = 7, Type = "Payment", CreatedAt = DateTime.UtcNow }
            );

            builder.Entity<TwoFactorCover>().HasData(
                new TwoFactorCover { Id = 1, Type = TwoFactorCoverStrings.Login, CreatedAt = DateTime.UtcNow },
                new TwoFactorCover { Id = 2, Type = TwoFactorCoverStrings.Transaction, CreatedAt = DateTime.UtcNow },
                new TwoFactorCover { Id = 3, Type = TwoFactorCoverStrings.Trading, CreatedAt = DateTime.UtcNow }
            );

            builder.Entity<TwoFactorType>().HasData(
                new TwoFactorType { Id = 1, Type = TwoFactorTypeStrings.Email, CreatedAt = DateTime.UtcNow },
                new TwoFactorType { Id = 2, Type = TwoFactorTypeStrings.GoogleAuth, CreatedAt = DateTime.UtcNow }
            );

            builder.Entity<UserIncomeInfo>(entity =>
            {
                entity.Property(e => e.InvestmentLimitUsed)
                      .HasPrecision(18, 2); // Set precision and scale    
                entity.Property(e => e.RemainingAllowance)
                      .HasPrecision(18, 2); // Set precision and scale                
            });

            builder.Entity<UserToken>(entity =>
            {
                entity.Property(e => e.Available)
                      .HasPrecision(18, 2); // Set precision and scale    
                entity.Property(e => e.Earnings)
                      .HasPrecision(18, 2); // Set precision and scale                
            });
        }

        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<InvestmentType> InvestmentTypes { get; set; }
        public DbSet<KycIdCard> IdCards { get; set; }
        public DbSet<KycLevel> KycLevels { get; set; }
        public DbSet<KycStatus> KycStatuses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<PropertyClass> PropertyClasses { get; set; }
        public DbSet<SecurityToken> SecurityTokens { get; set; }
        public DbSet<SecurityType> SecurityTypes { get; set; }
        public DbSet<StellarAccount> StellarAccounts { get; set; }
        public DbSet<SubRole> SubRoles { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<TokenAnnualYield> TokenAnnualYields { get; set; }
        public DbSet<TokenApproval> TokenApprovals { get; set; }
        public DbSet<TokenImage> TokenImages { get; set; }
        public DbSet<TokenListingStatus> TokenListingStatuses { get; set; }
        public DbSet<TokenTransactionType> TokenTransactionTypes { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }
        public DbSet<TwoFactorCover> TwoFactorCovers { get; set; }
        public DbSet<TwoFactorType> TwoFactorTypes { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<UserIncomeInfo> UserIncomeInfos { get; set; }
        public DbSet<UserInfo> UserInformation { get; set; }
        public DbSet<UserKycInfo> UserKycInfos { get; set; }
        public DbSet<UserNextOfKin> UserNextOfKins { get; set; }
        public DbSet<UserSubRole> UserSubRoles { get; set; }
        public DbSet<UserTwoFactorCover> UserTwoFactorCovers { get; set; }
        public DbSet<UserToken> UserTokens {  get; set; }
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
                auditEntry.RecordId = entry.State == EntityState.Added ? null : entry.Properties.FirstOrDefault(p => p.Metadata.IsPrimaryKey())?.CurrentValue.ToString();
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
