using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace iShipping.Ly.Application
{
    public static class ApplicationContainer
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(ApplicationContainer).Assembly));

            services.AddValidatorsFromAssembly(typeof(ApplicationContainer).Assembly);

            return services;
        }
    }
}
