using iShipping.Ly.Application.Constants;
using Microsoft.AspNetCore.Identity;

namespace iShipping.Ly.Infra.Persistence.Seed
{
    public static class DefaultRoles
    {
        public static async Task SeedAsync(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new IdentityRole(Roles.SuperAdmin.ToString()));
                await roleManager.CreateAsync(new IdentityRole(Roles.Customer.ToString()));
            }
        }
    }
}
