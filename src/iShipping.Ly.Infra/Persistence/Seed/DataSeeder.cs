using iShipping.Ly.Domain.Exceptions;
using iShipping.Ly.Infra.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace iShipping.Ly.Infra.Persistence.Seed
{
    public static class DataSeeder
    {
        public static async Task SeedAsync(IServiceProvider services)
        {
            using var scope = services.CreateScope();

            var serviceProvider = scope.ServiceProvider;

            try
            {
                var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
                var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                await DefaultRoles.SeedAsync(roleManager);
                await DefaultUsers.SeedSuperAdminAsync(userManager);
            }
            catch (Exception ex)
            {
                throw new AppException(ExceptionStatusCode.DataLoss, ex.Message);
            }
        }
    }
}
