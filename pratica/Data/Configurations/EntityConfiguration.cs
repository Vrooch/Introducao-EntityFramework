using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pratica.Domain;

namespace pratica.Data.Configurations
{
    internal class EntityConfiguration : IEntityTypeConfiguration<Entity>
    {
        public void Configure(EntityTypeBuilder<Entity> builder)
        {
            builder.ToTable("Entidades");
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Nome).HasColumnType("VARCHAR(30)").IsRequired();
            builder.Property(b => b.SobreNome).HasColumnType("VARCHAR(60)").IsRequired();
            builder.Property(b => b.Telefone).HasColumnType("CHAR(11)").IsRequired();
            builder.Property(b => b.CEP).HasColumnType("CHAR(8)").IsRequired();
            builder.Property(b => b.TipoPessoa).HasConversion<string>().IsRequired();

            builder.HasIndex(b => b.Nome).HasDatabaseName("Nomes");
        }
    }
}