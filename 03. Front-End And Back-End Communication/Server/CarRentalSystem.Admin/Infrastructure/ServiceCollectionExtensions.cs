namespace CarRentalSystem.Admin.Infrastructure
{
    using System;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Refit;
    using Services;

    public static class ServiceCollectionExtensions
    {
        private static ServiceEndpoints serviceEndpoints;

        // Not working because of https://github.com/reactiveui/refit/issues/717
        public static IServiceCollection AddExternalService<TService>(
            this IServiceCollection services,
            IConfiguration configuration)
            where TService : class
        {
            if (serviceEndpoints == null)
            {
                serviceEndpoints = configuration
                    .GetSection(nameof(ServiceEndpoints))
                    .Get<ServiceEndpoints>(config => config
                        .BindNonPublicProperties = true);
            }

            var serviceName = typeof(TService)
                .Name.Substring(1)
                .Replace("Service", string.Empty);

            services
                .AddRefitClient<TService>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(serviceEndpoints[serviceName]));

            return services;
        }
    }
}
