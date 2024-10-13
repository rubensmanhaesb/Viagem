using ViagemApp.Application.Interfaces.Logs;
using ViagemApp.Infra.Data.MongoDB.Context;
using ViagemApp.Infra.Data.MongoDB.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ViagemApp.Infra.Data.MongoDB.Storage;


namespace ViagemApp.Infra.Data.MongoDB.Extensions
{
    public static class MongoDBExtension
    {
        public static IServiceCollection AddMongoDB(this IServiceCollection services, IConfiguration configuration)
        {
            //capturar as configurações do /appsettings
            var mongoDBSettings = new MongoDBSettings();
            new ConfigureFromConfigurationOptions<MongoDBSettings>
                (configuration.GetSection("MongoDBSettings"))
                .Configure(mongoDBSettings);

            //injeção de dependência
            services.AddSingleton(mongoDBSettings);
            services.AddScoped<MongoDBContext>();
            services.AddTransient<ILogDataStore, LogDataStore>();

            return services;
        }
    }
}
