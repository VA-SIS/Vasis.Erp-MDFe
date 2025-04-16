using Vasis.Erp.Facil.Shared.Entities.Cadastros;

namespace Vasis.Erp.Facil.Server.Interfaces.Cadastros;

public interface ITransportadoraService
{
    Task<List<Transportadora>> ListarAsync();
    Task<Transportadora?> ObterPorIdAsync(Guid id);
    Task<Transportadora> CriarAsync(Transportadora transportadora);
    Task<Transportadora> AtualizarAsync(Guid id, Transportadora transportadora);
    Task<bool> RemoverAsync(Guid id);
}
