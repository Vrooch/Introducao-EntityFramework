using Microsoft.EntityFrameworkCore;
using pratica2.Domain;

namespace pratica2.Data
{
    internal class ApplicationContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer();
        } 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
        
    }
}