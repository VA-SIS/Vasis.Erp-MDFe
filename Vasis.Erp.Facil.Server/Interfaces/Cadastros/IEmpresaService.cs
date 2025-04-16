using Vasis.Erp.Facil.Server.DTOs.Cadastros;

namespace Vasis.Erp.Facil.Server.Interfaces.Cadastros;

public interface IEmpresaService
{
    Task<IEnumerable<EmpresaDto>> ListarAsync();
    Task<EmpresaDto?> ObterPorIdAsync(Guid id);
    Task<EmpresaDto> AdicionarAsync(EmpresaDto dto);
    Task<EmpresaDto> AtualizarAsync(EmpresaDto dto);
    Task<bool> RemoverAsync(Guid id);
}
