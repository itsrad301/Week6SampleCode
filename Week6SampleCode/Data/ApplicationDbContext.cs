using Microsoft.AspNetCore.Identity; // Contains PasswordHasher
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Week6SampleCode.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            IdentityUser identityUser = new IdentityUser
            {
                Email = "paul.powell@atu.ie",
                EmailConfirmed = true,
                UserName = "paul.powell@atu.ie",
                NormalizedUserName="PAUL.POWELL@ATU.IE",
                SecurityStamp = Guid.NewGuid().ToString(),
            };
            //set user password
            PasswordHasher<IdentityUser> ph = new PasswordHasher<IdentityUser>();
            identityUser.PasswordHash = ph.HashPassword(identityUser, "Rad301$123");
            builder.Entity<IdentityUser>().HasData(
                                    identityUser);
            base.OnModelCreating(builder);
        }
    }
}