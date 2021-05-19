using Encryption.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Encryption.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Renaming Identity Table Names

            modelBuilder.Entity<ApplicationUser>(b =>
            {
                b.ToTable("ApplicationUsers", schema: "auth");
            });

            modelBuilder.Entity<IdentityUserClaim<string>>(b =>
            {
                b.ToTable("ApplicationUserClaims", schema: "auth");
            });

            modelBuilder.Entity<IdentityUserLogin<string>>(b =>
            {
                b.ToTable("ApplicationUserLogins", schema: "auth");
            });

            modelBuilder.Entity<IdentityUserToken<string>>(b =>
            {
                b.ToTable("ApplicationUserTokens", schema: "auth");
            });

            modelBuilder.Entity<IdentityRole>(b =>
            {
                b.ToTable("Roles", schema: "auth");
            });

            modelBuilder.Entity<IdentityRoleClaim<string>>(b =>
            {
                b.ToTable("RoleClaims", schema: "auth");
            });

            modelBuilder.Entity<IdentityUserRole<string>>(b =>
            {
                b.ToTable("ApplicationUserRoles", schema: "auth");
            });

            #endregion
        }
    }
}
