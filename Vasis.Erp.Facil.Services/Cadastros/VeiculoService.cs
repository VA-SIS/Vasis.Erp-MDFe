using Microsoft.EntityFrameworkCore;
using Vasis.Erp.Facil.Data;
using Vasis.Erp.Facil.Shared.Entities.Cadastros;

namespace Vasis.Erp.Facil.Services;

public class VeiculoService
{
    private readonly AppDbContext _context;

    public VeiculoService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Veiculo>> ListarAsync()
        => await _context.Set<Veiculo>().ToListAsync();

    public async Task<Veiculo?> ObterPorIdAsync(Guid id)
        => await _context.Set<Veiculo>().FindAsync(id);

    public async Task AdicionarAsync(Veiculo obj)
    {
        _context.Add(obj);
        await _context.SaveChangesAsync();
    }

    public async Task AtualizarAsync(Veiculo obj)
    {
        _context.Update(obj);
        await _context.SaveChangesAsync();
    }

    public async Task RemoverAsync(Guid id)
    {
        var obj = await ObterPorIdAsync(id);
        if (obj is not null)
        {
            _context.Remove(obj);
            await _context.SaveChangesAsync();
        }
    }
}
