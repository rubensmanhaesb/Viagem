using DomainSharedLib.Context;
using Microsoft.EntityFrameworkCore;

namespace ViagemApp.Infra.Data.SqlServer.Context
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

    }
}