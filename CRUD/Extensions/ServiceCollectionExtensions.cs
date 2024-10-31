using CRUD.Services;

namespace CRUD.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<GameService>();
            services.AddScoped<GameService>();
            services.AddScoped<LoggerService>();

            return services;
        }
    }
}
