using Vasis.Erp.Facil.Shared.Dtos.Cadastros;

namespace Vasis.Erp.Facil.Application.Interfaces.Services.Cadastros;

public interface IPessoaAppService
{
    Task<List<PessoaDto>> GetAllAsync();
    Task<PessoaDto?> GetByIdAsync(Guid id);
    Task<PessoaDto> CreateAsync(PessoaDto dto);
    Task<PessoaDto> UpdateAsync(Guid id, PessoaDto dto);
    Task<bool> DeleteAsync(Guid id);
}
