namespace Vasis.Erp.Facil.Application.Interfaces.Services;

using Vasis.Erp.Facil.Shared.Entities.Cadastros;

public interface ITransportadoraService
{
    Task<List<Transportadora>> ListarAsync();
    Task<Transportadora?> ObterPorIdAsync(Guid id);
    Task<Transportadora> CriarAsync(Transportadora entidade);
    Task<Transportadora> AtualizarAsync(Transportadora entidade);
    Task<bool> RemoverAsync(Guid id);
}
