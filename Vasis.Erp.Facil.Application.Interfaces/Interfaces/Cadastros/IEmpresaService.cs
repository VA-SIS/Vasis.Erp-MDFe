
using Vasis.Erp.Facil.Shared.Dtos.Cadastros;

namespace Vasis.Erp.Facil.Application.Interfaces.Cadastros;

public interface IEmpresaService
{
    Task<IEnumerable<EmpresaDto>> ListarAsync();
    Task<EmpresaDto?> ObterAsync(Guid id);
    Task CriarAsync(EmpresaDto empresa);
    Task AtualizarAsync(EmpresaDto empresa);
    Task RemoverAsync(Guid id);
}

