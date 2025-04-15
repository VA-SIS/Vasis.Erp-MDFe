namespace Vasis.Erp.Facil.Application.Interfaces.Services;

using Vasis.Erp.Facil.Shared.Entities.Cadastros;

public interface IMotoristaService
{
    Task<List<Motorista>> ListarAsync();
    Task<Motorista?> ObterPorIdAsync(Guid id);
    Task<Motorista> CriarAsync(Motorista entidade);
    Task<Motorista> AtualizarAsync(Motorista entidade);
    Task<bool> RemoverAsync(Guid id);
}
