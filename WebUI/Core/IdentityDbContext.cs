using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebUI
{
    public class IdentityDbContext : IdentityDbContext<User>
    {
        public IdentityDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .ToTable("Users");

            modelBuilder.Entity<IdentityRole>()
                .ToTable("Roles");

            modelBuilder.Entity<IdentityUserRole>()
                .ToTable("UserRoles");

            modelBuilder.Entity<IdentityUserClaim>()
                .ToTable("UserClaims");

            modelBuilder.Entity<IdentityUserLogin>()
                .ToTable("UserLogins");
        }

        public static IdentityDbContext Create()
        {
            return new IdentityDbContext();
        }
    }
}