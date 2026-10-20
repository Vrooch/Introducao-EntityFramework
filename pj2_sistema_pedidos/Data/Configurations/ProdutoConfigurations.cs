using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pj2_sistema_pedidos.Domain;

namespace pj2_sistema_pedidos
{
    internal class ProdutoConfigurations : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produtos");
            builder.HasKey(b => b.Id);

            builder.Property(b => b.CodigoBarras).HasColumnType("VARCHAR(14)").IsRequired();
            builder.Property(b => b.Descricao).HasColumnType("VARCHAR(60)");
            builder.Property(b => b.Valor).IsRequired();
            builder.Property(b => b.TipoProduto).HasConversion<string>();
        }
    }
}