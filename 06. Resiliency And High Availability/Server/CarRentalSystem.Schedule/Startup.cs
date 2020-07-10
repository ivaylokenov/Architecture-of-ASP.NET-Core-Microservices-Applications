namespace CarRentalSystem.Schedule
{
    using Data;
    using Infrastructure;
    using Messages;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Services;

    public class Startup
    {
        public Startup(IConfiguration configuration)
            => this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
            => services
                .AddWebService<ScheduleDbContext>(this.Configuration)
                .AddTransient<IRentedCarService, RentedCarService>()
                .AddMessaging(
                    this.Configuration,
                    typeof(CarAdUpdatedConsumer));

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            => app
                .UseWebService(env)
                .Initialize();
    }
}
