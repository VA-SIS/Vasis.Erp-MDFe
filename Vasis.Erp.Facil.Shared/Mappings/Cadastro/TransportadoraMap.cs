using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vasis.Erp.Facil.Shared.Entities.Cadastros;

namespace Vasis.Erp.Facil.Shared.Mappings.Cadastros;

public class TransportadoraMap : IEntityTypeConfiguration<Transportadora>
{
    public void Configure(EntityTypeBuilder<Transportadora> builder)
    {
        builder.ToTable("Transportadoras");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Nome).IsRequired().HasMaxLength(200);
        builder.Property(t => t.Cnpj).HasMaxLength(20);
        builder.Property(t => t.Ie).HasMaxLength(20);
        builder.Property(t => t.Email).HasMaxLength(100);
        builder.Property(t => t.Telefone).HasMaxLength(20);
        builder.Property(t => t.Endereco).HasMaxLength(200);
        builder.Property(t => t.Cidade).HasMaxLength(100);
        builder.Property(t => t.Uf).HasMaxLength(2);
    }
}
