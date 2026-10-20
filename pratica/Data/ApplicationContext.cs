using Microsoft.EntityFrameworkCore;
namespace pratica.Data
{
    internal class ApplicationContext : DbContext
    {
        public void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=EF1_projeto2;User Id=sa;Password=Vi*sqls50091040;TrustServerCertificate=True;");
        }
        public void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }
    }
}