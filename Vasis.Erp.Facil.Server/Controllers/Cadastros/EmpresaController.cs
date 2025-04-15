using Microsoft.AspNetCore.Mvc;
using Vasis.Erp.Facil.Services;
using Vasis.Erp.Facil.Shared.Entities.Cadastro;

namespace Vasis.Erp.Facil.Server.Controllers.Cadastros;

[ApiController]
[Route("api/[controller]")]
public class EmpresaController : ControllerBase
{
    private readonly IEmpresaService _empresaService;

    public EmpresaController(IEmpresaService empresaService)
    {
        _empresaService = empresaService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Empresa>>> Get() =>
        Ok(await _empresaService.ListarAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult<Empresa?>> Get(Guid id)
    {
        var result = await _empresaService.ObterPorIdAsync(id);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Empresa>> Post([FromBody] Empresa empresa) =>
        Ok(await _empresaService.CriarAsync(empresa));

    [HttpPut("{id}")]
    public async Task<ActionResult<Empresa>> Put(Guid id, [FromBody] Empresa empresa)
    {
        if (id != empresa.Id) return BadRequest();
        return Ok(await _empresaService.AtualizarAsync(empresa));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var sucesso = await _empresaService.RemoverAsync(id);
        return sucesso ? Ok() : NotFound();
    }
}
