using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ViagemApp.Infra.Data.SqlServer.Context;

namespace ViagemApp.Infra.Data.SqlServer.Extensions
{
    public class ProductionDbContextFactoryProvider : IDbContextFactoryProvider
    {
        private readonly IConfiguration _configuration;
        public ProductionDbContextFactoryProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public DbContextOptions<DataContext> CreateDbContextOptions()
        {
            var connectionString = _configuration.GetConnectionString("ViagemApp");
            return new DbContextOptionsBuilder<DataContext>()
                .UseSqlServer(connectionString)
                .Options;
        }
    }
}
