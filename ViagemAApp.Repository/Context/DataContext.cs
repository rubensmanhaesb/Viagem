using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ViagemApp.Infra.Data.SqlServer.Context
{
    public class DataContext : DbContext
    {
        #region Construtor
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        #endregion Construtor

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        private string GetConnectionString()
        {
            return this.Database.GetDbConnection().ConnectionString;
        }

      }
}
