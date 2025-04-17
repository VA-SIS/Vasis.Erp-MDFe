using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Vasis.Erp.Facil.Application.Interfaces.Cadastros;
using Vasis.Erp.Facil.Data;
using Vasis.Erp.Facil.Shared.Dtos.Cadastros;
using Vasis.Erp.Facil.Shared.Entities.Cadastros;

namespace Vasis.Erp.Facil.Server.Services.Implementations;

public class TransportadoraService : ITransportadoraService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public TransportadoraService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TransportadoraDto>> ObterTodosAsync()
    {
        var entidades = await _context.Transportadoras.ToListAsync();
        return _mapper.Map<IEnumerable<TransportadoraDto>>(entidades);
    }

    public async Task<TransportadoraDto?> ObterPorIdAsync(Guid id)
    {
        var entidade = await _context.Transportadoras.FindAsync(id);
        return _mapper.Map<TransportadoraDto?>(entidade);
    }

    public async Task<TransportadoraDto> CriarAsync(TransportadoraDto dto)
    {
        var entidade = _mapper.Map<Transportadora>(dto);
        entidade.CriadoEm = DateTime.UtcNow;
        _context.Transportadoras.Add(entidade);
        await _context.SaveChangesAsync();
        return _mapper.Map<TransportadoraDto>(entidade);
    }

    public async Task<TransportadoraDto> AtualizarAsync(TransportadoraDto dto)
    {
        var entidade = await _context.Transportadoras.FindAsync(dto.Id);
        if (entidade is null) throw new Exception("Transportadora não encontrada.");

        _mapper.Map(dto, entidade);
        entidade.AtualizadoEm = DateTime.UtcNow;

        _context.Transportadoras.Update(entidade);
        await _context.SaveChangesAsync();
        return _mapper.Map<TransportadoraDto>(entidade);
    }

    public async Task<bool> RemoverAsync(Guid id)
    {
        var entidade = await _context.Transportadoras.FindAsync(id);
        if (entidade == null) return false;

        _context.Transportadoras.Remove(entidade);
        await _context.SaveChangesAsync();
        return true;
    }

    public Task<IEnumerable<TransportadoraDto>> ListarAsync()
    {
        throw new NotImplementedException();
    }

    public Task<TransportadoraDto> ObterAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task AdicionarAsync(TransportadoraDto transportadora)
    {
        throw new NotImplementedException();
    }

    Task ITransportadoraService.AtualizarAsync(TransportadoraDto transportadora)
    {
        return AtualizarAsync(transportadora);
    }

    public Task ExcluirAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}
