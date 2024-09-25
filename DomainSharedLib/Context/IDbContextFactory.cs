using Microsoft.EntityFrameworkCore;


namespace DomainSharedLib.Context
{
    public interface IDbContextFactory
    {
        public DbContext CreateDbContext();
    }
}
