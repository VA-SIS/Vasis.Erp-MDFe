namespace Vasis.Erp.Facil.Application.Interfaces.Services;

using Vasis.Erp.Facil.Shared.Entities.Cadastros;

public interface IVeiculoService
{
    Task<List<Veiculo>> ListarAsync();
    Task<Veiculo?> ObterPorIdAsync(Guid id);
    Task<Veiculo> CriarAsync(Veiculo entidade);
    Task<Veiculo> AtualizarAsync(Veiculo entidade);
    Task<bool> RemoverAsync(Guid id);
}
