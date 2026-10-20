using Microsoft.EntityFrameworkCore;
using pj2_sistema_pedidos.Data.Configurations;
using pj2_sistema_pedidos.Domain;


namespace pj2_sistema_pedidos.Data
{
    internal class ApplicationConbtext : DbContext
    {
        // Expondo as prorpiedades atraves do DbSet;
        public DbSet<Pedido> Pedido {get; set;}
        public DbSet<Cliente> Cliente {get; set;}
        public DbSet<Produto> Produto {get; set;}

        // sobrescrever o meotodo on conection, e mostar a string de conexao, pegar de: ConectionStrings
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=EF1_projeto2;User Id=sa;Password=Vi*sqls50091040;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationConbtext).Assembly);
        }
    }
}

