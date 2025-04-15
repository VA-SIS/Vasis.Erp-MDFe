using Microsoft.AspNetCore.Mvc;
using Vasis.Erp.Facil.Application.Interfaces.Services;
using Vasis.Erp.Facil.Shared.Entities.Cadastros;

namespace Vasis.Erp.Facil.Server.Controllers.Cadastros;

[ApiController]
[Route("api/[controller]")]
public class VeiculoController : ControllerBase
{
    private readonly IVeiculoService _veiculoService;

    public VeiculoController(IVeiculoService veiculoService)
    {
        _veiculoService = veiculoService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Veiculo>>> Get() =>
        Ok(await _veiculoService.ListarAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult<Veiculo?>> Get(Guid id)
    {
        var result = await _veiculoService.ObterPorIdAsync(id);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Veiculo>> Post([FromBody] Veiculo veiculo) =>
        Ok(await _veiculoService.CriarAsync(veiculo));

    [HttpPut("{id}")]
    public async Task<ActionResult<Veiculo>> Put(Guid id, [FromBody] Veiculo veiculo)
    {
        if (id != veiculo.Id) return BadRequest();
        return Ok(await _veiculoService.AtualizarAsync(veiculo));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var sucesso = await _veiculoService.RemoverAsync(id);
        return sucesso ? Ok() : NotFound();
    }
}
