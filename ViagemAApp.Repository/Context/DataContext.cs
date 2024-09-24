using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ViagemAApp.Repository.Context
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
            // Retorna a ConnectionString do DbContext
            return this.Database.GetDbConnection().ConnectionString;
        }

        /*   protected override void OnConfiguring
           (DbContextOptionsBuilder optionsBuilder)
           {
               optionsBuilder.UseSqlServer("Data Source=localhost,1433;User ID = sa; Password = Coti2024!; Encrypt = False");
           }
        */
    }
}
