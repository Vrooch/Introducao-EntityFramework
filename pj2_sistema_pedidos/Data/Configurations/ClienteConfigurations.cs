using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pj2_sistema_pedidos.Domain;

namespace pj2_sistema_pedidos.Data.Configurations
{
    internal class ClienteConfigurations : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            throw new NotImplementedException();
        }
    }
}