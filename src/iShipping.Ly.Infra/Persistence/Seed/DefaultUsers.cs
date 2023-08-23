using iShipping.Ly.Application.Constants;
using iShipping.Ly.Application.Dtos.Identity;
using iShipping.Ly.Infra.Identity;
using Microsoft.AspNetCore.Identity;

namespace iShipping.Ly.Infra.Persistence.Seed
{
    public static class DefaultUsers
    {
        public static async Task SeedSuperAdminAsync(UserManager<AppUser> userManager)
        {
            var registerRequest = new RegisterRequest
            (
                UserName: "super",
                Email: "super@shipping.ly",
                PhoneNumber: "0922362848",
                FirstName: "Ayham",
                LastName: "Jamal",
                IdentificationCardNumber: "1",
                Password: "Super@23",
                Role: Roles.SuperAdmin);

            var defaultUser = new AppUser(registerRequest);

            if (await userManager.FindByNameAsync(defaultUser.UserName) is null)
            {
                await userManager.CreateAsync(defaultUser, registerRequest.Password);

                await userManager.AddToRolesAsync(defaultUser, new List<string>
                {
                    Roles.SuperAdmin.ToString(),
                    Roles.Customer.ToString()
                });
            }
        }
    }
}
