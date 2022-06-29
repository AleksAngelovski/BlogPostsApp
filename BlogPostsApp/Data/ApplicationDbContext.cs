using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlogPostsApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            this.SeedRoles(builder);
            this.SeedUsers(builder);
            this.SeedUsersRoles(builder);
        }

        private void SeedUsers(ModelBuilder builder)
        {
            //1 user
            IdentityUser user1 = new IdentityUser()
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                UserName = "Aleks",
                //Note: For some reason entity framework searches Normalizes usernames as emails
                NormalizedUserName = "ALEKS@GMAIL.COM",
                Email = "aleks@gmail.com",
                NormalizedEmail = "ALEKS@GMAIL.COM",
                LockoutEnabled = false,
                PhoneNumber = "1234567890",
            };

            PasswordHasher<IdentityUser> passwordHasher = new PasswordHasher<IdentityUser>();
            var hash = passwordHasher.HashPassword(user1, "123");
            user1.PasswordHash = hash;

            builder.Entity<IdentityUser>().HasData(user1);


        }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = "fab4fac1-c546-41de-aebc-a14da6895711", Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" }
                );
        }
        private void SeedUsersRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { RoleId = "fab4fac1-c546-41de-aebc-a14da6895711", UserId = "b74ddd14-6340-4840-95c2-db12554843e5" }
                );
        }
    }
}