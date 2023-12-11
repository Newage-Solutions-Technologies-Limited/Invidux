using Invidux_Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Invidux_Data.Context
{
    public class InviduxDBContext : IdentityDbContext
    {
        public InviduxDBContext(DbContextOptions<InviduxDBContext> options)
            : base(options)
        {
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
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<UserIncomeInfo> UserIncomeInfos { get; set; }
        public DbSet<UserInfo> UserInformation { get; set; }
        public DbSet<UserKycInfo> UserKycInfos { get; set; }
        public DbSet<UserNextOfKin> UserNextOfKins { get; set; }

        public DbSet<VerificationToken> VerificationTokens { get; set; }
    }
}
