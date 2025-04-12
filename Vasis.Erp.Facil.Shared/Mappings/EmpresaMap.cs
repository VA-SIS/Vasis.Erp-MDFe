using Microsoft.EntityFrameworkCore;
using Vasis.Erp.Facil.Shared.Entities;

namespace Vasis.Erp.Facil.Shared.Mappings;

public class EmpresaMap : IEntityTypeConfiguration<Empresa>
{
    public void Configure(EntityTypeBuilder<Empresa> builder)
    {
        builder.ToTable("Empresas");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.RazaoSocial).IsRequired().HasMaxLength(150);
        builder.Property(e => e.NomeFantasia).IsRequired().HasMaxLength(150);
        builder.Property(e => e.Cnpj).IsRequired().HasMaxLength(20);
        builder.Property(e => e.InscricaoEstadual).HasMaxLength(30);
        builder.Property(e => e.InscricaoMunicipal).HasMaxLength(30);
        builder.Property(e => e.Email).HasMaxLength(100);
        builder.Property(e => e.Telefone).HasMaxLength(20);
        builder.Property(e => e.Cep).HasMaxLength(10);
        builder.Property(e => e.Endereco).HasMaxLength(150);
        builder.Property(e => e.Numero).HasMaxLength(20);
        builder.Property(e => e.Bairro).HasMaxLength(80);
        builder.Property(e => e.Cidade).HasMaxLength(80);
        builder.Property(e => e.Estado).HasMaxLength(2);
        builder.Property(e => e.Ativa).HasDefaultValue(true);
    }
}