using Microsoft.EntityFrameworkCore;
using ViagemAApp.Repository.Context;

namespace ViagemAApp.Repository.Extensions
{
    public interface IDbContextFactoryProvider
    {
        DbContextOptions<DataContext> CreateDbContextOptions();
    }
}
