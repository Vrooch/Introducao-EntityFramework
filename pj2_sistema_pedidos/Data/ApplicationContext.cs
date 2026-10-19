using Microsoft.EntityFrameworkCore;
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
            modelBuilder.Entity<Cliente>( p =>{

                p.ToTable("Clientes");
                p.HasKey(p => p.Id);

                p.Property(p => p.Nome).HasColumnType("VARCHAR(80)").IsRequired();
                p.Property(p => p.Telefone).HasColumnType("CHAR(11)");
                p.Property(p => p.CEP).HasColumnType("CHAR(8)").IsRequired();
                p.Property(p => p.Estado).HasColumnType("CHAR(2)").IsRequired();
                p.Property(p => p.Cidade).HasMaxLength(60).IsRequired();

                p.HasIndex(p => p.Telefone).HasDatabaseName("idx_cliente_telefone");

            });

            modelBuilder.Entity<Produto>(p =>
            {
               p.ToTable("Produtos");
               p.HasKey(p => p.Id);

               p.Property(p => p.CodigoBarras).HasColumnType("VARCHAR(14)").IsRequired();
               p.Property(p => p.Descricao).HasColumnType("VARCHAR(60)");
               p.Property(p => p.Valor).IsRequired();
               p.Property(p => p.TipoProduto).HasConversion<string>(); 
            });
        }
    }
}

