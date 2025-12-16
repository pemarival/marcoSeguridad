using marcoSeguridad.Models;
using marcoSeguridad.Services;
using Microsoft.AspNetCore.Mvc;

namespace marcoSeguridad.Controllers;

[ApiController]
[Route("[controller]")]
public class AuditoriaController : ControllerBase
{
    public AuditoriaController()
    {
    }

    // GET all
    [HttpGet]
    public ActionResult<List<Auditoria>> GetAll() =>
        AuditoriaService.GetAll();

    // GET by Id
    [HttpGet("{id}")]
    public ActionResult<Auditoria> Get(int id)
    {
        var auditoria = AuditoriaService.Get(id);

        if (auditoria == null)
            return NotFound();

        return auditoria;
    }

    // POST
    [HttpPost]
    public IActionResult Create(Auditoria auditoria)
    {
        AuditoriaService.Add(auditoria);
        return CreatedAtAction(
            nameof(Get),
            new { id = auditoria.AuditoriaID },
            auditoria
        );
    }

    // PUT
    [HttpPut("{id}")]
    public IActionResult Update(int id, Auditoria auditoria)
    {
        if (id != auditoria.AuditoriaID)
            return BadRequest();

        var existing = AuditoriaService.Get(id);
        if (existing is null)
            return NotFound();

        AuditoriaService.Update(auditoria);
        return NoContent();
    }

    // DELETE
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var auditoria = AuditoriaService.Get(id);
        if (auditoria is null)
            return NotFound();

        AuditoriaService.Delete(id);
        return NoContent();
    }
}
