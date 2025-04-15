using Microsoft.AspNetCore.Mvc;
using Vasis.Erp.Facil.Application.Interfaces.Services;
using Vasis.Erp.Facil.Shared.Entities.Cadastros;

namespace Vasis.Erp.Facil.Server.Controllers.Cadastros;

[ApiController]
[Route("api/[controller]")]
public class TransportadoraController : ControllerBase
{
    private readonly ITransportadoraService _transportadoraService;

    public TransportadoraController(ITransportadoraService transportadoraService)
    {
        _transportadoraService = transportadoraService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Transportadora>>> Get() =>
        Ok(await _transportadoraService.ListarAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult<Transportadora?>> Get(Guid id)
    {
        var result = await _transportadoraService.ObterPorIdAsync(id);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Transportadora>> Post([FromBody] Transportadora transportadora) =>
        Ok(await _transportadoraService.CriarAsync(transportadora));

    [HttpPut("{id}")]
    public async Task<ActionResult<Transportadora>> Put(Guid id, [FromBody] Transportadora transportadora)
    {
        if (id != transportadora.Id) return BadRequest();
        return Ok(await _transportadoraService.AtualizarAsync(transportadora));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var sucesso = await _transportadoraService.RemoverAsync(id);
        return sucesso ? Ok() : NotFound();
    }
}
