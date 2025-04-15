using Vasis.Erp.Facil.Shared.Entities.Cadastro;

namespace Vasis.Erp.Facil.Services;

public interface IEmpresaService
{
    Task<IEnumerable<Empresa>> ListarAsync();
    Task<Empresa?> ObterAsync(Guid id);
    Task CriarAsync(Empresa empresa);
    Task AtualizarAsync(Empresa empresa);
    Task ExcluirAsync(Guid id);
    Task ObterPorIdAsync(Guid id);
}