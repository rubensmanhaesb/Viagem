using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;  // Certifique-se de que este namespace também está presente

//usado em tempo de design para o migration
namespace ViagemAApp.Repository.Context
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            // Construir as configurações para o ambiente
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // Necessário para encontrar o appsettings.json
                .AddJsonFile("appsettings.json")              // Certifique-se que este arquivo exista
                .Build();

            var connectionString = configuration.GetConnectionString("ViagemApp");

            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new DataContext(optionsBuilder.Options);
        }
    }
}
