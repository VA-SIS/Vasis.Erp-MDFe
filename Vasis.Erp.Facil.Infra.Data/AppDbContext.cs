using Microsoft.EntityFrameworkCore;
using Vasis.Erp.Facil.Server.Mappings;
using Vasis.Erp.Facil.Shared.Entities.Cadastros;

namespace Vasis.Erp.Facil.Infra.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<Empresa> Empresas { get; set; }
    public DbSet<Pessoa> Pessoas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EmpresaMapping());
        modelBuilder.ApplyConfiguration(new PessoaMapping());
       
        base.OnModelCreating(modelBuilder);
    }
}
