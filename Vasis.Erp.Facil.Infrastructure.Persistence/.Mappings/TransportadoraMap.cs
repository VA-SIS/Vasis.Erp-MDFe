using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vasis.Erp.Facil.Shared.Entities.Cadastros;

namespace Vasis.Erp.Facil.Infrastructure.Persistence.Mappings;

public class TransportadoraMap : IEntityTypeConfiguration<Transportadora>
{
    public void Configure(EntityTypeBuilder<Transportadora> builder)
    {
        builder.ToTable("Transportadoras");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Nome).HasMaxLength(150);
        builder.Property(t => t.Cnpj).HasMaxLength(20);
        builder.Property(t => t.Ie).HasMaxLength(20);
        builder.Property(t => t.Email).HasMaxLength(100);
        builder.Property(t => t.Telefone).HasMaxLength(20);
        builder.Property(t => t.Cep).HasMaxLength(10);
        builder.Property(t => t.Endereco).HasMaxLength(150);
        builder.Property(t => t.Numero).HasMaxLength(20);
        builder.Property(t => t.Bairro).HasMaxLength(100);
        builder.Property(t => t.Complemento).HasMaxLength(100);
        builder.Property(t => t.Cidade).HasMaxLength(100);
        builder.Property(t => t.Estado).HasMaxLength(2);

        builder.Property(t => t.CriadoEm).IsRequired();

        builder.HasOne(t => t.Empresa)
               .WithMany()
               .HasForeignKey(t => t.EmpresaId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
