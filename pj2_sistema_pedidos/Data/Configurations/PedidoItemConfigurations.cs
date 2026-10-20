using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pj2_sistema_pedidos.Domain;

namespace pj2_sistema_pedidos.Data.Configurations
{
    internal class PedidoItemConfigurations : IEntityTypeConfiguration<PedidoItem>
    {
        public void Configure(EntityTypeBuilder<PedidoItem> builder)
        {
            builder.ToTable("PedidoItens");
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Quantidade).HasDefaultValue(1).IsRequired();
            builder.Property(b => b.valor).IsRequired();
            builder.Property(b => b.Desconto).IsRequired();
        }
    }
}