using Microsoft.EntityFrameworkCore;
using Vasis.Erp.Facil.Data;
using Vasis.Erp.Facil.Shared.Entities.Cadastros;

namespace Vasis.Erp.Facil.Services.Cadastros
{
    public class PessoaService
    {
        private readonly AppDbContext _context;

        public PessoaService(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<Pessoa>> ObterTodasAsync()
        {
            return await _context.Set<Pessoa>()
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Pessoa?> ObterPorIdAsync(Guid id)
        {
            return await _context.Set<Pessoa>()
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Pessoa> CriarAsync(Pessoa pessoa)
        {
            _context.Pessoas.Add(pessoa);
            await _context.SaveChangesAsync();
            return pessoa;
        }

        public async Task<Pessoa?> AtualizarAsync(Pessoa pessoa)
        {
            var existente = await _context.Pessoas.FindAsync(pessoa.Id);
            if (existente is null)
                return null;

            _context.Entry(existente).CurrentValues.SetValues(pessoa);
            await _context.SaveChangesAsync();
            return pessoa;
        }

        public async Task<bool> RemoverAsync(Guid id)
        {
            var pessoa = await _context.Pessoas.FindAsync(id);
            if (pessoa is null)
                return false;

            _context.Pessoas.Remove(pessoa);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
