using Microsoft.AspNetCore.Mvc;
using Vasis.Erp.Facil.Application.Interfaces.Services;
using Vasis.Erp.Facil.Shared.Entities.Cadastros;

namespace Vasis.Erp.Facil.Server.Controllers.Cadastros;

[ApiController]
[Route("api/[controller]")]
public class PessoaController : ControllerBase
{
    private readonly IPessoaService _pessoaService;

    public PessoaController(IPessoaService pessoaService)
    {
        _pessoaService = pessoaService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Pessoa>>> Get() =>
        Ok(await _pessoaService.ListarAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult<Pessoa?>> Get(Guid id)
    {
        var result = await _pessoaService.ObterPorIdAsync(id);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Pessoa>> Post([FromBody] Pessoa pessoa) =>
        Ok(await _pessoaService.CriarAsync(pessoa));

    [HttpPut("{id}")]
    public async Task<ActionResult<Pessoa>> Put(Guid id, [FromBody] Pessoa pessoa)
    {
        if (id != pessoa.Id) return BadRequest();
        return Ok(await _pessoaService.AtualizarAsync(pessoa));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var sucesso = await _pessoaService.RemoverAsync(id);
        return sucesso ? Ok() : NotFound();
    }
}
