using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pratica2.Domain;

namespace pratica2.Data.Configurations
{
    internal class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Nome).HasColumnType("VARCHAR(80)");
        }
    }
}