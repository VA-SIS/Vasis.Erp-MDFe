using AutoMapper;
using Vasis.Erp.Facil.Application.Interfaces.Services.Cadastros;
using Vasis.Erp.Facil.Domain.Interfaces.Repositories.Cadastros;
using Vasis.Erp.Facil.Shared.Dtos.Cadastros;
using Vasis.Erp.Facil.Shared.Entities.Cadastros;

namespace Vasis.Erp.Facil.Application.Services.Cadastros;

public class PessoaAppService : IPessoaAppService
{
    private readonly IPessoaRepository _repo;
    private readonly IMapper _mapper;

    public PessoaAppService(IPessoaRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<List<PessoaDto>> GetAllAsync()
    {
        var entidades = await _repo.GetAllAsync();
        return _mapper.Map<List<PessoaDto>>(entidades);
    }

    public async Task<PessoaDto?> GetByIdAsync(Guid id)
    {
        var entidade = await _repo.GetByIdAsync(id);
        return _mapper.Map<PessoaDto>(entidade);
    }

    public async Task<PessoaDto> CreateAsync(PessoaDto dto)
    {
        var entidade = _mapper.Map<Pessoa>(dto);
        await _repo.AddAsync(entidade);
        return _mapper.Map<PessoaDto>(entidade);
    }

    public async Task<PessoaDto> UpdateAsync(Guid id, PessoaDto dto)
    {
        var entidade = await _repo.GetByIdAsync(id);
        if (entidade == null) throw new Exception("Pessoa não encontrada");

        _mapper.Map(dto, entidade);
        await _repo.UpdateAsync(entidade);
        return _mapper.Map<PessoaDto>(entidade);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        return await _repo.DeleteAsync(id);
    }
}
