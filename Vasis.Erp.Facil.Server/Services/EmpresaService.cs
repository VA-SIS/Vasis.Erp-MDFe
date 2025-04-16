using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Vasis.Erp.Facil.Application.Interfaces.Cadastros;
using Vasis.Erp.Facil.Data;
using Vasis.Erp.Facil.Shared.Dtos.Cadastros;
using Vasis.Erp.Facil.Shared.Entities.Cadastro;

namespace Vasis.Erp.Facil.Server.Services.Cadastros;

public class EmpresaService : IEmpresaService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public EmpresaService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<EmpresaDto>> ListarAsync()
    {
        var empresas = await _context.Empresas.AsNoTracking().ToListAsync();
        return _mapper.Map<IEnumerable<EmpresaDto>>(empresas);
    }

    public async Task<EmpresaDto?> ObterPorIdAsync(Guid id)
    {
        var empresa = await _context.Empresas.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        return _mapper.Map<EmpresaDto?>(empresa);
    }

    public async Task<EmpresaDto> AdicionarAsync(EmpresaDto dto)
    {
        var empresa = _mapper.Map<Empresa>(dto);
        empresa.Id = Guid.NewGuid();
        empresa.CriadoEm = DateTime.UtcNow;
        empresa.AtualizadoEm = DateTime.UtcNow;

        _context.Empresas.Add(empresa);
        await _context.SaveChangesAsync();

        return _mapper.Map<EmpresaDto>(empresa);
    }

    public async Task<EmpresaDto> AtualizarAsync(EmpresaDto dto)
    {
        var empresa = await _context.Empresas.FirstOrDefaultAsync(e => e.Id == dto.Id);
        if (empresa == null)
            throw new Exception("Empresa não encontrada");

        _mapper.Map(dto, empresa);
        empresa.AtualizadoEm = DateTime.UtcNow;

        _context.Empresas.Update(empresa);
        await _context.SaveChangesAsync();

        return _mapper.Map<EmpresaDto>(empresa);
    }

    public async Task<bool> RemoverAsync(Guid id)
    {
        var empresa = await _context.Empresas.FindAsync(id);
        if (empresa == null)
            return false;

        _context.Empresas.Remove(empresa);
        await _context.SaveChangesAsync();

        return true;
    }

    public Task<EmpresaDto?> ObterAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task CriarAsync(EmpresaDto empresa)
    {
        throw new NotImplementedException();
    }

    Task IEmpresaService.AtualizarAsync(EmpresaDto empresa)
    {
        return AtualizarAsync(empresa);
    }

    Task IEmpresaService.RemoverAsync(Guid id)
    {
        return RemoverAsync(id);
    }
}
