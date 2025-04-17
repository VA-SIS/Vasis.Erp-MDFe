using Microsoft.EntityFrameworkCore;
using System;
using Vasis.Erp.Facil.Domain.Interfaces.Repositories.Cadastros;
using Vasis.Erp.Facil.Infra.Data.Context;
using Vasis.Erp.Facil.Shared.Entities.Cadastros;

namespace Vasis.Erp.Facil.Infra.Data.Repositories.Cadastros;

public class PessoaRepository : IPessoaRepository
{
    private readonly AppDbContext _context;

    public PessoaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Pessoa>> GetAllAsync()
    {
        return await _context.Pessoas.ToListAsync();
    }

    public async Task<Pessoa?> GetByIdAsync(Guid id)
    {
        return await _context.Pessoas.FindAsync(id);
    }

    public async Task AddAsync(Pessoa entity)
    {
        await _context.Pessoas.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Pessoa entity)
    {
        _context.Pessoas.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var entity = await _context.Pessoas.FindAsync(id);
        if (entity == null) return false;

        _context.Pessoas.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }
}
