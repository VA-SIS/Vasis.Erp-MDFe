using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vasis.Erp.Facil.Shared.Entities.Cadastros;

namespace Vasis.Erp.Facil.Infra.Data.Mappings.Cadastros;

public class PessoaMapping : IEntityTypeConfiguration<Pessoa>
{
    public void Configure(EntityTypeBuilder<Pessoa> builder)
    {
        builder.ToTable("Pessoas");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Nome).IsRequired().HasMaxLength(100);
        builder.Property(x => x.NomeFantasia).HasMaxLength(100);
        builder.Property(x => x.CpfCnpj).HasMaxLength(20);
        builder.Property(x => x.RgIe).HasMaxLength(20);
        builder.Property(x => x.TipoPessoa).HasMaxLength(1);
        builder.Property(x => x.Email).HasMaxLength(100);
        builder.Property(x => x.Telefone).HasMaxLength(20);

        builder.Property(x => x.Cep).HasMaxLength(10);
        builder.Property(x => x.Endereco).HasMaxLength(100);
        builder.Property(x => x.Numero).HasMaxLength(10);
        builder.Property(x => x.Bairro).HasMaxLength(50);
        builder.Property(x => x.Complemento).HasMaxLength(50);
        builder.Property(x => x.Cidade).HasMaxLength(50);
        builder.Property(x => x.Uf).HasMaxLength(2);

        builder.HasOne(x => x.Empresa)
               .WithMany()
               .HasForeignKey(x => x.EmpresaId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
