using Vasis.Erp.Facil.Shared.Entities;

namespace Vasis.Erp.Facil.Data.Repositories;

public interface IEmpresaRepository
{
    Task<IEnumerable<Empresa>> ObterTodasAsync();
    Task<Empresa?> ObterPorIdAsync(Guid id);
    Task AdicionarAsync(Empresa empresa);
    Task AtualizarAsync(Empresa empresa);
    Task RemoverAsync(Guid id);
}
