using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViagemAApp.Repository.Context;

namespace ViagemAApp.Repository.Extensions
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
