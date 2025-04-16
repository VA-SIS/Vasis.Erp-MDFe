using Microsoft.EntityFrameworkCore;
using Vasis.Erp.Facil.Data;
using Vasis.Erp.Facil.Server.Interfaces.Cadastros;
using Vasis.Erp.Facil.Shared.Entities.Cadastros;

namespace Vasis.Erp.Facil.Application.Services.Cadastros;

public class TransportadoraService : ITransportadoraService
{
    private readonly AppDbContext _context;

    public TransportadoraService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Transportadora>> ListarAsync()
    {
        return await _context.Transportadoras.AsNoTracking().ToListAsync();
    }

    public async Task<Transportadora?> ObterPorIdAsync(Guid id)
    {
        return await _context.Transportadoras.FindAsync(id);
    }

    public async Task<Transportadora> CriarAsync(Transportadora transportadora)
    {
        transportadora.CriadoEm = DateTime.UtcNow;
        _context.Transportadoras.Add(transportadora);
        await _context.SaveChangesAsync();
        return transportadora;
    }

    public async Task<Transportadora> AtualizarAsync(Guid id, Transportadora transportadora)
    {
        var existente = await _context.Transportadoras.FindAsync(id);
        if (existente is null) throw new Exception("Transportadora não encontrada.");

        existente.Nome = transportadora.Nome;
        existente.Cnpj = transportadora.Cnpj;
        existente.Ie = transportadora.Ie;
        existente.Email = transportadora.Email;
        existente.Telefone = transportadora.Telefone;
        existente.Endereco = transportadora.Endereco;
        existente.Cidade = transportadora.Cidade;
        existente.Uf = transportadora.Uf;
        existente.AtualizadoEm = DateTime.UtcNow;

        await _context.SaveChangesAsync();
        return existente;
    }

    public async Task<bool> RemoverAsync(Guid id)
    {
        var existente = await _context.Transportadoras.FindAsync(id);
        if (existente is null) return false;

        _context.Transportadoras.Remove(existente);
        await _context.SaveChangesAsync();
        return true;
    }
}
