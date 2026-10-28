using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using pj2_sistema_pedidos.Data.Configurations;
using pj2_sistema_pedidos.Domain;


namespace pj2_sistema_pedidos.Data
{
    internal class ApplicationContext : DbContext
    {
        private static readonly ILoggerFactory _logger = LoggerFactory.Create(p => p.AddConsole());
        
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
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }
    }
}

