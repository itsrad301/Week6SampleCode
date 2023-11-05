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
            IdentityRole[] identityRoles = new IdentityRole[]{ 
                new() { ConcurrencyStamp = Guid.NewGuid().ToString(),
                    Id= Guid.NewGuid().ToString(), Name="Admin", NormalizedName="ADMIN"},
                new() { ConcurrencyStamp = Guid.NewGuid().ToString(),
                    Id= Guid.NewGuid().ToString(), Name="Club Captain", NormalizedName="CLUB CAPTAIN"}
            };

            builder.Entity<IdentityRole>().HasData(
                                                identityRoles);

            List<IdentityUserRole<string>> identityUserRoles = new List<IdentityUserRole<string>>();
            

            // Add the current user to two roles
            foreach (IdentityRole item in identityRoles)
            {
                // Put the Seeded user in that Role.
                identityUserRoles.Add(
                new()
                {
                    RoleId = item.Id,
                    UserId = identityUser.Id // created in previous migration
                });
            }
            builder.Entity<IdentityUserRole<string>>().HasData(
                                                identityUserRoles.ToArray());

            // Claims are not automatically seeded based on user role above so
            // we have to add a claim to the user's role in seeding
            // And note you have to add a migration for this claim change as well.
            var adminClaim = new Claim(ClaimTypes.Role, "Admin");
            var clubClaim = new Claim(ClaimTypes.Role, "Club Captain");

            // Add admin role claim
            builder.Entity<IdentityUserClaim<string>>().HasData(
                new IdentityUserClaim<string>
                {
                    Id = 1, 
                    UserId = identityUser.Id,
                    ClaimType = adminClaim.Type,
                    ClaimValue = adminClaim.Value
                }
            );
            // Add Club Captain Role Claim
            builder.Entity<IdentityUserClaim<string>>().HasData(
                new IdentityUserClaim<string>
                {
                    Id = 2, // Change this ID as needed
                    UserId = identityUser.Id,
                    ClaimType = clubClaim.Type,
                    ClaimValue = clubClaim.Value
                }
            );

            base.OnModelCreating(builder);
        }
    }
}