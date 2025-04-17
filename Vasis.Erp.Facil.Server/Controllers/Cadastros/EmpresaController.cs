using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Vasis.Erp.Facil.Server.Controllers.Cadastros;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class EmpresaController : ControllerBase
{
    private readonly IEmpresaService _empresaService;

    public EmpresaController(IEmpresaService empresaService)
    {
        _empresaService = empresaService;
    }

    [HttpGet]
    public async Task<IActionResult> Get() =>
        Ok(await _empresaService.ObterTodosAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var empresa = await _empresaService.ObterPorIdAsync(id);
        return empresa == null ? NotFound() : Ok(empresa);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] EmpresaCreateDto dto)
    {
        var novaEmpresa = await _empresaService.AdicionarAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = novaEmpresa.Id }, novaEmpresa);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] EmpresaUpdateDto dto)
    {
        if (id != dto.Id) return BadRequest();
        await _empresaService.AtualizarAsync(dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _empresaService.RemoverAsync(id);
        return NoContent();
    }
}
