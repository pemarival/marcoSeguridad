using marcoSeguridad.Models;
using marcoSeguridad.Services;
using Microsoft.AspNetCore.Mvc;

namespace marcoSeguridad.Controllers;

[ApiController]
[Route("[controller]")]
public class SesionUsuarioController : ControllerBase
{
    public SesionUsuarioController()
    {
    }

    // GET all
    [HttpGet]
    public ActionResult<List<SesionUsuario>> GetAll() =>
        SesionUsuarioService.GetAll();

    // GET by Id
    [HttpGet("{id}")]
    public ActionResult<SesionUsuario> Get(int id)
    {
        var sesion = SesionUsuarioService.Get(id);

        if (sesion == null)
            return NotFound();

        return sesion;
    }

    // POST
    [HttpPost]
    public IActionResult Create(SesionUsuario sesion)
    {
        SesionUsuarioService.Add(sesion);
        return CreatedAtAction(
            nameof(Get),
            new { id = sesion.SesionID },
            sesion
        );
    }

    // PUT
    [HttpPut("{id}")]
    public IActionResult Update(int id, SesionUsuario sesion)
    {
        if (id != sesion.SesionID)
            return BadRequest();

        var existing = SesionUsuarioService.Get(id);
        if (existing is null)
            return NotFound();

        SesionUsuarioService.Update(sesion);
        return NoContent();
    }

    // DELETE
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var sesion = SesionUsuarioService.Get(id);
        if (sesion is null)
            return NotFound();

        SesionUsuarioService.Delete(id);
        return NoContent();
    }
}
