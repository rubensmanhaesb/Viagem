using Microsoft.EntityFrameworkCore;
using ViagemAApp.Repository.Context;

namespace ViagemAApp.Repository.Extensions
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
