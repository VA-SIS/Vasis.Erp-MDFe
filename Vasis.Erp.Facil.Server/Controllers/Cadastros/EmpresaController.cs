using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vasis.Erp.Facil.Data;
using Vasis.Erp.Facil.Shared.Entities.Cadastro;

namespace Vasis.Erp.Facil.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmpresaController : ControllerBase
{
    private readonly AppDbContext _context;

    public EmpresaController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Empresa>>> GetAll()
    {
        return await _context.Empresas.AsNoTracking().ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Empresa>> GetById(Guid id)
    {
        var empresa = await _context.Empresas.FindAsync(id);
        return empresa is null ? NotFound() : empresa;
    }

    [HttpPost]
    public async Task<ActionResult<Empresa>> Create(Empresa model)
    {
        model.Id = Guid.NewGuid();
        model.CriadoEm = DateTime.UtcNow;
        _context.Empresas.Add(model);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = model.Id }, model);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, Empresa model)
    {
        if (id != model.Id) return BadRequest();

        var entity = await _context.Empresas.FindAsync(id);
        if (entity is null) return NotFound();

        model.AtualizadoEm = DateTime.UtcNow;
        _context.Entry(entity).CurrentValues.SetValues(model);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var entity = await _context.Empresas.FindAsync(id);
        if (entity is null) return NotFound();

        _context.Empresas.Remove(entity);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
