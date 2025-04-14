using Microsoft.EntityFrameworkCore;
using Vasis.Erp.Facil.Shared.Entities.Cadastro;

namespace Vasis.Erp.Facil.Data.Repositories;

public class EmpresaRepository : IEmpresaRepository
{
    private readonly AppDbContext _context;

    public EmpresaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Empresa>> ObterTodasAsync()
        => await _context.Empresas.ToListAsync();

    public async Task<Empresa?> ObterPorIdAsync(Guid id)
        => await _context.Empresas.FindAsync(id);

    public async Task AdicionarAsync(Empresa empresa)
    {
        await _context.Empresas.AddAsync(empresa);
        await _context.SaveChangesAsync();
    }

    public async Task AtualizarAsync(Empresa empresa)
    {
        _context.Empresas.Update(empresa);
        await _context.SaveChangesAsync();
    }

    public async Task RemoverAsync(Guid id)
    {
        var empresa = await ObterPorIdAsync(id);
        if (empresa != null)
        {
            _context.Empresas.Remove(empresa);
            await _context.SaveChangesAsync();
        }
    }
}
