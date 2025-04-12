using Microsoft.EntityFrameworkCore;
using Vasis.Erp.Facil.Shared.Entities;
using Vasis.Erp.Facil.Shared.Entities.Cadastros;
using Vasis.Erp.Facil.Shared.Mappings;
using Vasis.Erp.Facil.Shared.Mappings.Cadastros;

namespace Vasis.Erp.Facil.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Empresa> Empresas => Set<Empresa>();
    public DbSet<Pessoa> Pessoas => Set<Pessoa>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EmpresaMap());
        modelBuilder.ApplyConfiguration(new PessoaMap());

        base.OnModelCreating(modelBuilder);
    }
}