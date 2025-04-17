using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vasis.Erp.Facil.Shared.Entities.Cadastro;

namespace Vasis.Erp.Facil.Infrastructure.Persistence.Mappings;

public class EmpresaMap : IEntityTypeConfiguration<Empresa>
{
    public void Configure(EntityTypeBuilder<Empresa> builder)
    {
        builder.ToTable("Empresas");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.RazaoSocial)
               .IsRequired()
               .HasMaxLength(150);

        builder.Property(e => e.NomeFantasia).HasMaxLength(150);
        builder.Property(e => e.Cnpj).HasMaxLength(20);
        builder.Property(e => e.InscricaoEstadual).HasMaxLength(20);
        builder.Property(e => e.Email).HasMaxLength(100);
        builder.Property(e => e.Telefone).HasMaxLength(20);
        builder.Property(e => e.Cep).HasMaxLength(10);
        builder.Property(e => e.Endereco).HasMaxLength(150);
        builder.Property(e => e.Numero).HasMaxLength(20);
        builder.Property(e => e.Bairro).HasMaxLength(100);
        builder.Property(e => e.Complemento).HasMaxLength(150);
        builder.Property(e => e.Cidade).HasMaxLength(100);
        builder.Property(e => e.Estado).HasMaxLength(2);

        builder.Property(e => e.CriadoEm).IsRequired();
    }
}
