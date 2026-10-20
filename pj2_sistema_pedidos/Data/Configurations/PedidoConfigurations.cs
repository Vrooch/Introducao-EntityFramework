using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pj2_sistema_pedidos.Domain;

namespace pj2_sistema_pedidos
{
    internal class PedidoConfigurations : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedidos");
            builder.HasKey(b => b.Id);

            builder.Property(b => b.IniciadoEm).HasDefaultValueSql("GETATE()").ValueGeneratedOnAdd();
            builder.Property(b => b.Status).HasConversion<string>();
            builder.Property(b => b.TipoFrete).HasConversion<int>();
            builder.Property(b => b.Observacao).HasColumnType("VARCHAR(512)");

            builder.HasMany(b => b.Itens)
                .WithOne(b => b.Pedido)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}