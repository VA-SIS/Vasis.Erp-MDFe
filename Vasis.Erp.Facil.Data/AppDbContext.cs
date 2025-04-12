using Microsoft.EntityFrameworkCore;
using Vasis.Erp.Facil.Shared.Entities;
using Vasis.Erp.Facil.Shared.Mappings;

namespace Vasis.Erp.Facil.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Empresa> Empresas => Set<Empresa>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EmpresaMap());
        base.OnModelCreating(modelBuilder);
    }
}