using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;


//usado em tempo de design para o migration
namespace ViagemAApp.Repository.Context
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var basePath = Directory.GetCurrentDirectory();
            Console.WriteLine($"Base path: {basePath}"); // Verifique o caminho base no tempo de design

            // Construir as configurações para o ambiente
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // Necessário para encontrar o appsettings.json
                .AddJsonFile("appsettings.Development.json")  // Certifique-se que este arquivo exista
                .Build();

            var connectionString = configuration.GetConnectionString("ViagemApp");
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string 'ViagemApp' não foi encontrada.");
            }

            Console.WriteLine($"Connection String: {connectionString}");

            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new DataContext(optionsBuilder.Options);
        }
    }
}
