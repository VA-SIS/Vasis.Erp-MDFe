using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vasis.Erp.Facil.Data;
using Vasis.Erp.Facil.Shared.Entities.Cadastros;

namespace Vasis.Erp.Facil.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PessoaController : ControllerBase
{
    private readonly AppDbContext _context;

    public PessoaController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Pessoa>>> GetAll()
    {
        return await _context.Pessoas.AsNoTracking().ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Pessoa>> GetById(Guid id)
    {
        var pessoa = await _context.Pessoas.FindAsync(id);
        return pessoa is null ? NotFound() : pessoa;
    }

    [HttpPost]
    public async Task<ActionResult<Pessoa>> Create(Pessoa model)
    {
        model.Id = Guid.NewGuid();
        model.CriadoEm = DateTime.UtcNow;
        _context.Pessoas.Add(model);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = model.Id }, model);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, Pessoa model)
    {
        if (id != model.Id) return BadRequest();

        var entity = await _context.Pessoas.FindAsync(id);
        if (entity is null) return NotFound();

        model.AtualizadoEm = DateTime.UtcNow;
        _context.Entry(entity).CurrentValues.SetValues(model);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var entity = await _context.Pessoas.FindAsync(id);
        if (entity is null) return NotFound();

        _context.Pessoas.Remove(entity);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
