using Microsoft.AspNetCore.Mvc;
using Vasis.Erp.Facil.Application.Interfaces.Services;
using Vasis.Erp.Facil.Shared.Entities.Cadastros;

namespace Vasis.Erp.Facil.Server.Controllers.Cadastros;

[ApiController]
[Route("api/[controller]")]
public class MotoristaController : ControllerBase
{
    private readonly IMotoristaService _motoristaService;

    public MotoristaController(IMotoristaService motoristaService)
    {
        _motoristaService = motoristaService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Motorista>>> Get() =>
        Ok(await _motoristaService.ListarAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult<Motorista?>> Get(Guid id)
    {
        var result = await _motoristaService.ObterPorIdAsync(id);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Motorista>> Post([FromBody] Motorista motorista) =>
        Ok(await _motoristaService.CriarAsync(motorista));

    [HttpPut("{id}")]
    public async Task<ActionResult<Motorista>> Put(Guid id, [FromBody] Motorista motorista)
    {
        if (id != motorista.Id) return BadRequest();
        return Ok(await _motoristaService.AtualizarAsync(motorista));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var sucesso = await _motoristaService.RemoverAsync(id);
        return sucesso ? Ok() : NotFound();
    }
}
