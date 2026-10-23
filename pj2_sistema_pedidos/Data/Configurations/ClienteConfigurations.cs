using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pj2_sistema_pedidos.Domain;

namespace pj2_sistema_pedidos.Data.Configurations
{
    internal class ClienteConfigurations : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");
            builder.HasKey(b => b.Id);
            
            builder.Property(b => b.Nome).HasColumnType("VARCHAR(80)").IsRequired();
            builder.Property(b => b.Telefone).HasColumnType("CHAR(11)");
            builder.Property(b => b.CEP).HasColumnType("CHAR(8)").IsRequired();
            builder.Property(b => b.Estado).HasColumnType("CHAR(2)").IsRequired();
            builder.Property(b => b.Cidade).HasMaxLength(60).IsRequired();
            
        }
    }
}