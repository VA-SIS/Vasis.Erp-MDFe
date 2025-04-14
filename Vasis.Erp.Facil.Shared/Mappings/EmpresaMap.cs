using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vasis.Erp.Facil.Shared.Entities.Cadastro;

namespace Vasis.Erp.Facil.Shared.Mappings
{
    public class EmpresaMap : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("Empresas");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                   .IsRequired();

            builder.Property(e => e.RazaoSocial)
                   .HasMaxLength(200)
                   .IsRequired();

            builder.Property(e => e.NomeFantasia)
                   .HasMaxLength(200);

            builder.Property(e => e.Cnpj)
                   .HasMaxLength(20)
                   .IsRequired();

            builder.Property(e => e.InscricaoEstadual)
                   .HasMaxLength(20);

            builder.Property(e => e.Endereco)
                   .HasMaxLength(300);

            builder.Property(e => e.Telefone)
                   .HasMaxLength(20);

            builder.Property(e => e.Email)
                   .HasMaxLength(100);
        }
    }
}
