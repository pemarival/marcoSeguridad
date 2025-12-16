using marcoSeguridad.Models;
using marcoSeguridad.Services;
using Microsoft.AspNetCore.Mvc;

namespace marcoSeguridad.Controllers;

[ApiController]
[Route("[controller]")]
public class PoliticaController : ControllerBase
{
    public PoliticaController()
    {
    }

    // GET all
    [HttpGet]
    public ActionResult<List<Politica>> GetAll() =>
        PoliticaService.GetAll();

    // GET by Id
    [HttpGet("{id}")]
    public ActionResult<Politica> Get(int id)
    {
        var politica = PoliticaService.Get(id);

        if (politica == null)
            return NotFound();

        return politica;
    }

    // POST
    [HttpPost]
    public IActionResult Create(Politica politica)
    {
        PoliticaService.Add(politica);
        return CreatedAtAction(nameof(Get), new { id = politica.PoliticaID }, politica);
    }

    // PUT
    [HttpPut("{id}")]
    public IActionResult Update(int id, Politica politica)
    {
        if (id != politica.PoliticaID)
            return BadRequest();

        var existing = PoliticaService.Get(id);
        if (existing is null)
            return NotFound();

        PoliticaService.Update(politica);
        return NoContent();
    }

    // DELETE
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var politica = PoliticaService.Get(id);
        if (politica is null)
            return NotFound();

        PoliticaService.Delete(id);
        return NoContent();
    }
}
