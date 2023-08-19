using iShipping.Ly.Infra.Identity;
using iShipping.Ly.Infra.Persistence;
using iShipping.Ly.Infra.Persistence.Seed;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace iShipping.Ly.Infra
{
    public static class InfraContainer
    {
        public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DataContext>();

            // TODO: Register IUnitOfWork

            services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;

            }).AddEntityFrameworkStores<DataContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = config["Jwt:ValidIssuer"],
                    ValidAudience = config["Jwt:ValidAudience"],
                    IssuerSigningKey = new SymmetricSecurityKey
                    (Encoding.UTF8.GetBytes(config["Jwt:Secret"]!)),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true
                };
            });

            services.AddAuthorization();

            DataSeeder.SeedAsync(services.BuildServiceProvider()).GetAwaiter().GetResult();

            return services;
        }
    }
}
