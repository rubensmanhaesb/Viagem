using Microsoft.EntityFrameworkCore;
using ViagemApp.Infra.Data.SqlServer.Context;

namespace ViagemApp.Infra.Data.SqlServer.Extensions
{
    public interface IDbContextFactoryProvider
    {
        DbContextOptions<DataContext> CreateDbContextOptions();
    }
}
