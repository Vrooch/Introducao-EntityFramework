using Microsoft.EntityFrameworkCore;

namespace pj2_sistema_pedidos.Data
{
    internal class ApplicationConbtext : DbContext
    {
        // sobrescrever o meotodo on conection, e mostar a string de conexao, pegar de: ConectionStrings
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=EF1_projeto2;User Id=sa;Password=Vi*sqls50091040;TrustServerCertificate=True;");
        }
    }
}

