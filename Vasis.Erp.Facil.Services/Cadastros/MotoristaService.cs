using Microsoft.EntityFrameworkCore;
using Vasis.Erp.Facil.Data;
using Vasis.Erp.Facil.Shared.Entities.Cadastros;

namespace Vasis.Erp.Facil.Services;

public class MotoristaService
{
    private readonly AppDbContext _context;

    public MotoristaService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Motorista>> ListarAsync()
        => await _context.Set<Motorista>().ToListAsync();

    public async Task<Motorista?> ObterPorIdAsync(Guid id)
        => await _context.Set<Motorista>().FindAsync(id);

    public async Task AdicionarAsync(Motorista obj)
    {
        _context.Add(obj);
        await _context.SaveChangesAsync();
    }

    public async Task AtualizarAsync(Motorista obj)
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
