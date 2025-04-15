namespace Vasis.Erp.Facil.Application.Interfaces.Services;

using Vasis.Erp.Facil.Shared.Entities.Cadastros;

public interface IPessoaService
{
    Task<List<Pessoa>> ListarAsync();
    Task<Pessoa?> ObterPorIdAsync(Guid id);
    Task<Pessoa> CriarAsync(Pessoa entidade);
    Task<Pessoa> AtualizarAsync(Pessoa entidade);
    Task<bool> RemoverAsync(Guid id);
}
