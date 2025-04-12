using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Vasis.Erp.Facil.Shared.Entities.Cadastros;



namespace Vasis.Erp.Facil.Shared.Mappings.Cadastros;

public class PessoaMap : IEntityTypeConfiguration<Pessoa>
{
    public void Configure(EntityTypeBuilder<Pessoa> builder)
    {
        builder.ToTable("Pessoa");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Nome)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(p => p.CpfCnpj)
            .HasMaxLength(20);

        builder.Property(p => p.TipoPessoa)
            .HasMaxLength(1);

        builder.Property(p => p.Email)
            .HasMaxLength(100);

        builder.HasOne(p => p.Empresa)
            .WithMany(e => e.Pessoas)
            .HasForeignKey(p => p.EmpresaId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}