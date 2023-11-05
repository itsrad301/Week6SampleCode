using Microsoft.AspNetCore.Identity; // Contains PasswordHasher
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Week6SampleCode.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            IdentityUser identityUser = new IdentityUser
            {
                Id= Guid.NewGuid().ToString(),
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
            // Create an admin Role
            IdentityRole identityRole = new() { ConcurrencyStamp = Guid.NewGuid().ToString(),
                    Id= Guid.NewGuid().ToString(), Name="Admin", NormalizedName="ADMIN"
            };
            builder.Entity<IdentityRole>().HasData(
                                                identityRole);

            // Put the Seeded user in that Role.
            IdentityUserRole<string> identityUserRole = new() 
                                        { RoleId = identityRole.Id, 
                                          UserId = identityUser.Id // created in previous migration
            };
            builder.Entity<IdentityUserRole<string>>().HasData(
                                                identityUserRole);

            // Claims are not automatically seeded based on user role above so
            // we have to add a claim to the user's role in seeding
            // And note you have to add a migration for this claim change as well.
            var adminClaim = new Claim(ClaimTypes.Role, "Admin");

            builder.Entity<IdentityUserClaim<string>>().HasData(
                new IdentityUserClaim<string>
                {
                    Id = 1, // Change this ID as needed
                    UserId = identityUser.Id,
                    ClaimType = adminClaim.Type,
                    ClaimValue = adminClaim.Value
                }
            );

            base.OnModelCreating(builder);
        }
    }
}