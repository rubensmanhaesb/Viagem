using Microsoft.EntityFrameworkCore;
using ViagemApp.Infra.Data.SqlServer.Context;

namespace ViagemApp.Infra.Data.SqlServer.Extensions
{
    public class TestingDbContextFactoryProvider : IDbContextFactoryProvider
    {
        public DbContextOptions<DataContext> CreateDbContextOptions()
        {
            return new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase("TestDatabase")
                .Options;
        }


    }
}
