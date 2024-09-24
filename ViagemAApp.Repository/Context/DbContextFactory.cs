using Microsoft.EntityFrameworkCore;
using ViagemAApp.Repository.Context;
using ViagemAApp.Repository.Context;

namespace ViagemAApp.Repository.Context
{
    public class DbContextFactory
    {
        public static DataContext CreateDbContext(string connectionString)
        {
            // Cria o DbContextOptions usando o connectionString fornecido
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseSqlServer(connectionString);

            // Retorna uma nova instância de DataContext com as opções configuradas
            return new DataContext(optionsBuilder.Options);
        }
    }
}