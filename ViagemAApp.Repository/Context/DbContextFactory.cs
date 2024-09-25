using DomainSharedLib.Context;
using Microsoft.EntityFrameworkCore;


namespace ViagemAApp.Repository.Context
{
    public class DbContextFactory : IDbContextFactory
    {
        private readonly DbContextOptions<DataContext> _options;

        public DbContextFactory(DbContextOptions<DataContext> options)
        {
            _options = options;
        }

        public DbContext CreateDbContext()
        {
            return new DataContext(_options);
        }


        /*
         * private readonly string _connectionString;
        public DbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }
        public  DataContext CreateDbContext() //string connectionString)
        {
            // Cria o DbContextOptions usando o connectionString fornecido
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseSqlServer(_connectionString);

            // Retorna uma nova instância de DataContext com as opções configuradas
            return new DataContext(optionsBuilder.Options);
        }
        */
    }
}