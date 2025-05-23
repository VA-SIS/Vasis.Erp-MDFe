﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vasis.Erp.Facil.Shared.Entities.Cadastros;

namespace Vasis.Erp.Facil.Infrastructure.Persistence.Mappings;

public class PessoaMap : IEntityTypeConfiguration<Pessoa>
{
    public void Configure(EntityTypeBuilder<Pessoa> builder)
    {
        builder.ToTable("Pessoas");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Nome)
               .IsRequired()
               .HasMaxLength(150);

        builder.Property(p => p.NomeFantasia).HasMaxLength(150);
        builder.Property(p => p.CpfCnpj).HasMaxLength(20);
        builder.Property(p => p.RgIe).HasMaxLength(20);
        builder.Property(p => p.TipoPessoa).HasMaxLength(1);
        builder.Property(p => p.Email).HasMaxLength(100);
        builder.Property(p => p.Telefone).HasMaxLength(20);

        builder.Property(p => p.Cep).HasMaxLength(10);
        builder.Property(p => p.Endereco).HasMaxLength(150);
        builder.Property(p => p.Numero).HasMaxLength(20);
        builder.Property(p => p.Bairro).HasMaxLength(100);
        builder.Property(p => p.Complemento).HasMaxLength(100);
        builder.Property(p => p.Cidade).HasMaxLength(100);
        builder.Property(p => p.Uf).HasMaxLength(2);

        builder.HasOne(p => p.Empresa)
               .WithMany(e => e.Pessoas)
               .HasForeignKey(p => p.EmpresaId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
