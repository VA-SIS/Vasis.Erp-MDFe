using Vasis.Erp.Facil.Shared.Entities.Cadastros;

namespace Vasis.Erp.Facil.Domain.Interfaces.Repositories.Cadastros;

public interface IPessoaRepository
{
    Task<List<Pessoa>> GetAllAsync();
    Task<Pessoa?> GetByIdAsync(Guid id);
    Task AddAsync(Pessoa entity);
    Task UpdateAsync(Pessoa entity);
    Task<bool> DeleteAsync(Guid id);
}
