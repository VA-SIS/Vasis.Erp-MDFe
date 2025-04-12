using Microsoft.AspNetCore.Mvc;
using Vasis.Erp.Facil.Services;
using Vasis.Erp.Facil.Shared.Entities.Cadastros;

namespace Vasis.Erp.Facil.Server.Controllers.Cadastros;

[ApiController]
[Route("api/[controller]")]
public class MotoristaController : ControllerBase
{
    private readonly MotoristaService _service;

    public MotoristaController(MotoristaService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Motorista>>> Get()
        => Ok(await _service.ListarAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult<Motorista>> GetById(Guid id)
    {
        var obj = await _service.ObterPorIdAsync(id);
        return obj is null ? NotFound() : Ok(obj);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] Motorista obj)
    {
        await _service.AdicionarAsync(obj);
        return Ok(obj);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(Guid id, [FromBody] Motorista obj)
    {
        if (id != obj.Id) return BadRequest();
        await _service.AtualizarAsync(obj);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await _service.RemoverAsync(id);
        return NoContent();
    }
}
