using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SquadPremium.Infrastructure.Identity;

namespace SquadPremium.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedDefaultUserAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var administratorRole = new IdentityRole("Administrator");

            if (roleManager.Roles.All(r => r.Name != administratorRole.Name))
            {
                await roleManager.CreateAsync(administratorRole);
            }

            var defaultUser = new ApplicationUser { UserName = "PremiumAdmin", Email = "admin@squadpremium.com" };

            if (userManager.Users.All(u => u.UserName != defaultUser.UserName))
            {
                await userManager.CreateAsync(defaultUser, "Squadtech_2021");
                await userManager.AddToRolesAsync(defaultUser, new[] { administratorRole.Name });
            }
        }
    }
}
