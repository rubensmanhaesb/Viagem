using Microsoft.Extensions.DependencyInjection;

namespace ViagemApp.Application.Extensions
{
    public static class MapperExtensions
    {
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddMaps(AppDomain.CurrentDomain.GetAssemblies());
            });

            return services;
        }
    }
}
