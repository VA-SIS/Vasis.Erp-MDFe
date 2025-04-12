using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vasis.Erp.Facil.Shared.Entities.Cadastros;

namespace Vasis.Erp.Facil.Shared.Mappings.Cadastros;

public class MotoristaMap : IEntityTypeConfiguration<Motorista>
{
    public void Configure(EntityTypeBuilder<Motorista> builder)
    {
        builder.ToTable("Motoristas");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Nome).IsRequired().HasMaxLength(200);
        builder.Property(m => m.Cpf).HasMaxLength(20);
        builder.Property(m => m.Cnh).HasMaxLength(20);
        builder.Property(m => m.CategoriaCnh).HasMaxLength(5);

        builder.HasOne(m => m.Transportadora)
               .WithMany()
               .HasForeignKey(m => m.TransportadoraId);
    }
}
