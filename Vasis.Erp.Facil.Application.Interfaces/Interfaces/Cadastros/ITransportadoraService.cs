using Vasis.Erp.Facil.Shared.Dtos.Cadastros;

namespace Vasis.Erp.Facil.Application.Interfaces.Cadastros;


public interface ITransportadoraService
{
    Task<IEnumerable<TransportadoraDto>> ListarAsync();
    Task<TransportadoraDto> ObterAsync(Guid id);
    Task AdicionarAsync(TransportadoraDto transportadora);
    Task AtualizarAsync(TransportadoraDto transportadora);
    Task ExcluirAsync(Guid id);
}


