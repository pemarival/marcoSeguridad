using marcoSeguridad.Models;
using marcoSeguridad.Services;
using Microsoft.AspNetCore.Mvc;

namespace marcoSeguridad.Controllers;

[ApiController]
[Route("[controller]")]
public class PermisoController : ControllerBase
{
    public PermisoController()
    {
    }

    // GET all
    [HttpGet]
    public ActionResult<List<Permiso>> GetAll() =>
        PermisoService.GetAll();

    // GET by Id
    [HttpGet("{id}")]
    public ActionResult<Permiso> Get(int id)
    {
        var permiso = PermisoService.Get(id);

        if (permiso == null)
            return NotFound();

        return permiso;
    }

    // POST
    [HttpPost]
    public IActionResult Create(Permiso permiso)
    {
        PermisoService.Add(permiso);
        return CreatedAtAction(
            nameof(Get),
            new { id = permiso.PermisoID },
            permiso
        );
    }

    // PUT
    [HttpPut("{id}")]
    public IActionResult Update(int id, Permiso permiso)
    {
        if (id != permiso.PermisoID)
            return BadRequest();

        var existing = PermisoService.Get(id);
        if (existing is null)
            return NotFound();

        PermisoService.Update(permiso);
        return NoContent();
    }

    // DELETE
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var permiso = PermisoService.Get(id);
        if (permiso is null)
            return NotFound();

        PermisoService.Delete(id);
        return NoContent();
    }
}
